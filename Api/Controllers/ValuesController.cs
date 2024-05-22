using Final_Api_Project.DAL.Data.Models.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITI.ISM.APIs.Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public ValuesController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [Authorize]
    [HttpGet]
    [Route("user")]
    public ActionResult<List<string>> GetEmployeesNames()
    {
        var currentUser = User;
        return new List<string> { "Ahmed", "Muahmmed", "Yara", "Yousef", "Hadeer" };
    }

    [Authorize(Policy = "ManagersOnly")]
    [HttpGet]
    [Route("for-manager")]
    public async Task<ActionResult<List<string>>> GetEmployeesNamesForManager()
    {
        User? user = await _userManager.GetUserAsync(User);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        User? user2 = await _userManager.FindByIdAsync(userId);

        return new List<string> { "For", "Managers", "Only" };
    }
}
