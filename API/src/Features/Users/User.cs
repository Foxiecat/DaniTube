using src.Features.Users.Interfaces;

namespace src.Features.Users;

public class User : IUser
{
    public Guid Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string HashedPassword { get; init; } =  string.Empty;
    
    public ICollection<IRole> Roles { get; set; }
}