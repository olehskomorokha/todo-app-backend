using Microsoft.AspNetCore.Mvc;
using TodoApp.Services.Interfaces;
using TodoApp.Services.Models.Task;

namespace TodoApp.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{pageId},{pageSize}")]

    public async Task<IActionResult> GetAllAsync(int pageId, int pageSize)
    {
        return Ok(await _taskService.GetAllAsync(pageId, pageSize));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _taskService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddTaskDto taskDto)
    {
        await _taskService.AddAsync(taskDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateTaskDto taskDto)
    {
        await _taskService.UpdateAsync(id, taskDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _taskService.DeleteAsync(id);
        return Ok();
    }
}