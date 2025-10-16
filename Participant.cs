namespace App;

class Participant
{
    public string Name; // 
    public EventRole EventRole;

    public Participant(string name, EventRole eventRole) // Förväntas att få tillbaka två parametrar
    {
        Name = name;    // göra det tydligt vilken som e klass och vilken som är klassens fält och parametrar
        EventRole = eventRole;
    }

    public void ShowUser()
    {
        Console.WriteLine($"Hello {Name}, your role is {EventRole}");
    }
    /*public void Access()
    {
        if (EventRole == EventRole.Doctor)
        {
            Console.WriteLine("--- You have access to these things as a doctor ---");
            Console.WriteLine("[1] View patient journal\n[2] Schedule appointments\n [3] Change appointments\n [4] Accept appointments ");
        }
        if(EventRole == EventRole.Patient)
        {
            Console.WriteLine("--- As a patient ---");
            Console.WriteLine("[1] View journal\n [2] Request an appointment");
        }
    }
    */

}
public enum EventRole
{
    Doctor,
    Patient,
}

//Participant p1 = new Participant("Nicklas", EventRole.Doctor);
// Participant p2 = new Participant("Erik", EventRole.Doctor);


/*
case "1":
System.Console.WriteLine("Enter patient name: "); // Frågar patient namn
string patientName = Console.ReadLine(); // Sparar namnet i patientName

System.Console.WriteLine("Enter journal text: "); // Här skriver doktorn journal texten
string journalText = Console.ReadLine(); // Sparar journalen i journalText

Participant patientParticipant = new Participant(patientName, Participant.EventRole.Patient);
Journal newJorunal = new Journal(patientParticipant); // Gör en ny journal till patient
newJournal.AddParticipant(patientParticipant);
newJournal.AddParticipant(newParticipant(d.Username, Participant.EventRole.Doctor));

journal.Add(newJournal);
System.Console.WriteLine("Journal saved. ");
break;

// ------------ SKRIVA JOURNAL --------------- //
*/ 