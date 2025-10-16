using System.Security.Cryptography.X509Certificates;

namespace App;

public class User
{
    private static int IdCount = 0;
    public int Id;
    public string Username;
    public string Password;
    public bool IsLoggedIn;
    public UserRole Role;
    public Permissions permissions;

    public User(string username, string password, bool isloggedin, UserRole role)
    {
        Id = IdCount++;
        Username = username;
        Password = password;
        IsLoggedIn = isloggedin;
        Role = role;
        permissions = new Permissions();
    }
    public void ShowUser(User activeuser)
    {
        Console.WriteLine($"{activeuser.Username} ID: {activeuser.Id}");
    }
    public bool TryLogin(string username, string password)
    {
        if (username == Username && password == Password)
        {
            IsLoggedIn = true;
            return true;
        }
        else
        {
            IsLoggedIn = false;
            return false;
        }
    }
    public string SaveUserCsv(User activeuser)
    {
        return $"{activeuser.Username},{activeuser.Password},{activeuser.Id},{activeuser.Role},{activeuser.IsLoggedIn}";
    }
}
