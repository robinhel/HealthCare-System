namespace App;

class Location
{
    public string Name;
    public string Address;
    public string Description;

    public Location(string name, string address, string description)
    {
        Name = name;
        Address = address;
        Description = description;
    }
    public static void ShowAllLocations(List<Location> locations)
    {
        if (locations.Count <= 0)
        {
            Console.WriteLine("No hospitals available");
        }
        else
        {
            Console.WriteLine("Available hospitals:");
            foreach (Location location in locations)
            {
                Console.WriteLine($"{location}");
            }
        }

    }
}

class Assignment
{
    public int userId;
    public Location Loc;
    public Assignment(int userId, Location loc)
    {
        userId = userId;
        loc = loc;
    }
}