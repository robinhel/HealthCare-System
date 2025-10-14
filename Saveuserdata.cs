using System.Security;

namespace App;

public class SaveData
{
    public string UserFile = "Users.csv";
    public string BookingFile = "Bookings.csv";

    public static void SaveUserDataCsv(User activeuser)
    {
        SaveData save = new SaveData();
        if (File.Exists(save.UserFile))
        {
            string line = activeuser.SaveUserCsv(activeuser);
            File.AppendAllLines(save.UserFile, new[] { line });
        }
        else
        {
            Console.WriteLine("Didn´t find that file!");
        }
    }
    public static void LoadUserDataCsv(List<User> users)
    {
        SaveData save = new SaveData();
        if (File.Exists(save.UserFile))
        {
            string[] lines = File.ReadAllLines(save.UserFile);
            foreach (string line in lines)
            {
                string[] part = line.Split(",");
                string username = part[0];
                string password = part[1];
                string id = part[2];
                string rolestring = part[3];
                Enum.TryParse(rolestring, true, out UserRole Role); ;
                bool isloggedin = bool.Parse(part[4]);

                User user = new User(username, password, isloggedin, Role);
                users.Add(user);
            }
        }
    }

}