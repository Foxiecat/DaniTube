namespace src.Features.Users.Interfaces;

public interface IUser
{
    Guid Id { get; set; }
    string Username { get; set; }
    string HashedPassword { get; set; }
    
    ICollection<IRole> Roles { get; set; }
}