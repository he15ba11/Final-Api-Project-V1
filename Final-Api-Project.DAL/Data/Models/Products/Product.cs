using Final_Api_Project.DAL.Data.Models.Authorization;
using Final_Api_Project.DAL.Data.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Data.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public int CategoryId { get; set; } 
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public Category Category { get; set; }

    }

}
