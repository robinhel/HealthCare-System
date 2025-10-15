namespace App;

public class BookingSystem
{
    public List<Booking> bookings = new();
    public List<User> Doctors = new();
    public List<User> Patients = new();
    public TimeSpan openingHour = new(8, 0, 0);
    public bool isOpenWeekends = false;

    public void ShowAvailableTimes(User doctor)
    {
        Console.WriteLine($"Available times for Dr. {doctor.Username}:");
        DateTime date = DateTime.Today;

        for (int hour = 8; hour < 16; hour++)
        {
            DateTime time = new(date.Year, date.Month, date.Day, hour, 0, 0);
            bool isBooked = bookings.Any(b => b.Doctor == doctor && b.Start == time);

            string status = isBooked ? "busy" : "available";
            Console.WriteLine($"{hour}:00 - {hour + 1}:00 ({status})");
        }
    }

    public void CreateBooking(User doctor, User patient, DateTime time)
    {
        if (bookings.Any(b => b.Doctor == doctor && b.Start == time))
        {
            Console.WriteLine($"Time {time:HH:mm} is already booked for Dr. {doctor.Username}.");
            return;
        }

        int newId = bookings.Count + 1;
        Booking booking = new(newId, patient, doctor, time);
        bookings.Add(booking);

        Console.WriteLine($"New booking created for Dr. {doctor.Username}");
        Console.WriteLine($"Patient: {patient.Username}");
        Console.WriteLine($"Time: {time:HH:mm}");
    }
}
