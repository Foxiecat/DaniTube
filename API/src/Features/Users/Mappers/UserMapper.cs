using src.Features.Common.Interfaces;
using src.Features.Users.DTOs;
using src.Features.Users.Entities;

namespace src.Features.Users.Mappers;

public class UserMapper : IMapper<User, UserResponse, UserRequest>
{
    public UserResponse MapToResponse(User model)
    {
        return new UserResponse
        {
            Id = model.Id,
            Username = model.Username,
        };
    }

    public User MapToModel(UserRequest request)
    {
        return new User
        {
            Username = request.Username,
            Email = request.Email,
        };
    }
}