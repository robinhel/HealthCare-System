namespace App;

public class Doctor : IUser
{
    public string Username;
    public string Password;
    public bool IsLoggedIn;

    public Doctor(string username, string password, bool isloggedin)
    {
        Username = username;
        Password = password;

        IsLoggedIn = isloggedin;
    }
    public bool TryLogin(string username, string password)
    {
        if (username == Username && password == Password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

