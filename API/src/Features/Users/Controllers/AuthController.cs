using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using src.Features.Users.DTOs;
using src.Features.Users.Entities;
using src.Features.Users.Interfaces;
using src.Services.Interfaces;

namespace src.Features.Users.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    IUserService userService,
    ITokenService tokenService, 
    ILogger<UserController> logger) : ControllerBase
{
    public static User user = new();
     
    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Register(UserRequest request)
    {
        UserResponse? response = await userService.CreateAsync(request);
        
        return response is null
            ? BadRequest("Unable to create user")
            : Ok(response);
    }

    [HttpPost("login")]
    public Task<IActionResult> Login(string? usernameOrEmail, string password)
    {
        throw new NotImplementedException();
    }
    
    // public Task<ActionResult<string>> Login(UserResponse request)
    // {
    //     if (request.Username != user.Username || new PasswordHasher<User>()
    //             .VerifyHashedPassword(user, user.HashedPassword, request.Password) == PasswordVerificationResult.Failed)
    //     {
    //         return BadRequest("Username or password is incorrect");
    //     }
    //     
    //     string token = tokenService.CreateTokenAsync(user);
    //     return Ok(token);
    // }
}