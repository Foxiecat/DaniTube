namespace src.Features.Users.DTOs;

public class UserRequest
{
    public string Username { get; init; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; init; } =  string.Empty;
}