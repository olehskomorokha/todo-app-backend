using TodoApp.Data.Entities;

namespace TodoApp.Interfaces.Interfaces;

public interface ITaskRepository : ICrud<TaskToDo>
{
    public Task<List<TaskToDo>> GetByPageAsync(int items, int page);
}