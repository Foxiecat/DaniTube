using src.Features.Users.Interfaces;

namespace src.Features.Users.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string HashedPassword { get; set; } =  string.Empty;
    
    public ICollection<IRole> Roles { get; set; } =  new List<IRole>();
}