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
}
