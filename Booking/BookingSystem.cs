namespace App;

public class BookingSystem
{
    public List<Booking> bookings = new();

    public void ShowAvailableTimes(User doctor)
    {
        Console.WriteLine($"available times for doctor: {doctor.Username}");
        DateTime date = DateTime.Today;

        for (int hour = 8; hour < 16; hour++)
        {
            DateTime time = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);

            bool isBooked = false;

            Booking foundBooking = null;

            foreach (Booking b in bookings)
            {
                if (b.Doctor == doctor && b.Start.Hour == hour && b.Start.Date == date.Date)
                {
                    isBooked = true;
                    foundBooking = b;
                    break;
                }
            }
            if (isBooked)
            {
                if (foundBooking.Approved)
                {
                    Console.WriteLine($"{hour}:00 - {hour + 1}:00 ({BookingStates.busy})");
                }
                else
                {
                    Console.WriteLine($"{hour}:00 - {hour + 1}:00 ({BookingStates.pending})");
                }
            }
            else
            {
                Console.WriteLine($"{hour}:00 - {hour + 1}:00 ({BookingStates.available}), time: {time}");
            }


        }
    }

    public void RequestBooking(User doctor, User patient, DateTime time)
    {
        bool timeTaken = false;
        foreach (Booking b in bookings)
        {
            if (b.Start == time)
            {
                timeTaken = true;
                break;
            }
        }
        if (timeTaken == true)
        {
            Console.WriteLine($"Time: {time:HH:mm} is already book for Dr.{doctor.Username}.");
        }
        else
        {
            int newId = bookings.Count + 1;

            Booking booking = new Booking(newId, patient, doctor, time);
            bookings.Add(booking);

            Console.WriteLine($"new booking for Dr.{doctor.Username}");
            Console.WriteLine($"Patient is: {patient.Username}");
            Console.WriteLine($"Time: {time}");
        }
    }



}