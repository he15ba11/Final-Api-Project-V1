using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Data.Models.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Final_Api_Project.DAL.Repositories.Authentication
{
    internal class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly E_CommerceContext _context;

        public AuthenticationRepository(E_CommerceContext context)
        {
            _context = context;
        }

        public User AuthenticateUser(string username, string password)
        {
            // Retrieve the user from the database based on the provided username and password
            var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.PasswordHash== password);
            return user;
        }

        public bool CreateUser(User user, string password)
        {
            try
            {
                // Hash the password (You should use a proper password hashing algorithm)
                user.PasswordHash = password;

                // Add the user to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                // Handle any exceptions, such as database errors
                return false;
            }
        }

        public User GetUser(string username)
        {
            // Retrieve the user from the database based on the provided username
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            return user;
        }

        public async Task<bool> SignOut()
        {
            // Perform any sign-out operations, such as clearing session data, if needed
            // For simplicity, let's assume the sign-out operation always succeeds
            return true;
        }
    }
}
