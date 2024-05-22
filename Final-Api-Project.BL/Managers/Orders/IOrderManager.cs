using Final_Api_Project.BL.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.Orders
{
    public interface IOrderManager
    {
        public int PlaceOrder(int userId);
        public OrderDTO GetOrdersByUserId(int userId);
        public OrderDTO GetOrderDetails(int orderId);
        public decimal CalculateTotalPrice(int orderId);
    }
}
