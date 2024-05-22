using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Api_Project.DAL.Data.Models.Products;
namespace Final_Api_Project.DAL.Data.Models.Carts
{
    public class CartItem
    {

        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
