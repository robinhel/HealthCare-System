namespace App;

public class Doctor : User
{
    public string Role = "Doctor";
    public Doctor(string username, string password, bool isloggedin) : base(username, password, isloggedin)
    {

    }
}