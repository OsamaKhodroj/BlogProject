
namespace Tools.Helpers;
public class Cryptography
{
    public static string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("Password Paramter is required");
        }
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        return passwordHash;
    }
}
