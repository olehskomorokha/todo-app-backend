using TodoApp.Data.Entities;
using TodoApp.Services.Models.User;

namespace TodoApp.Services.Interfaces;

public interface IJwtService
{
    public Task<string> Authenticate(LoginUserDto userDto);
}