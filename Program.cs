using System.Reflection.Metadata.Ecma335;
using App;


List<User> users = new List<User>();
User activeUser = null;

bool Running = true;

while (Running)
{
    if (activeUser == null)
    {
        Console.WriteLine("-=Welcome to the Healcare system=-");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Create account");
        Console.WriteLine("3. Exit system");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.Write("Enter username: ");
                string L_username = Console.ReadLine();
                Console.Write("Enter password: ");
                string L_password = Console.ReadLine();
                break;

            case "2":
                Console.Write("Enter username: ");
                string C_username = Console.ReadLine();
                Console.Write("Enter password: ");
                string C_password = Console.ReadLine();
                break;

            case "3":
                Console.WriteLine("Exiting System!");
                Running = false;
                break;
        }

    }

}