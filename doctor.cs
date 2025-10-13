namespace App;

public class Doctor : User
{
    public string Role = "Doctor";
    public Doctor(string username, string password, bool isloggedin) : base(username, password, isloggedin)
    {

    }
    public void ShowPatientJournals(string patientName, List<Journal> journals)
    {
        Console.WriteLine($"=== Journals for {patientName} ===");
        int i = 0;
        while(i < journals.Count)
        {
            //if (journals[i].Patient != null && journals[i].Patient.Username == patientName)
            {
                Console.WriteLine($"Title: {journals[i].Title} ");
                Console.WriteLine($"Description: {journals[i].Description }");
                Console.WriteLine("--------------------------");
            }
        }
    }
    

}

// P A T I E N T
// Ska kunna se patientjournaler.
//Ska kunna skriva en patientjournal.