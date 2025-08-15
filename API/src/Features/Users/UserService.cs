using Microsoft.AspNetCore.Identity;
using src.Features.Common.Interfaces;
using src.Features.Users.DTOs;
using src.Features.Users.Entities;
using src.Features.Users.Interfaces;

namespace src.Features.Users;

public class UserService(
    ILogger<UserService> logger,
    IMapper<User, UserResponse, UserRequest> userMapper,
    IUserRepository userRepository,
    IHttpContextAccessor context) : IUserService
{
    public async Task<UserResponse?> CreateAsync(UserRequest request)
    {
        bool usernameExists = (await userRepository.FindAsync(user => user.Username == request.Username)).Any();
        bool emailExists = (await userRepository.FindAsync(user => user.Email == request.Email)).Any();
        
        if (usernameExists)
        {
            logger.LogWarning("Username taken");
            throw new InvalidOperationException("Username already taken");
        }
        if (emailExists)
        {
            logger.LogWarning("Email already exists");
            throw new InvalidOperationException("Email already exists");
        }

        User user = userMapper.MapToModel(request);
        user.Id = Guid.NewGuid();
        user.Created = DateTime.UtcNow;
        user.HashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
        user.Roles.Add(new Role {Id = Guid.NewGuid(), Name = "User"});
        
        User registeredUser = await userRepository.AddAsync(user);
        return userMapper.MapToResponse(registeredUser);
    }

    public async Task<UserResponse> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserResponse>> FindAsync(UserRequest model)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponse> UpdateAsync(UserRequest model)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(UserRequest model)
    {
        throw new NotImplementedException();
    }
}