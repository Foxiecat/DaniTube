using src.Features.Common.Interfaces;
using src.Features.Users;
using src.Features.Users.DTOs;
using src.Features.Users.Entities;
using src.Features.Users.Interfaces;
using src.Features.Users.Mappers;

namespace src.Extensions;

public static class ScopedFeaturesServicesExtension
{
    public static void AddScopedFeaturesServices(this IServiceCollection services)
    {
        // User
        services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IMapper<User, UserResponse, UserRequest>, UserMapper>();
    }
}