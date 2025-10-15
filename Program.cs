using System.Collections;
using System.Reflection.Metadata.Ecma335;
using App;


List<User> users = new List<User>(); // Lista för alla users
//List<Patient> patients = new List<Patient>(); // Lista för patienter
List<Journal> journal = new List<Journal>(); //  // Lista för alla journaler
User activeUser = null;
List<Location> locations = new();

users.Add(new User("a", "a", false));

SaveData.LoadUserDataCsv(users);
LocationSaveData.LoadLocationDataCsv(locations);

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

                bool isloggedin = false;

                User newUser = new User(C_username, C_password, isloggedin);
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

        Console.WriteLine($"Welcome {activeUser.Username} to a terminal based HealthCare.");
        Console.WriteLine("[1]");
        Console.WriteLine("[2]");
        Console.WriteLine("[3]");
        Console.WriteLine("[4]");
        Console.WriteLine("[5]");
        Console.WriteLine("[6]");
        Console.WriteLine("[7]");
        Console.WriteLine("[8]");
        Console.WriteLine("[9]");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                break;
            case "5":
                break;
            case "6":
                break;
            case "q":
                activeUser.IsLoggedIn = false;
                activeUser = null;
                break;

        }
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