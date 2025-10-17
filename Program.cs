using System.Collections;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using App;




List<User> users = new List<User>(); // Lista för alla users
//List<Patient> patients = new List<Patient>(); // Lista för patienter
List<Journal> journal = new List<Journal>(); //  // Lista för alla journaler
User activeUser = null;
List<Location> locations = new();
List<Assignment> assignments = new List<Assignment>();

users.Add(new User("p", "p", false, UserRole.Patient));

users.Add(new User("d", "d", false, UserRole.Doctor));

users.Add(new User("a", "a", false, UserRole.Admin));
Journal test = new Journal("Huvudvärk", "Kom in med huvudvärk", "Dr.Nicklas", "p");
journal.Add(test);


SaveData.LoadUserDataCsv(users);
LocationSaveData.LoadLocationDataCsv(locations);

User admin1 = new User("b", "b", false, UserRole.Admin);



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
        if (activeUser.Role == UserRole.Patient)
        {
            Console.WriteLine($"Welcome {activeUser.Username} to a terminal based HealthCare.");
            Console.WriteLine("[1] - Browse Journal"); // Nicklas
            Console.WriteLine("[2] - Request Event"); // Robin
            Console.WriteLine("[3] - Create Event"); // Robin
            Console.WriteLine("[4] - Show schedule"); // Robin
            Console.WriteLine("[q] - Quit"); // Nicklas
            
            // Request om att ändra lösenord (kanske)
            // Ska kunna se sin egen journal.
            // Ska kunna begära en tid (bokning).
            // Ska kunna se sitt schema (bokade tider).

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Write your name: ");
                    string username = Console.ReadLine().ToLower();
                    int index = 0;

                    foreach (Journal j in journal)
                    {
                        if (j.Patient == username)
                        {
                            Journal.ShowPatientJournals(username, journal);
                            System.Console.WriteLine();
                            Console.WriteLine($"[{index}], {j.Title}");
                        }
                        index++;

                    }
                    Console.WriteLine("Type the journal number to view the journal");
                    string number = Console.ReadLine();

                    if (int.TryParse(number, out int input))
                    {
                        if (journal[input].Patient == username)
                        {
                            Journal showJournal = journal[input];
                            Console.WriteLine($"---- {showJournal.Title} ----");
                            Console.WriteLine($"Description: {showJournal.Description} ");
                            Console.WriteLine($"Publisher: {showJournal.Publisher}");
                        }
                        else
                        {
                            System.Console.WriteLine("You dont have acess to this journal.");
                        }
                    }
                    Console.ReadLine();
                    // gör funktion för att visa användarens journaler
                    // eventuellt göra så att användaren kan välja ett event i journalen och kolla djupare på det
                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":
                // en funktion för att patienten ska kunna se sina tider med location detaljer och doctor namn
                    break;
                case "5":
                    break;
                case "q":
                    break;
            }
        }
        if (activeUser.Role == UserRole.Admin)
        {
            // ADMIN VV
            Console.WriteLine("[1] - Add Doctor"); // FILIPH
            Console.WriteLine("[2] - Edit Privileges"); // Calle
            Console.WriteLine("[3] - Show Privileges"); // Calle
            Console.WriteLine("[4] - Add Hospital"); // Ska kunna lägga till platser (sjukhus, vårdcentraler). Typ klar, filiph ska kolla på det
            Console.WriteLine("[5] - Remove Doctor"); // FILIPH KAN TESTA
            Console.WriteLine("[q] - Quit"); //  Nicklas  

            switch (Console.ReadLine())
                {
                case "1":
                    // gör en funktion för att admin ska kunna lägga till nya doctorer (sätta enum Doctor)
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
                    // en funktion för att kunna ta bort doctorer
                    break;
                case "q":
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

  
        if (activeUser.Role == UserRole.Doctor)
        {

        // DOCTOR VV
        Console.WriteLine("[1] - View patient journals"); // Nicklas
        Console.WriteLine("[2] - Write journals"); // FILIPH
        Console.WriteLine("[3] - Accept Requested Event");
        Console.WriteLine("[4]");
        Console.WriteLine("[5] - create/(edit??) journal entry"); // (Nicklas)
        Console.WriteLine("[6] - view location"); 
        Console.WriteLine("[0] - Settings"); // Calle kanske
        Console.WriteLine("[q] - Quit");


        string input = Console.ReadLine();
        switch (input)
        {
                case "1":
                // funktion för att visa alla journaler i systemet (historik)
                break;
                case "2":
                // funktion för att skriva journaler
                break;
                case "3":

                break;
                case "4":

                break;
                case "5":
                // funktion för att ändra gamla journaler
                break;
                case "6":
                    // funktion för att visa vilka sjukhus den activa doctorn är tillgänglig på
                    Console.WriteLine("view location you are available at");
                    if (activeUser.Role != UserRole.Doctor)
                    {
                        Console.WriteLine("du har inte behörigheten att se detta. endast personal kan se tillgängliga platser.");
                        Console.WriteLine("tryck enter för atergå");
                        Console.WriteLine();
                        break;
                    }
                    List<Location> myLocation = new List<Location>();
                    for (int i =0; i <assignments.Count; i++)
                    {
                        if (assignments[i].UserId == activeUser.Id)
                        {
                            myLocation.Add(assignments[i].Loc);
                        }
                    }
                break;
                case "q":
                activeUser.IsLoggedIn = false;
                activeUser = null;
                break;

                    Location.ShowAllLocations(locations);
                    // funktion för att visa vilka sjukhus den activa doctorn är tillgänglig på
                    break;
                case "7":
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