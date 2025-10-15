
using System.Reflection.Metadata;
using App;


BookingSystem booking = new BookingSystem();


DateTime now = DateTime.Now;


User doctor1 = new User("d1", "p", true, UserRole.Doctor);
User doctor2 = new User("d2", "p", true, UserRole.Doctor);

booking.Doctors.Add(doctor1);
booking.Doctors.Add(doctor2);


User patient1 = new User("p1", "p", true, UserRole.Patient);
User patient2 = new User("p2", "p", true, UserRole.Patient);

booking.Patients.Add(patient1);
booking.Patients.Add(patient2);

Console.WriteLine("Welcome to booking system");
Console.WriteLine("what doctor would you like to book?");
for (int i = 0; i < booking.Doctors.Count; i++)
{
    Console.WriteLine($"Doctor Index:{i} Dr.{booking.Doctors[i].Username}.");
}

int BookedDrIndex = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter index of Doctor to book.");

booking.ShowAvailableTimes(booking.Doctors[BookedDrIndex]);




//booking.ShowAvailableTimes();