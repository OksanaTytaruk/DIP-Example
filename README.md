# DIP Example (Dependency Inversion Principle)

Цей репозиторій містить приклад принципу інверсії залежностей з SOLID.

## Принцип інверсії залежностей (DIP)

Високорівневі модулі не повинні залежати від низькорівневих модулів. І ті, й інші повинні залежати від абстракцій. Абстракції не повинні залежати від деталей, але деталі мають залежати від абстракцій.

### Приклад коду:

```csharp
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
