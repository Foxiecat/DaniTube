using FastEndpoints;
using src.Features.Users.DTOs;
using src.Features.Users.Interfaces;
using src.Services.Interfaces;

namespace src.Features.Users.Endpoints;

public class RegisterUserEndpoint(
    ITokenService tokenService,
    IUserService userService) : Endpoint<UserRequest, UserResponse>
{
    public override void Configure()
    {
        Post("/api/user/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserRequest request, CancellationToken cancellationToken)
    {
        UserResponse? response = await userService.CreateAsync(request);
        
        
    }
}