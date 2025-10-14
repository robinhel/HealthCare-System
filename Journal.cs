namespace App;

public class Journal
{
    public string Title;

    public string Description;

    public string Publisher;

    public string Patient;
    public List<Patient> patientJournal = new List<Patient>();


    public Journal(string title, string description, string publisher, string patient)
    {
        Title = title;
        Description = description;
        Publisher = publisher;
        Patient = patient;
    }

}