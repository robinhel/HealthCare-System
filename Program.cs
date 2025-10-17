using System.Reflection;
using App;
using Microsoft.VisualBasic;

class MyProgram
{
    static void Main(string[] args)
    {

        BookingSystem bookingSystem = new BookingSystem();

        List<User> users = new List<User>();

        users.Add(new User("p-1", "a", false, UserRole.Patient));
        users.Add(new User("p-2", "a", false, UserRole.Patient));
        users.Add(new User("p-3", "a", false, UserRole.Patient));
        users.Add(new User("d-1", "a", false, UserRole.Doctor));
        users.Add(new User("d-2", "a", false, UserRole.Doctor));
        users.Add(new User("a-1", "a", false, UserRole.Admin));

        User activeUser = users[0];

        // Välj doktor
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Role == UserRole.Doctor)
            {
                Console.WriteLine($"Doctor Index:{i} Dr.{users[i].Username}.");
            }
        }

        Console.WriteLine("Enter index of Doctor to book.");
        int index = Convert.ToInt32(Console.ReadLine());

        // Vald doktor från lista med index
        User choosenDoctor = users[index];



        // Se lediga tider för vald doktor
        bookingSystem.ShowAvailableTimes(choosenDoctor);
        Console.WriteLine("Enter starting Hour of booking (8-15)");

        Double startTime = Convert.ToInt32(Console.ReadLine());

        DateTime bookedTime = DateTime.Today.AddHours(startTime);

        bookingSystem.RequestBooking(choosenDoctor, activeUser, bookedTime);

        bookingSystem.HandleRequestBooking(choosenDoctor);

        bookingSystem.Patientscheduele(activeUser);



        //välj tid
        //avgöra vilken patient som ska ha tiden



        // Boka en ledig tid för vald doctor.
        //bookingSystem.CreateBooking(choosenDoctor);
    }
}