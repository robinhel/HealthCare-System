namespace App;

public class LocationSaveData
{
    public string LocationFile = "Locations.csv";

    public static void SaveLocationDatacsv(Location locations)
    {
        LocationSaveData save = new LocationSaveData();
        if (File.Exists(save.LocationFile))
        {
            string line = $"{locations.Name},{locations.Address},{locations.Description}";
            File.AppendAllLines(save.LocationFile, new[] { line });
        }
        else
        {
            Console.WriteLine("Didn't find location file!");
        }
    }
}






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