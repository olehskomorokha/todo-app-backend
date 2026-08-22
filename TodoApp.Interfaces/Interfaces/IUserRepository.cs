using TodoApp.Data.Entities;

namespace TodoApp.Interfaces.Interfaces;

public interface IUserRepository : ICrud<User>
{
    public Task<User> GetByEmailAsync(string email);
}