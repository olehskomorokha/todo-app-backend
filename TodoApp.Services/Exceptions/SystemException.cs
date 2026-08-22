namespace TodoApp.Services.Exceptions;

public class SystemException : Exception
{
    public string Code { get; }
    
    public SystemException(string code, string message)
        : base(message)
    {
        Code = code;
    }
    
}