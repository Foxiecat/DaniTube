using src.Features.Common.Interfaces;
using src.Features.Users.Entities;
using src.Features.Users.Models;

namespace src.Features.Users;

public class UserMapper : IMapper<User, UserDto>
{
    public UserDto MapToResponse(User request)
    {
        return new UserDto
        {
            Id = request.Id,
            Username = request.Username,
        };
    }

    public User MapToRequest(UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            Username = dto.Username,
        };
    }
}