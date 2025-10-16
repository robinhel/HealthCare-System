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
        Console.WriteLine("All active permissions");
        Console.WriteLine($"ViewPatient: {ViewPatient}");
        Console.WriteLine($"EditPatient: {EditPatient}");
        Console.WriteLine($"AddDoctor: {AddDoctor}");
        Console.WriteLine($"GiveMed: {GiveMed}");
        Console.WriteLine($"ManageUsers: {ManageUsers}");
        Console.WriteLine($"CreateEvent: {CreateEvent}");
    }
    public string ToCsv(User activeuser)
    {
        return $"{activeuser.Id}, {activeuser.Username}, {activeuser.Role}, {ViewPatient}, {EditPatient}, {AddDoctor}, {GiveMed}, {ManageUsers}, {CreateEvent}";
    }
    public User ChooseUserByIdAdmin(List<User> users)
    {
        Console.WriteLine("-----All users in system-----");
        foreach (User user in users)
        {
            if (user.Role == UserRole.Patient)
                Console.WriteLine($"Id: {user.Id} Name: {user.Username} Role: {user.Role}");
        }
        Console.Write("Choose a user by ID:");
        string inputid = Console.ReadLine();
        int intinputid = int.Parse(inputid);
        foreach (User user in users)
        {
            if (intinputid == user.Id)
            {
                User ChoosenUser = user;
                return ChoosenUser;
            }
            else
            {
                Console.WriteLine("No user with that id found!");
            }
        }

    }

    public void ViewChoosenUserPermission()
    {

    }
}