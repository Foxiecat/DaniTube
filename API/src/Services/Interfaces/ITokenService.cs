using src.Features.Users.Entities;
using src.Features.Users.Interfaces;

namespace src.Services.Interfaces;

public interface ITokenService
{
    string CreateTokenAsync(User user);
    
    (string? userId, IEnumerable<string>? roles) ValidateAccessToken(string accessToken);
}