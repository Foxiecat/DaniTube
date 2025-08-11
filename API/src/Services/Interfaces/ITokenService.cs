using src.Features.Users.Interfaces;

namespace src.Services.Interfaces;

public interface ITokenService
{
    Task<IUser> LoginAsync(string username, string password);
    Task<string> CreateTokenAsync(IUser user);
    
    (string? userId, IEnumerable<string>? roles) ValidateAccessToken(string accessToken);
}