using TodoApp.Services.Models.Task;

namespace TodoApp.Services.Interfaces;

public interface ITaskService
{
    public Task<TaskDto> GetByIdAsync(int id);

    public Task<List<TaskDto>> GetByPageAsync(int items, int page);

    public Task AddAsync(AddTaskDto taskDto);

    public Task UpdateAsync(int id, UpdateTaskDto taskDto);

    public Task DeleteAsync(int id);
}