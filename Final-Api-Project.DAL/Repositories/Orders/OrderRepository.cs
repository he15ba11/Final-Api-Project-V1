using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Data.Models.Orders;
using Final_Api_Project.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Api_Project.DAL.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(E_CommerceContext context) : base(context)
        {
        }

        public decimal CalculateTotalPrice(int orderId)
        {
            return _context.Orders
                .Where(o => o.Id == orderId)
                .Select(o => o.OrderItems.Sum(oi => oi.Quantity * oi.Price))
                .FirstOrDefault();
        }

        public Order GetOrderDetails(int orderId)
        {
            return _context.Orders
               .Include(o => o.OrderItems)
                   .ThenInclude(oi => oi.Product)
               .FirstOrDefault(o => o.Id == orderId);
        }

        public Order GetOrdersByUserId(int userId)
        {
            return _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product).OrderBy(c=>c.CreateAt)
                    .LastOrDefault(o=>o.UserId==userId);

        }

    }
}
