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