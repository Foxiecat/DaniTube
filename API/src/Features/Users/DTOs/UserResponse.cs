namespace src.Features.Users.DTOs;

public class UserResponse
{
    public Guid Id { get; init; }
    public string Username { get; init; } = string.Empty;
}