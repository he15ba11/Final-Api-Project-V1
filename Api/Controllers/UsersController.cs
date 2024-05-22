using Final_Api_Project.BL.Dtos.Products;
using Final_Api_Project.BL.Dtos.Users;
using Final_Api_Project.BL.Managers.Users;
using Final_Api_Project.DAL.Data.Models.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Api_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
{
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UsersDto>> GetUsers()
        {
            var users = _userManager.GetUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDetailsDto> GetUserDetails(int userId)
        {
            var userDetails = _userManager.GetUserDetails(userId);
            if (userDetails == null)
                return NotFound();

            return userDetails;
        }

    }
}
