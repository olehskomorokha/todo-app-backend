using TodoApp.Data.Entities;

namespace TodoApp.Interfaces.Interfaces;

public interface IUserRepository
{
    public Task<User> GetByIdAsync(int userId);
    public Task<List<User>> GetAllAsync();
    public Task AddAsync(User model);
    public Task UpdateAsync(User model);
    public Task DeleteAsync(User model);
}