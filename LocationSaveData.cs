namespace App;
class LocationSaveData
{
    public string LocationFile = "Locations.csv";

    public static void SaveLocationDataCsv(Location location)
    {
        LocationSaveData save = new LocationSaveData();
        if (File.Exists(save.LocationFile))
        {
            string line = $"{location.Name},{location.Address},{location.Description}";
            File.AppendAllLines(save.LocationFile, new[] { line });
        }
        else
        {
            Console.WriteLine("Didn't find location file!");
        }
    }
    public static void LoadLocationDataCsv(List<Location> locations)
    {
        LocationSaveData save = new LocationSaveData();
        if (File.Exists(save.LocationFile))
        {
            string[] lines = File.ReadAllLines(save.LocationFile);
            foreach (string line in lines)
            {
                string[] part = line.Split(",");
                string name = part[0];
                string address = part[1];
                string description = part[2];

                Location location = new Location(name, address, description);
                locations.Add(location);
            }
        }
        else
        {
            Console.WriteLine("Didnt find location file!");
        }
    }

}