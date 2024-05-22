using Final_Api_Project.DAL.Data.Models.Authorization;
using Final_Api_Project.DAL.Data.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Dtos.Carts
{
    public class CartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<CartItemDTO> CartItems { get; set; }= [];
    }
}
