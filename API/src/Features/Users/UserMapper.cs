using src.Features.Common.Interfaces;
using src.Features.Users.DTOs;

namespace src.Features.Users;

public class UserMapper : IMapper<User, UserResponse>
{
    public UserResponse MapToResponse(User request)
    {
        return new UserResponse
        {
            Id = request.Id,
            Username = request.Username,
        };
    }

    public User MapToRequest(UserResponse response)
    {
        return new User
        {
            Id = response.Id,
            Username = response.Username,
        };
    }
}