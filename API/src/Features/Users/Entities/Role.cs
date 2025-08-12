using src.Features.Users.Interfaces;

namespace src.Features.Users.Entities;

public class Role : IRole
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}