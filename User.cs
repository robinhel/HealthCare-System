namespace App;

public class User
{
    public string Username;
    public string Password;
    public bool IsLoggedIn;

    public User(string username, string password, bool isloggedin)
    {
        Username = username;
        Password = password;
        IsLoggedIn = isloggedin;
    }
}