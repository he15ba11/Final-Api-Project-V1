using Final_Api_Project.DAL.Data.Models.Orders;
using Final_Api_Project.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Repositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        decimal CalculateTotalPrice(int orderId);
        Order GetOrdersByUserId(int userId);
        Order GetOrderDetails(int orderId);

    }
}
