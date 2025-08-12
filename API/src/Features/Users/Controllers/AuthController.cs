using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using src.Features.Users.Entities;
using src.Features.Users.Interfaces;
using src.Features.Users.Models;
using src.Services.Interfaces;

namespace src.Features.Users.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(ITokenService tokenService) : ControllerBase
{
    public static User user = new();
     
    [HttpPost("register")]
    public ActionResult<User> Register(UserDto request)
    {
        string hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
        
        user.Id = Guid.NewGuid();
        user.Username = request.Username;
        user.Roles = new List<IRole> { new Role {Id = Guid.NewGuid(), Name = "User"} };
        
        user.HashedPassword = hashedPassword;

        return Ok(user);
    }

    [HttpPost("login")]
    public ActionResult<string> Login(UserDto request)
    {
        if (request.Username != user.Username || new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.HashedPassword, request.Password) != PasswordVerificationResult.Success)
        {
            return BadRequest("Username or password is incorrect");
        }
        
        string token = tokenService.CreateTokenAsync(user);
        return Ok(token);
    }
}