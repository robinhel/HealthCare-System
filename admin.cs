namespace App;

public class Admin : User
{
    public string Role = "Admin";
    public Admin(string username, string password, bool isloggedin) : base(username, password, isloggedin)
    {

    }
}

/* Event 

List<Participent>
Datetime Start
Datetime end
string description
string title
(List<documents>)
location location
EventType Type

-- Participent --
User user
Enum role role 

-- User --

-- Location -- 

*/