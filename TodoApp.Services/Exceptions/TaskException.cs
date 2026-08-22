namespace TodoApp.Services.Exceptions;

public class TaskException : SystemException
{
    public TaskException(string code, string message) : base(code, message)
    {
    }
}