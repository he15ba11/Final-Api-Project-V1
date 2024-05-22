using Final_Api_Project.BL.Dtos.Carts;
using Final_Api_Project.BL.Dtos.Users;
using Final_Api_Project.BL.Managers.Carts;
using Final_Api_Project.DAL.Data.Models.Authorization;
using Final_Api_Project.DAL.Data.Models.Carts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ITI.ISM.APIs.Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IConfiguration configuration,
    UserManager<User> userManager,ICartManager cartManager) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;
    private readonly UserManager<User> _userManager = userManager;
    private readonly ICartManager _cartManager= cartManager;

    //#region Static Login

    //[HttpPost]
    //[Route("static-login")]
    //public ActionResult<TokenDto> StaticLogin(LoginDto loginDto)
    //{
    //    bool isAuthenticated = loginDto.UserName == "Admin" && loginDto.Password == "123";
    //    if (!isAuthenticated)
    //    {
    //        return Unauthorized(); // 401
    //    }

    //    //Generate Token
    //    var userClaims = new List<Claim>
    //    {
    //        new ("My Custom Key", "My Custom Value"),
    //        new (ClaimTypes.NameIdentifier, int.Newint().ToString()),
    //        new (ClaimTypes.Name, loginDto.UserName),
    //        new (ClaimTypes.Role, "Admin"),
    //    };

    //    return GenerateToken(userClaims);
    //}

    //#endregion

    #region Register

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
        };
        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors); // 400, Errors
        }

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName),
            new (ClaimTypes.Email, user.Email),
            new(ClaimTypes.MobilePhone,user.PhoneNumber),
        };
        
       
        await _userManager.AddClaimsAsync(user, claims);
        var cartDto = new CartDto
        {
            UserId = user.Id,
            CreatedDate = DateTime.UtcNow,
        };

        _cartManager.AddCart(cartDto);
        return Content("Has Registered Succsessfully");
    }

    #endregion

    #region Login

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if (user == null)
        {
            return Unauthorized(); // 401
        }

        bool isAuthenticated = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!isAuthenticated)
        {
            return Unauthorized(); // 401
        }

        var userClaims = await _userManager.GetClaimsAsync(user);

        return GenerateToken(userClaims);
    }

    #endregion

    #region Helpers

    private ActionResult<TokenDto> GenerateToken(IEnumerable<Claim> userClaims)
    {
        var keyFromConfig = _configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
        var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
        var key = new SymmetricSecurityKey(keyInBytes);

        var signingCredentials = new SigningCredentials(key,
            SecurityAlgorithms.HmacSha256Signature);

        var expiryDateTime = DateTime.Now.AddMinutes(10);

        var jwt = new JwtSecurityToken(
            claims: userClaims,
            expires: expiryDateTime,
            signingCredentials: signingCredentials);

        var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new TokenDto(jwtAsString, expiryDateTime);
    }

    #endregion

}
