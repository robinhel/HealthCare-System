namespace App;

class Participant
{
    public string name;
    public EventRole eventRole;

    public Participant(string name, EventRole eventRole)
    {
        this.name = name;    // göra det tydligt vilken som e klass och vilken som är klassens fält och parametrar
        this.eventRole = eventRole;
    }
    
    public void ShowUser()
    {
        Console.WriteLine($"Hello {name}, your role is {eventRole}");
    }
}
public enum EventRole
{
    Doctor,
    Patient,
}

//Participant p1 = new Participant("Nicklas", EventRole.Doctor);
// Participant p2 = new Participant("Erik", EventRole.Doctor);
