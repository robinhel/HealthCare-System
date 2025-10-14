namespace App;

public class Event
{

    List<Event> events = new List<Event>();
    List<Event> participents = new List<Event>();


    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }


    public Event(string title, string description, string location, DateTime start, DateTime end)
    {
        Title = title;
        Description = description;
        Location = location;
        Start = start;
        End = end;
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