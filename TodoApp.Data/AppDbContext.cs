using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Entities;
using Task = TodoApp.Data.Entities.Task;

namespace TodoApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>()
            .HasKey(t => t.Id);
    }
}