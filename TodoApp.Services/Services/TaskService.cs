using TodoApp.Interfaces.Interfaces;
using TodoApp.Services.Interfaces;
using TodoApp.Services.Mappers;
using TodoApp.Services.Models.Task;

namespace TodoApp.Services.Services;

public class TaskService : ITaskService
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

    public async Task AddAsync(AddTaskDto taskDto)
    {
        if (taskDto == null)
        {
            throw new ArgumentNullException(nameof(taskDto));
        }

        await _taskRepository.AddAsync(TaskMapper.MapToAddTask(taskDto));
    }

    public async Task UpdateAsync(int id, UpdateTaskDto taskDto)
    {
        var modelToUpdate = await _taskRepository.GetByIdAsync(id);
        if (modelToUpdate == null)
        {
            throw new KeyNotFoundException($"Task with id {id} was not found.");
        }

        if (taskDto.Deadline != null)
        {
            modelToUpdate.Deadline = taskDto.Deadline.Value;
        }

        if (taskDto.Remind != null)
        {
            modelToUpdate.Remind = taskDto.Remind.Value;
        }

        if (taskDto.IsFinished != null)
        {
            modelToUpdate.IsFinished = taskDto.IsFinished.Value;
        }

        if (taskDto.Description != null)
        {
            modelToUpdate.Description = taskDto.Description;
        }

        if (taskDto.Name != null)
        {
            modelToUpdate.Name = taskDto.Name;
        }

        if (taskDto.CategoryId != null)
        {
            modelToUpdate.CategoryId = taskDto.CategoryId.Value;
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