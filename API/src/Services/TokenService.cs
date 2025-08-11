using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using src.Config;
using src.Features.Users;
using src.Features.Users.Interfaces;
using src.Services.Interfaces;

namespace src.Services;

public class TokenService(IOptions<JwtOptions> options) : ITokenService
{
    public Task<IUser> LoginAsync(string username, string password)
    {
        return Task.FromResult<IUser>(new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Roles =
            [
                new Role {Id = Guid.NewGuid(), Name = "Admin"},
                new Role {Id = Guid.NewGuid(), Name = "User"}
            ]
        });
    }

    public Task<string> CreateTokenAsync(IUser user)
    {
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username)
        ];

        foreach (IRole role in user.Roles)
            claims.Add(new Claim(ClaimTypes.Role, role.Name!));

        var secrets = Encoding.UTF8.GetBytes(options.Value.Key ?? throw new InvalidOperationException());
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = options.Value.Issuer,
            Audience = options.Value.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secrets), SecurityAlgorithms.HmacSha256Signature)
        };
        
        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }

    public (string? userId, IEnumerable<string>? roles) ValidateAccessToken(string accessToken)
    {
        try
        {
            JwtSecurityTokenHandler tokenHandler = new();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Key ?? throw new InvalidOperationException()));

            tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = key,
                ValidIssuer = options.Value.Issuer,
                ValidAudience = options.Value.Audience,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            
            JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
            
            string userId = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            IEnumerable<string> roles = jwtToken.Claims
                .Where(token => token.Type == ClaimTypes.Role)
                .Select(token => token.Value);
            return (userId, roles);
        }
        catch (Exception e)
        {
            return (null, null);
        }
    }
}