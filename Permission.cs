namespace App;

public class Permissions
{
    public bool ViewPatient = false;
    public bool EditPatient = false;
    public bool AddDoctor = false;
    public bool GiveMed = false;
    public bool ManageUsers = false;
    public bool CreateEvent = false;
    public bool ShowPermissions = false;


    public Permissions(User activeUser)
    {
        if (activeUser.Role == UserRole.Patient)
        {
            ViewPatient = true;
        }
        if (activeUser.Role == UserRole.Doctor)
        {
            ViewPatient = true;
            EditPatient = true;
            GiveMed = true;
            ShowPermissions = true;
        }
        if (activeUser.Role == UserRole.Admin)
        {
            ViewPatient = true;
            EditPatient = true;
            AddDoctor = true;
            ManageUsers = true;
            GiveMed = true;
            CreateEvent = true;
            ShowPermissions = true;
        }
    }
    public void ShowAllPermission(User activeUser)
    {
        Console.WriteLine("All active permissions\n");
        Console.WriteLine($"[1] - ViewPatient: {ViewPatient}");
        Console.WriteLine($"[2] - EditPatient: {EditPatient}");
        Console.WriteLine($"[3] - AddDoctor: {AddDoctor}");
        Console.WriteLine($"[4] - GiveMed: {GiveMed}");
        Console.WriteLine($"[5] - ManageUsers: {ManageUsers}");
        Console.WriteLine($"[6] - CreateEvent: {CreateEvent}");
    }
    public string ToCsv(User activeuser)
    {
        return $"{activeuser.Id}, {activeuser.Username}, {activeuser.Role}, {ViewPatient}, {EditPatient}, {AddDoctor}, {GiveMed}, {ManageUsers}, {CreateEvent}";
    }
    public User ChooseUserByIdAdmin(List<User> users)
    {
        Console.WriteLine("-----All users in system-----\n");
        foreach (User user in users)
        {
            if (user.Role == UserRole.Patient)
                Console.WriteLine($"Id: {user.Id} Name: {user.Username} Role: {user.Role}");
        }
        Console.Write("\nChoose a user by ID:");
        string inputid = Console.ReadLine();
        int intinputid = int.Parse(inputid);
        foreach (User user in users)
        {
            if (intinputid == user.Id)
            {
                User ChoosenUser = user;
                return ChoosenUser;
            }
            return null;


        }
        return null;
    }

    public void EditUserPermissionById(List<User> users)
    {
        User user = ChooseUserByIdAdmin(users);
        bool Choosing = true;
        while (Choosing)
        {
            Console.WriteLine($"Choosen user: {user.Username}");
            ShowAllPermission(user);
            Console.Write("\nChoose a permission in the list:");

            string ChangePermission = Console.ReadLine();
            switch (ChangePermission)
            {
                case "1":
                    Console.WriteLine($"[1] - ViewPatient: {ViewPatient}");
                    Console.WriteLine("T = true  |  F = false");
                    switch (Console.ReadLine())
                    {
                        case "t":
                            ViewPatient = true;
                            break;
                        case "f":
                            ViewPatient = false;
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine($"[2] - EditPatient: {EditPatient}");
                    Console.WriteLine("T = true  |  F = false");
                    switch (Console.ReadLine())
                    {
                        case "t":
                            EditPatient = true;
                            break;
                        case "f":
                            EditPatient = false;
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine($"[3] - AddDoctor: {AddDoctor}");
                    Console.WriteLine("T = true  |  F = false");
                    switch (Console.ReadLine())
                    {
                        case "t":
                            AddDoctor = true;
                            break;
                        case "f":
                            AddDoctor = false;
                            break;
                    }
                    break;
                case "4":
                    Console.WriteLine($"[4] - GiveMed: {GiveMed}");
                    Console.WriteLine("T = true  |  F = false");
                    switch (Console.ReadLine())
                    {
                        case "t":
                            GiveMed = true;
                            break;
                        case "f":
                            GiveMed = false;
                            break;
                    }
                    break;
                case "5":
                    Console.WriteLine($"[5] - ManageUsers: {ManageUsers}");
                    Console.WriteLine("T = true  |  F = false");
                    switch (Console.ReadLine())
                    {
                        case "t":
                            ManageUsers = true;
                            break;
                        case "f":
                            ManageUsers = false;
                            break;
                    }
                    break;
                case "6":
                    Console.WriteLine($"[6] - CreateEvent: {CreateEvent}");
                    Console.WriteLine("T = true  |  F = false");
                    switch (Console.ReadLine())
                    {
                        case "t":
                            CreateEvent = true;
                            break;
                        case "f":
                            CreateEvent = false;
                            break;
                    }
                    break;

            }

        }

    }
}