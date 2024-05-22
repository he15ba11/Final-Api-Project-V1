using Final_Api_Project.DAL.Data.Models.Authorization;
using Final_Api_Project.DAL.Data.Models.Products;
using Final_Api_Project.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Repositories.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetUsers();
        User GetUserDetails(int userId);
    }
}
