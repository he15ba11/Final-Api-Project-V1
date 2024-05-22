using Final_Api_Project.BL.Dtos.Products;
using Final_Api_Project.BL.Dtos.Users;
using Final_Api_Project.BL.Managers.Products;
using Final_Api_Project.DAL;
using Final_Api_Project.DAL.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.Users
{
    internal class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserDetailsDto? GetUserDetails(int userId)
        {
            var user = _unitOfWork.UserRepository.GetUserDetails(userId);
            if (user != null)
            {
                return new UserDetailsDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };
            }
            return null;
        }

        public IEnumerable<UsersDto> GetUsers()
        {
            var users = _unitOfWork.UserRepository.GetUsers();
            return users.Select(u => new UsersDto
            {
                Id=u.Id,
                UserName= u.UserName,
                Email=u.Email,
                PhoneNumber=u.PhoneNumber
                
            });
        }
    }
}
