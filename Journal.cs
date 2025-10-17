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

    public void Info()
    {
        System.Console.WriteLine($"Doctor: {Publisher}");
        Console.WriteLine($"Title: {Title}");
        System.Console.WriteLine($"Patient: {Patient}");
        System.Console.WriteLine("--------------------");
        System.Console.WriteLine($"Description: {Description}");
    }
    public void ChangeTitle()
    {
        System.Console.WriteLine($"------  Changing title of journal entry [{Title}]  ------");
        Title = null;
        System.Console.WriteLine("Enter the new title");
        string ChangedTitle = Console.ReadLine();
        Title = ChangedTitle;
    }
    public void ChangeDesc()
    {
        System.Console.WriteLine($"------  Changing description of journal entry [{Title}]  ------");
        Description = null;
        System.Console.WriteLine("Enter the new description");
        string ChangedDesc = Console.ReadLine();
        Description = ChangedDesc;
    }
    public void ShowPatientJournals(string patientName, List<Journal> journals)
    {
        Console.WriteLine($"=== Journals for {patientName} ===");
        System.Console.WriteLine();
        int i = 0;
        while (i < journals.Count)
        {
            if (journals[i].Patient != null && journals[i].Patient.ToLower() == patientName)
            {
                //Console.WriteLine("--- Journal history ---");
                Console.WriteLine($"Name: {patientName}");
                Console.WriteLine($"Title: {journals[i].Title} ");
                //Console.WriteLine($"Description: {journals[i].Description}");
                Console.WriteLine("------------------------");
            }
            i++;
        }
    }
}