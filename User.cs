using System.Security.Cryptography.X509Certificates;

namespace App;

public class User
{
    private static int IdCount = 0;
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
    public static void ShowUser(User activeuser)
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
    public static void SaveString(User Username, User Password, User Id, User Role)
    {
        string[] Userdata = new string[] { $"{Username},{Password},{Id},{Role}" };
    }
}
