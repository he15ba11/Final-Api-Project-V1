using Final_Api_Project.BL.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.Users
{
    public interface IUserManager
    {
        IEnumerable<UsersDto> GetUsers();
        UserDetailsDto? GetUserDetails(int userId);
    }
}
