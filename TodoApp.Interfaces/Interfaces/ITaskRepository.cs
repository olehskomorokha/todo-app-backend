using TodoApp.Data.Entities;

namespace TodoApp.Interfaces.Interfaces;

public interface ITaskRepository
{
    Task<TaskToDo> GetByIdAsync(int id);

    Task<List<TaskToDo>> GetAllAsync(int items, int page);

    Task AddAsync(TaskToDo model);

    Task UpdateAsync(TaskToDo model);

    Task DeleteAsync(TaskToDo model);
}