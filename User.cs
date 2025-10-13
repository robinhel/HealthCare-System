using System.Security.Cryptography.X509Certificates;

namespace App;

public class User
{
    private int IdCount = 0;
    public int Id;
    public string Username;
    public string Password;
    public bool IsLoggedIn;

    public User(string username, string password, bool isloggedin)
    {
        Id = IdCount++;
        Username = username;
        Password = password;
        IsLoggedIn = isloggedin;

    }
    public static void ShowUser(User Username, User Id)
    {
        Console.WriteLine($"{Username} ID: {Id}");
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
}
