using TodoApp.Data.Entities;
using TodoApp.Services.Models.User;

namespace TodoApp.Services.Interfaces;

public interface IUserService
{
    public Task<UserDto> GetByIdAsync(int id);
    public Task<List<UserDto>> GetAllAsync();
    public Task AddAsync(AddUserDto user);
    public Task UpdateAsync(int id, UpdateUserDto user);
    public Task DeleteAsync(int id);
}