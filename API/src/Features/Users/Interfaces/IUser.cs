namespace src.Features.Users.Interfaces;

public interface IUser
{
    Guid Id { get; init; }
    string Username { get; init; }
    string HashedPassword { get; init; }
    
    ICollection<IRole> Roles { get; set; }
}