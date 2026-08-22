using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Data.Entities;
using TodoApp.Interfaces.Interfaces;

namespace TodoApp.Interfaces.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<TaskToDo>> GetAllAsync()
    {
        return _context.Tasks.ToListAsync();
    }

    public async Task<TaskToDo> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<List<TaskToDo>> GetByPageAsync(int page, int itemsCount)
    {
        return await _context.Tasks.Skip((page - 1) * itemsCount).Take(itemsCount).ToListAsync();
    }

    public async Task AddAsync(TaskToDo task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskToDo task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskToDo task)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}