using System.Collections;
using System.Reflection.Metadata.Ecma335;
using App;


List<User> users = new List<User>(); // Lista för alla users
List<string> patients = new List<string>(); // Lista för patienter
List<Journal> journal = new List<Journal>(); //  // Lista för alla journaler
User activeUser = null;

SaveData.LoadUserDataCsv(users);

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
                    if(!loginSuccess)
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

        if (activeUser is Patient p)
        {
            Console.WriteLine($"Welcome {p.Username}");
        }

        if (activeUser is Admin a)
        {
            Console.WriteLine($"Welcome {a.Username}");
            System.Console.WriteLine("[1] Create personel account"); //NEW

            string AdminInput = Console.ReadLine();

            switch (AdminInput)
            {
               /*  case "1": SKAPA KONTO FÖR PERSONAL/DOCTOR
                    Console.WriteLine("Username?");
                    string PersonelUsername = Console.ReadLine();
                    Console.WriteLine("Password?");
                    string PersonelPassword = Console.ReadLine();
                    User newuser = new Doctor(PersonelUsername, PersonelPassword, false);
                    users.Add(newuser); // case 1 är ny, berätta för gruppen
                    break; */
            }

           // Ska kunna skapa konton för personal.

        }

        if (UserRole.Doctor)
        {
            Console.WriteLine($"Welcome {d.Username}");
            Console.WriteLine($"[1] Write journal for patient");


            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                
            }
            
        }


        Console.WriteLine($"Welcome {activeUser} to a terminal based HealthCare.");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        string input = Console.ReadLine();
        switch (input)
        {





        }






    }



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