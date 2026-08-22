namespace TodoApp.Services.Models.Task;

public class TaskDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsFinished { get; set; }
    public DateTime DateOfCreation { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime Remind { get; set; }
}