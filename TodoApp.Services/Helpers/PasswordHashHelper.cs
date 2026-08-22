using TodoApp.Services.Exceptions;

namespace TodoApp.Services.Helpers;

public static class PasswordHashHelper
{
    public static string HashPassword(string password)
    {
        try
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }
        catch (Exception)
        {
            throw new PasswordException("failed_to_hash", "Failed to hash client password.");
        }
    }

    public static bool VarifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}