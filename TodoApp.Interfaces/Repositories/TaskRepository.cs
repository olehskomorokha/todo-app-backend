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

    public async Task<TaskToDo> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<List<TaskToDo>> GetAllAsync(int items, int page)
    {
        return await _context.Tasks.Skip((page - 1) * items).Take(items).ToListAsync();
    }

    public async Task AddAsync(TaskToDo model)
    {
        await _context.Tasks.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskToDo model)
    {
        _context.Tasks.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskToDo model)
    {
        _context.Tasks.Remove(model);
        await _context.SaveChangesAsync();
    }
}