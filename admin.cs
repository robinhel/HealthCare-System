namespace App;

public class Admin : User
{
    public string Role = "Admin";
    public Admin(string username, string password, bool isloggedin) : base(username, password, isloggedin)
    {

    }
}