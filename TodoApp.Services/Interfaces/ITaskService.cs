using TodoApp.Services.Models.Task;

namespace TodoApp.Services.Interfaces;

public interface ITaskService
{
    public Task<TaskDto> GetByIdAsync(int id);

    public Task<List<TaskDto>> GetAllAsync(int items, int page);

    public Task AddAsync(AddTaskDto model);

    public Task UpdateAsync(int id, UpdateTaskDto model);

    public Task DeleteAsync(int id);
}