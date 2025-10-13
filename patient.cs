using System.Security.Cryptography.X509Certificates;

namespace App;

public class Patient : User
{
    public string Role = "Patient";
    public Patient(string username, string password, bool isloggedin) : base(username, password, isloggedin)
    {

    }

}