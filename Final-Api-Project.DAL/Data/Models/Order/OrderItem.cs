using Final_Api_Project.DAL.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Api_Project.DAL.Data.Models.Products;
namespace Final_Api_Project.DAL.Data.Models.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Product Product { get; set; } 
        public Order Order { get; set; }
    }
}
