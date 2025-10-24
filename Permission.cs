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

    public Permissions()
    {

    }
    public void SetPatientPermissions(User user)
    {
        if (user.Role == UserRole.Patient)
        {
            // Standard patient permissions set
            user.permissions.ViewPatient = true;
            user.permissions.EditPatient = true;
            user.permissions.AddDoctor = false;
            user.permissions.ManageUsers = false;
            user.permissions.GiveMed = false;
            user.permissions.CreateEvent = false;
            user.permissions.ShowPermissions = false;
        }
    }
    public void SetDoctorPermissions(User user)
    {
        if (user.Role == UserRole.Doctor)
        {
            // Standard doctor permissions set
            user.permissions.ViewPatient = true;
            user.permissions.EditPatient = true;
            user.permissions.AddDoctor = false;
            user.permissions.ManageUsers = false;
            user.permissions.GiveMed = true;
            user.permissions.CreateEvent = true;
            user.permissions.ShowPermissions = true;
        }

    }
    public void ShowAllPermission()
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
            Console.WriteLine($"Id: {user.Id} Name: {user.Username} Role: {user.Role}");
        }
        Console.Write("\nChoose a user by ID: ");
        string inputid = Console.ReadLine();
        int intinputid = int.Parse(inputid);
        foreach (User user in users)
        {
            if (intinputid == user.Id)
            {
                User ChoosenUser = user;
                return ChoosenUser;
            }
        }
        return null;
    }

    public void EditUserPermissionById(List<User> users)
    {
            try
            {
        User user = ChooseUserByIdAdmin(users);
        bool Choosing = true;
        while (Choosing)
        {
            Console.WriteLine($"Choosen user: {user.Username}");
            user.permissions.ShowAllPermission();
            Console.WriteLine("Q to quit");
            Console.Write("\nChoose a permission in the list:");

                string ChangePermission = Console.ReadLine();
                switch (ChangePermission)
                {
                    case "1":
                        user.permissions.ViewPatient = AskBool(1, "ViewPatient", user.permissions.ViewPatient);
                        break;
                    case "2":
                        user.permissions.EditPatient = AskBool(2, "EditPatient", user.permissions.EditPatient);
                        break;
                    case "3":
                        user.permissions.AddDoctor = AskBool(3, "AddDoctor", user.permissions.AddDoctor);
                        break;
                    case "4":
                        user.permissions.GiveMed = AskBool(4, "GiveMed", user.permissions.GiveMed);
                        break;
                    case "5":
                        user.permissions.ManageUsers = AskBool(5, "ManageUsers", user.permissions.ManageUsers);
                        break;
                    case "6":
                        user.permissions.CreateEvent = AskBool(6, "CreateEvent", user.permissions.CreateEvent);
                        break;
                    case "q":
                        Choosing = false;
                        break;
                }
            }

        }

            catch

                        {
            System.Console.WriteLine("Wrong input, try again.");
            Console.ReadLine();
            }
    }

    private bool AskBool(int num, string perm, bool currentbool)
    {
        while (true)
        {
            Console.WriteLine($"[{num}] - {perm}: {currentbool}");
            Console.WriteLine("T = true  |  F = false");
            switch (Console.ReadLine())
            {
                case "t":
                    return true;
                case "f":
                    return false;
            }
            Console.WriteLine("invalid input");
        }
    }
}