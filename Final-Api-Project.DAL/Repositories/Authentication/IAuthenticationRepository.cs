using Final_Api_Project.DAL.Data.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Repositories.Authentication
{
    public interface IAuthenticationRepository
    {
        bool CreateUser(User user, string password); 
        Task <bool> SignOut();
        User AuthenticateUser(string username, string password);
        User GetUser(string username);

    }
}
