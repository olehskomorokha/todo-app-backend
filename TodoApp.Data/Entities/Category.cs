namespace TodoApp.Data.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<TaskToDo> Tasks { get; set; }
}