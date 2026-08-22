using TodoApp.Data.Entities;
using TodoApp.Services.Models.Task;

namespace TodoApp.Services.Mappers;

public static class TaskMapper
{
    public static TaskDto MapToTaskDto(TaskToDo model)
    {
        return new TaskDto()
        {
            Id = model.Id,
            CategoryId = model.CategoryId,
            Name = model.Name,
            Description = model.Description,
            Deadline = model.Deadline,
            IsFinished = model.IsFinished,
            DateOfCreation = model.DateOfCreation,
            Remind = model.Remind
        };
    }

    public static TaskToDo MapToAddTask(AddTaskDto model)
    {
        return new TaskToDo()
        {
            CategoryId = model.CategoryId,
            UserId = model.UserId,
            Name = model.Name,
            Description = model.Description,
            Deadline = model.Deadline,
            Remind = model.Remind,
            DateOfCreation = DateTime.Now,
            IsFinished = false,
        };
    }
}