namespace TodoApp.Services.Models.User;

public class UpdateUserDto
{
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}