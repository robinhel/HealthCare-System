
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using App;


// Global lista med users, innehåller alla roller.
List<User> users = new List<User>(); // Lista för alla users
//List<Patient> patients = new List<Patient>(); // Lista för patienter
List<Journal> journals = new List<Journal>(); //  // Lista för alla journaler
User activeUser = null;
List<Location> locations = new();
Permissions permission = null;



// Skapa ett globalt bokningssystem
BookingSystem bookingSystem = new BookingSystem();
DateTime now = DateTime.Now;


users.Add(new User("a", "a", false, UserRole.Admin));
Journal test = new Journal("Huvudvärk", "Kom in med huvudvärk", "Dr.Nicklas", "p-1");
journals.Add(test);


// Skapa 3st users med roller, patient, doctor, admin
users.Add(new User("p-1", "a", false, UserRole.Patient));
users.Add(new User("p-2", "a", false, UserRole.Patient));
users.Add(new User("p-3", "a", false, UserRole.Patient));
users.Add(new User("d-1", "a", false, UserRole.Doctor));
users.Add(new User("d-2", "a", false, UserRole.Doctor));
users.Add(new User("a-1", "a", false, UserRole.Admin));


// SaveData.LoadUserDataCsv(users);
// LocationSaveData.LoadLocationDataCsv(locations);

bool Running = true;

while (Running)
{
    if (activeUser == null)  // ------------------------LOGIN MENU----------------------
    {
        Console.WriteLine("-=Welcome to the Healcare system=-");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Create account");
        Console.WriteLine("3. Exit system");
        string Login_input = Console.ReadLine();
        switch (Login_input)
        {
            case "1":               //------------------------LOGIN----------------------
                Console.Write("Enter username: ");
                string L_username = Console.ReadLine();
                Console.Write("Enter password: ");
                string L_password = Console.ReadLine();
                bool loginSuccess = false;
                foreach (User user in users)
                {

                    if (user.TryLogin(L_username, L_password))
                    {
                        activeUser = user;
                        permission = new Permissions();
                        Console.WriteLine("Login Succesfull!");
                        loginSuccess = true;
                        break;
                    }
                }
                if (!loginSuccess)
                {
                    Console.WriteLine("Invalid input, try again ");
                }
                break;

            case "2":               //---------------------CREATE ACCOUNT------------------
                Console.Write("Enter username: ");
                string C_username = Console.ReadLine();
                Console.Write("Enter password: ");
                string C_password = Console.ReadLine();

                permission = new Permissions();
                bool isloggedin = false;


                User newUser = new User(C_username, C_password, isloggedin, UserRole.Patient);
                permission.SetPatientPermissions(newUser);
                users.Add(newUser);
                SaveData.SaveUserDataCsv(newUser);
                Console.WriteLine($"Account: {C_username} has been created.");
                break;

            case "3":               //------------------------EXIT-----------------------
                Console.WriteLine("Exiting System!");
                Running = false;
                break;
                // ------------------- >> LOGGA IN & SKAPA KONTO KLART << ----------------------- \\
        }

    }
    //-------------------------------------LOGGED IN MENU----------------------------------------
    else
    {
        // --- FUNKTIONER -- 
        // - Event ()
        // - User (Användarna)
        // - Location (Var eventet kommer äga rum)
        // - Participant (Visa vilken roll som är med i eventet )
        // - Journal (Skriva journaler och visa journaler)
        // - UserRoles (Tilldela roller)
        if (activeUser != null && activeUser.Role == UserRole.Patient)
        {
            try { Console.Clear(); } catch { }
            Console.WriteLine($"Welcome {activeUser.Username} to a terminal based HealthCare.");

            Console.WriteLine("[1] - Browse Journal"); // Nicklas kanske klar? ingen aning? hoppas det?
            Console.WriteLine("[2] - Request Event"); // Robin
            Console.WriteLine("[3] - Create Event"); // Robin
            Console.WriteLine("[4] - Show schedule"); // Robin
            Console.WriteLine("[q] - Quit"); // Nicklas klar

            // Request om att ändra lösenord (kanske)
            // Ska kunna se sin egen journal.
            // Ska kunna begära en tid (bokning).
            // Ska kunna se sitt schema (bokade tider).

            switch (Console.ReadLine())
            {
                case "1":
                    try
                    {
                        if (journals.Count == 0)
                        {
                            System.Console.WriteLine("No journals to show, try again later! ");
                        }
                        else
                        {
                            Console.WriteLine("Write your name: ");
                            string username = Console.ReadLine().ToLower();
                            int index = 0;
                            try{ Console.Clear(); } catch{} 
                            foreach (Journal j in journals)
                            {
                                if (j.Patient == username)
                                {
                                    j.ShowPatientJournals(username, journals);

                                    System.Console.WriteLine();
                                    Console.WriteLine($"[{index}]. {j.Title}");
                                }
                                index++;
                            }
                            Console.WriteLine("Type the journal number to view the journal");
                            string number = Console.ReadLine();

                            if (int.TryParse(number, out int input))
                            {
                                if (journals[input].Patient == username)
                                {
                                    try{ Console.Clear(); } catch{}
                                    Journal showJournal = journals[input];
                                    Console.WriteLine($"---- {showJournal.Title} ----");
                                    Console.WriteLine($"Description: {showJournal.Description} ");
                                    Console.WriteLine($"Publisher: {showJournal.Publisher}");
                                    System.Console.WriteLine();
                                    System.Console.WriteLine("press ENTER to continue.. ");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    System.Console.WriteLine("You dont have acess to this journal.");
                                }
                            }
                            Console.ReadLine();
                            
                        }
                        // gör funktion för att visa användarens journaler
                    }
                    catch
                    {
                        System.Console.WriteLine("Wrong input ");
                    }
                    // eventuellt göra så att användaren kan välja ett event i journalen och kolla djupare på det
                    break;
                case "2":
                        //booking.ShowAvailableTimes();

                        break;
                    case "3":

                        break;
                    case "4":
                        // en funktion för att patienten ska kunna se sina tider med location detaljer och doctor namn
                        break;
                    case "5":
                        break;
                    case "q":
                        activeUser.IsLoggedIn = false;
                        permission = null;
                        activeUser = null;
                        break;
                    }
                    }
        if (activeUser != null && activeUser.Role == UserRole.Admin)
        {
            // ADMIN VV
            try { Console.Clear(); } catch { }
            Console.WriteLine("[1] - Add Doctor"); // FILIPH
            Console.WriteLine("[2] - Edit Privileges"); // Calle Jobbar på det
            Console.WriteLine("[3] - Show Privileges"); // Calle Klar !!
            Console.WriteLine("[4] - Add Hospital"); // Ska kunna lägga till platser (sjukhus, vårdcentraler). Typ klar, filiph ska kolla på det
            Console.WriteLine("[5] - Remove Doctor"); // FILIPH KAN TESTA
            Console.WriteLine("[q] - Quit"); //  Nicklas  

            switch (Console.ReadLine())
            {
                case "1":
                    // gör en funktion för att admin ska kunna lägga till nya doctorer (sätta enum Doctor)
                    AddDoctor(users);
                    break;
                case "2":
                    permission?.EditUserPermissionById(users);
                    // gör en klass för olika privliges med hjälp av Bools, försöker göra så att admin kan toggla true or false på individuella användare
                    break;
                case "3":
                    activeUser.permissions?.ShowAllPermission();
                    // funktion för att visa privileges på alla olika typer av användare (admin,patient,doctor)
                    break;
                case "4":
                    // funktion för admin att lägga till tillgängliga sjukhus i listan av sjukhus  
                    LocationAdd(locations);
                    break;
                case "5":
                    RemoveDoctor(users);
                    // en funktion för att kunna ta bort doctorer
                    break;
                case "q":
                    activeUser.IsLoggedIn = false;
                    permission = null;
                    activeUser = null;

                    break;
            }
        }
        // PATIENT VV



        // Ska kunna hantera rättigheter för andra användare.
        // Ska kunna skapa konton för personal.
        // Ska kunna godkänna eller avslå patientregistreringar.
        // Ska kunna godkänna eller avslå patientregistreringar.
        // Ska kunna se vem som har vilka behörigheter.
        // Systemet ska vara uppbyggt så att varje användare bara har tillgång till det som deras roll behöver.
        // Ska kunna tilldela roller (t.ex. personal, lokal admin).



        if (activeUser != null && activeUser.Role == UserRole.Doctor)
        {

            // DOCTOR VV
            try { Console.Clear(); } catch { }
            Console.WriteLine("[1] - View patient journals"); // Nicklas
            Console.WriteLine("[2] - Write journals"); // FILIPH
            Console.WriteLine("[3] - Accept Requested Event");
            Console.WriteLine("[4] - edit journal entry"); // (filiph)
            Console.WriteLine("[5] - view location"); // Klar !!
            Console.WriteLine("[6] - Show priviliges"); // Klar !!
            Console.WriteLine("[0] - Settings"); // Calle kanske
            Console.WriteLine("[q] - Quit");


            string input = Console.ReadLine();
            switch (input)
            {
                case "1":

                    try
                    {
                        ShowAllJournals(journals);
                        Console.WriteLine();
                        System.Console.WriteLine("Enter the number of the journal you want to view: ");
                        int patientChoose = Convert.ToInt32(Console.ReadLine());
                        Journal selected_journal = journals[patientChoose - 1];
                        try { Console.Clear(); } catch { };
                        selected_journal.Info();

                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                    }
                    catch
                    {
                        System.Console.WriteLine("Wrong input");
                    }



                    // funktion för att visa alla journaler i systemet (historik)
                    break;
                case "2":
                    CreateJournal(journals, users, activeUser);

                    // funktion för att skriva journaler
                    break;
                case "3":

                    break;
             
                case "4":

                    EditJournal(journals, users);
                    // funktion för att ändra gamla journaler
                    break;
                case "5":
                    // Location.ShowAllLocations(locations); // funkar ej
                    // funktion för att visa vilka sjukhus den activa doctorn är tillgänglig på
                    break;
                case "6":
                    activeUser.permissions?.ShowAllPermission();
                    break;
                case "q":
                    activeUser.IsLoggedIn = false;
                    permission = null;
                    activeUser = null;
                    break;
            }
        }
        // Ska kunna se patientjournaler. ---
        // Ska kunna skriva en patientjournal. ---
        // Ska kunna markera journaler med olika läsbehörigheter.
        // Ska kunna registrera och ändra tider.
        // Ska kunna godkänna eller avslå tidsförfrågningar.
        // Ska kunna se schema för en plats (t.ex. vårdcentral).


    }
}

static void LocationAdd(List<Location> locations) // Denna funktionen kallas på för att lägga till en address.
{
    // ta in input
    System.Console.WriteLine("Name?");
    string LocationName = Console.ReadLine();
    System.Console.WriteLine("Address?");
    string LocationAddress = Console.ReadLine();
    System.Console.WriteLine("Description?");
    string LocationDescription = Console.ReadLine();
    Location newloc = new Location(LocationName, LocationAddress, LocationDescription);
    locations.Add(newloc);

    LocationSaveData.SaveLocationDataCsv(newloc);
    System.Console.WriteLine("Location saved and added.");
    Console.ReadLine();
    // Behövs lägga till filsystem i location.
}







static void AddDoctor(List<User> users)
{
    System.Console.WriteLine("");
    System.Console.WriteLine("----------   CREATE A NEW DOCTOR ACCOUNT   ----------");
    System.Console.WriteLine("\n   Enter username: ");
    string AdminUsername = Console.ReadLine();
    System.Console.WriteLine("\n   Enter password: ");
    string AdminPassword = Console.ReadLine();
    Console.WriteLine("\n \n   New account succesfully created! \n");
    System.Console.WriteLine("-----------------------------------------------------------------");



    User newAdmin = new User(AdminUsername, AdminPassword, false, UserRole.Doctor);
    users.Add(newAdmin);
}





static void RemoveDoctor(List<User> users)
{
    System.Console.WriteLine("----------   REMOVE A DOCTOR ACCOUNT   ----------");
    User? deletedUser = null;

    foreach (User user in users)
    {
        if (user.Role == UserRole.Doctor)
        {
            System.Console.WriteLine($"     [ID - {user.Id}    USERNAME - {user.Username}] ");

        }
    }
    System.Console.WriteLine("Enter ID of doctor which you wish to remove: ");
    int idRemove = Convert.ToInt32(Console.ReadLine());

    foreach (User user in users)
    {
        if (idRemove == user.Id && user.Role == UserRole.Doctor)
        {
            deletedUser = user;
            break;
        }
    }
    if (deletedUser != null)
    {
        users.Remove(deletedUser);
        System.Console.WriteLine($"Succesfully deleted {deletedUser.Username} with ID: {deletedUser.Id}");
    }
    else
    {
        System.Console.WriteLine($"User with that ID not found.");
    }

}



static void CreateJournal(List<Journal> journals, List<User> users, User activeUser)
{
    try { Console.Clear(); } catch { }
    bool DoctorFound = false;
    System.Console.WriteLine("----------   CREATE JOURNAL FOR PATIENT   ----------");
    foreach (User user in users)
    {
        if (user.Role == UserRole.Doctor) ;
        DoctorFound = true;
    }
    if (DoctorFound)
    {
        try { Console.Clear(); } catch { }
        ;
        Console.WriteLine("----------   ENTER ID OF USER YOU'D LIKE TO CREATE JOURNAL FOR   ----------");
        foreach (User user in users)
        {
            if (user.Role == UserRole.Patient)
            {
                System.Console.WriteLine($"     [ID - {user.Id}    USERNAME - {user.Username}] ");
            }
        }
        int EnteredID = Convert.ToInt32(Console.ReadLine());
        bool userFound = false;
        foreach (User user in users)
        {
            try { Console.Clear(); } catch { }
            ;
            if (EnteredID == user.Id)
            {
                Console.WriteLine($"----------   Creating a journal copy for {user.Username}    ----------");
                System.Console.WriteLine("Enter title of new journal");
                string TitleJournal = Console.ReadLine();
                System.Console.WriteLine("Enter descrition of new journal");
                string DescJournal = Console.ReadLine();

                Journal newJournal = new Journal(TitleJournal, DescJournal, activeUser.Username, user.Username);
                journals.Add(newJournal);
                System.Console.WriteLine($"Journal for {user.Username} succesfully created.");
                Console.ReadLine();
                userFound = true;
                DoctorFound = false;
            }
            if (!userFound)
            {
                System.Console.WriteLine($"User with [ID {EnteredID}] not found.");
                Console.ReadLine();
                break;
            }


            /*  public string Title;

             public string Description;

             public string Publisher;

             public string Patient; */
        }

    }
    else
    {
        System.Console.WriteLine("You don't have the right permissions to access this. ");
    }


}




//             Console.WriteLine("[5] - create/(edit??) journal entry"); // (Filiph)

static void EditJournal(List<Journal> journals, List<User> users)
{
    if (journals.Count >= 1)
    {
        System.Console.WriteLine("----------   EDIT JOURNAL ENTRY   ----------");

        foreach (User user in users)
        {
            if (user.Role == UserRole.Patient)
            {
                System.Console.WriteLine($"[ID {user.Id}] ---- Username - {user.Username}");
            }
        }
        System.Console.WriteLine("Enter the ID of the user you'd like to change journal entry: ");
        int ID_input = Convert.ToInt32(Console.ReadLine());
        foreach (User user in users)
        {
            if (ID_input == user.Id)
            {
                System.Console.WriteLine("---- USER FOUND ----");
                System.Console.WriteLine("\n \n-- JOURNAL TITLES --");
                for (int i = 0; i < journals.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + journals[i].Title);
                }
            }
        }
        System.Console.WriteLine("Enter INDEX of the journal you'd like to change");
        int journal_change = Convert.ToInt32(Console.ReadLine());
        Journal chosenIndex = journals[journal_change - 1];
        chosenIndex.Info();
        bool changeJournal = true;
        while (changeJournal)
        {
            System.Console.WriteLine("What would you like to change? Title/Description");
            string inputChange = Console.ReadLine().ToLower();
            if (inputChange.ToLower() == "title")
            {
                chosenIndex.ChangeTitle();
            }
            if (inputChange.ToLower() == "description")
            {
                chosenIndex.ChangeDesc();
            }

            System.Console.WriteLine("\n \n \nWrite DONE to leave, press ENTER to change more ");
            string userLeave = Console.ReadLine().ToLower();
            if (userLeave.ToLower() == "done")
            {
                changeJournal = false;
            }
        }
    }
    else
    {
        System.Console.WriteLine("There is no journals saved in the system.");
    }
}

static void ShowAllJournals(List<Journal> journals)
{
    try { Console.Clear(); } catch { }
    System.Console.WriteLine("==== ALL JOURNALS IN THE SYSTEM ====");
    System.Console.WriteLine();
    if (journals.Count == 0)
    {
        System.Console.WriteLine("No journals found. ");
    }
    else
    {
        for (int i = 0; i < journals.Count; i++) 
        {
            Journal j = journals[i];
            Console.WriteLine($"[{i + 1}] ");
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Publisher: {j.Publisher}");
            Console.WriteLine($"Name: {j.Patient}");
            Console.WriteLine($"Title: {j.Title}");
            Console.WriteLine("-----------------------");

        }
    }
}



// 
/*


TODO:

1. Patient

Ska kunna registrera sig och logga in. !!
Ska kunna se sin egen journal.
Ska kunna begära en tid (bokning).
Ska kunna se sitt schema (bokade tider).

2. Personal (vårdpersonal)

Ska kunna se patientjournaler. ---
Ska kunna skriva en patientjournal. ---
Ska kunna markera journaler med olika läsbehörigheter.
Ska kunna registrera och ändra tider.
Ska kunna godkänna eller avslå tidsförfrågningar.
Ska kunna se schema för en plats (t.ex. vårdcentral).

3. Administratör (admin)

Ska kunna hantera rättigheter för andra användare.
Ska kunna tilldela roller (t.ex. personal, lokal admin).
Ska kunna skapa konton för personal.
Ska kunna lägga till platser (sjukhus, vårdcentraler).
Ska kunna godkänna eller avslå patientregistreringar.
Ska kunna se vem som har vilka behörigheter.
Systemet ska vara uppbyggt så att varje användare bara har tillgång till det som deras roll behöver.


*/
