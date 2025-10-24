namespace App;

class Location
{
    public string Name;
    public string Address;
    public string Description;
    public List<int> DoctorIds;

    public Location(string name, string address, string description)
    {
        Name = name;
        Address = address;
        Description = description;
        DoctorIds = new List<int>();
    }
    public static void ShowAllLocations(List<Location> locations)
    {
        if (locations.Count < 1)
        {
            Console.WriteLine("No hospitals available");
        }
        else
        {
            Console.WriteLine("Available hospitals:");
            foreach (Location location in locations)
            {
                Console.WriteLine($"{location.Name}");
            }
        }
        Console.WriteLine("Enter to continue");
        Console.ReadLine();
    }
}
