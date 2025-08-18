using FastEndpoints;
using src.Features.Common.Interfaces;
using src.Features.Users.DTOs;
using src.Features.Users.Entities;

namespace src.Features.Users.Mappers;

/*public class UserMapper : IMapper<User, UserResponse, UserRequest>
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
}*/

public class UserMapper : Mapper<UserRequest, UserResponse, User>
{
    public override User ToEntity(UserRequest request) => new()
    {
        Username = request.Username,
        Email = request.Email
    };

    public override UserResponse FromEntity(User user) => new()
    {
        Id = user.Id,
        Username = user.Username,
        Email = user.Email,
        Created = user.Created,
        Updated = user.Updated
    };
}