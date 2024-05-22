using Final_Api_Project.DAL.Repositories.Orders;
using Final_Api_Project.BL.Dtos.Orders;
using System.Collections.Generic;
using System.Linq;
using Final_Api_Project.DAL;
using Final_Api_Project.DAL.Data.Enums;
using Final_Api_Project.DAL.Data.Models.Orders;

namespace Final_Api_Project.BL.Managers.Orders
{
    public class OrderManager:IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
        public decimal CalculateTotalPrice(int orderId)
        {
            return _unitOfWork.OrderRepository.CalculateTotalPrice(orderId);
        }

        public OrderDTO GetOrderDetails(int orderId)
        {
                var order = _unitOfWork.OrderRepository.GetOrderDetails(orderId);
                if (order == null) return null;

                return new OrderDTO
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    CreateAt = order.CreateAt,
                    TotalPrice = order.TotalPrice,
                    Status = order.Status,
                    UpdatedAt = order.UpdatedAt,
                    OrderItems = order.OrderItems.Select(oi => new OrderItemDTO
                    {
                        Id = oi.Id,
                        ProductId = oi.ProductId,
                        OrderId = oi.OrderId,
                        Quantity = oi.Quantity,
                        Price = oi.Price,
                        OrderStatus = oi.OrderStatus,
                        ProductName = oi.Product.Name
                    }).ToList()
                };
            }

        public OrderDTO GetOrdersByUserId(int userId)
        {
            var orders = _unitOfWork.OrderRepository.GetOrdersByUserId(userId);

            return  new OrderDTO
            {
                Id = orders.Id,
                UserId = orders.UserId,
                CreateAt = orders.CreateAt,
                TotalPrice = orders.TotalPrice,
                Status = orders.Status,
                UpdatedAt = orders.UpdatedAt,
                OrderItems = orders.OrderItems.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    OrderId = oi.OrderId,
                    Quantity = oi.Quantity,
                    Price = oi.Price,
                    OrderStatus = oi.OrderStatus,
                    ProductName = oi.Product.Name
                }).ToList()
            };
        }

        public int PlaceOrder(int userId)
        {
            _unitOfWork.OrderRepository.Delete(_unitOfWork.OrderRepository.GetOrdersByUserId(userId).Id);
            var cart = _unitOfWork.CartRepository.GetCartByUserId(userId);
            if(cart == null) { return 1; }
            var orderItems = cart.CartItems.Select(ci => new OrderItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                Price = ci.Product.Price, // Assuming Product has a Price property
                OrderStatus = OrderStatus.Pending
            }).ToList();

            var order = new Order
            {
                UserId = userId,
                CreateAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                OrderItems = orderItems,
                TotalPrice = orderItems.Sum(oi => oi.Quantity * oi.Price)
            };
            if (orderItems.Count==0)
            {
            return 2;
            }
            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.SaveChanges();
            return 0;
        }


    }
}
