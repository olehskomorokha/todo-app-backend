using TodoApp.Interfaces.Interfaces;
using TodoApp.Services.Mappers;
using TodoApp.Services.Models.Task;

namespace TodoApp.Services.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskDto> GetByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return TaskMapper.MapToTaskDto(task);
    }

    public async Task<List<TaskDto>> GetAllAsync(int items, int page)
    {
        var tasks = await _taskRepository.GetAllAsync(items, page);
        return tasks.Select(TaskMapper.MapToTaskDto).ToList();
    }

    public async Task AddAsync(AddTaskDto model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        await _taskRepository.AddAsync(TaskMapper.MapToAddTask(model));
    }

    public async Task UpdateAsync(int id, UpdateTaskDto model)
    {
        var modelToUpdate = await _taskRepository.GetByIdAsync(id);
        if (modelToUpdate == null)
        {
            throw new KeyNotFoundException($"Task with id {id} was not found.");
        }

        if (model.Deadline != null)
        {
            modelToUpdate.Deadline = model.Deadline.Value;
        }

        if (model.Remind != null)
        {
            modelToUpdate.Remind = model.Remind.Value;
        }

        if (model.IsFinished != null)
        {
            modelToUpdate.IsFinished = model.IsFinished.Value;
        }

        if (model.Description != null)
        {
            modelToUpdate.Description = model.Description;
        }

        if (model.Name != null)
        {
            modelToUpdate.Name = model.Name;
        }

        if (model.CategoryId != null)
        {
            modelToUpdate.CategoryId = model.CategoryId.Value;
        }

        await _taskRepository.UpdateAsync(modelToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var modelToDelete = await _taskRepository.GetByIdAsync(id);

        if (modelToDelete == null)
        {
            throw new KeyNotFoundException($"Task with id {id} was not found.");
        }

        await _taskRepository.DeleteAsync(modelToDelete);
    }
}