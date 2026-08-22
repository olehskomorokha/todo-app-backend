namespace TodoApp.Data.Entities;

public class TaskToDo
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsFinished { get; set; }
    public DateTime DateOfCreation { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime Remind { get; set; }
    public Category Category { get; set; }
    public User User { get; set; }
}