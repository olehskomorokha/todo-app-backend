namespace TodoApp.Services.Exceptions;

public class PasswordException : SystemException
{
    public PasswordException(string code, string message)
        : base(code, message)
    {
    }
}