namespace src.Features.Users.Models;

public class UserDto
{
    public Guid Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } =  string.Empty;
}