using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Data.Models.Authorization;
using Final_Api_Project.DAL.Data.Models.Products;
using Final_Api_Project.DAL.Repositories.Generic;
using Final_Api_Project.DAL.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(E_CommerceContext context) : base(context)
        {
        }

        public User GetUserDetails(int userId)
        {
            return _context.Users
                .FirstOrDefault(p => p.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            IQueryable<User> query = _context.Users;
            return query.ToList();
        }
    }
}
