namespace App;

public class SaveData
{
    public string UserFile = "Users.csv";
    public string BookingFile = "Bookings.csv";

    public static void SaveUserDataCsv(string UserFile, User activeuser)
    {
        if (File.Exists(UserFile))
        {
            string line = activeuser.SaveUserCsv(activeuser);
            File.AppendAllLines(UserFile, new[] { line });
        }
        else
        {
            Console.WriteLine("Didn´t find that file!");
        }
    }

}