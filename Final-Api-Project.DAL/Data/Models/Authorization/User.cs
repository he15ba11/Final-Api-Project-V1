using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Api_Project.DAL.Data.Models.Carts;
using Final_Api_Project.DAL.Data.Models.Orders;
namespace Final_Api_Project.DAL.Data.Models.Authorization
{
    public class User : IdentityUser<int>
    {
        public int CartId { get; set; }    
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

}
