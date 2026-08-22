using TodoApp.Data.Entities;

namespace TodoApp.Interfaces.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int userId);
    Task<List<User>> GetAllAsync();
    Task AddAsync(User model);
    Task UpdateAsync(User model);
    Task DeleteAsync(User model);
}