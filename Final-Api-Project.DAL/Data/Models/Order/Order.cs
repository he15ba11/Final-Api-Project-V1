using Final_Api_Project.DAL.Data.Enums;
using Final_Api_Project.DAL.Data.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Data.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateAt { get; set; }= DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } 
        public User User { get; set; } 
        public OrderStatus Status { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
