namespace App;

public class Patient : IUser
{
    public string Username;
    public string Password;
    public bool IsLoggedIn;

    public Patient(string username, string password, bool isloggedin)
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
