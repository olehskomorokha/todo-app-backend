namespace TodoApp.Services.Models.Task;

public class AddTaskDto
{
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime Remind { get; set; }
}