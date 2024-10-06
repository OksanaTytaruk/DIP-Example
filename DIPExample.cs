// High-level module
public class PasswordManager
{
    private readonly IPasswordHasher _passwordHasher;

    public PasswordManager(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public void SavePassword(string password)
    {
        var hashedPassword = _passwordHasher.Hash(password);
        Console.WriteLine("Password saved: " + hashedPassword);
    }
}

// Abstraction (Interface)
public interface IPasswordHasher
{
    string Hash(string password);
}

// Low-level module
public class SHA256PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return "SHA256_" + password;  // Simplified for demonstration
    }
}

// Usage
var passwordHasher = new SHA256PasswordHasher();
var passwordManager = new PasswordManager(passwordHasher);
passwordManager.SavePassword("my_secure_password");
