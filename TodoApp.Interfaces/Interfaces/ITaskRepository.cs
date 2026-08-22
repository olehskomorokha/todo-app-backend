using TodoApp.Data.Entities;

namespace TodoApp.Interfaces.Interfaces;

public interface ITaskRepository
{
    public Task<TaskToDo> GetByIdAsync(int id);

    public Task<List<TaskToDo>> GetAllAsync(int items, int page);

    public Task AddAsync(TaskToDo model);
 
    public Task UpdateAsync(TaskToDo model);

    public Task DeleteAsync(TaskToDo model);
}