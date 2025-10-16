namespace App;

public class Journal
{
    public string Title;

    public string Description;

    public string Publisher;

    public string Patient;
    public List<User> patientJournal = new List<User>();


    public Journal(string title, string description, string publisher, string patient)
    {
        Title = title;
        Description = description;
        Publisher = publisher;
        Patient = patient;
    }
    public static void ShowPatientJournals(string patientName, List<Journal> journals)
    {
        Console.WriteLine($"=== Journals for {patientName} ===");
        int i = 0;
        while (i < journals.Count)
        {
            if (journals[i].Patient != null && journals[i].Patient == patientName)
            {
                Console.WriteLine($"Title: {journals[i].Title} ");
                Console.WriteLine($"Description: {journals[i].Description}");
                Console.WriteLine("--------------------------");
            }
            i++;
        }
    }
}