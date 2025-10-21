using System.Collections;

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
                if (foundBooking.status == BookingStatus.busy)
                {
                    Console.WriteLine($"{hour}:00 - {hour + 1}:00 ({BookingStatus.busy})");
                }
                else
                {
                    Console.WriteLine($"{hour}:00 - {hour + 1}:00 ({BookingStatus.pending})");
                }
            }
            else
            {
                Console.WriteLine($"{hour}:00 - {hour + 1}:00 ({BookingStatus.available}), time: {time}");
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

            Console.WriteLine($"new booking request sent to Dr.{doctor.Username}");
            Console.WriteLine($"Patient is: {patient.Username}");
            Console.WriteLine($"Time: {time}");
            Console.WriteLine("if booking is accepted, it will land in scheduele");
        }
    }
    public void HandleRequestBooking(User doctor)
    {
        for (int i = 0; i < bookings.Count; i++)
        {
            Booking b = bookings[i];
            if (b.status == BookingStatus.pending)
            {
                Console.WriteLine($"booking index: {i} patient:{b.Patient.Username}, time: {b.Start}, status: {b.status}");
            }
        }
        Console.WriteLine("Enter index of booking to Handle");
        int index = Convert.ToInt32(Console.ReadLine());

        Booking HandleBooking = bookings[index];


        Console.WriteLine("Enter [a] to accept request or [d] to deny request");
        string AcceptDeny = Console.ReadLine();

        switch (AcceptDeny)
        {
            case "a":
                HandleBooking.status = BookingStatus.approved;
                Console.WriteLine("Booking Approved");
                Console.ReadLine();

                break;

            case "d":
                HandleBooking.status = BookingStatus.denied;
                Console.WriteLine("Booking Denied");
                Console.ReadLine();

                break;
        }
    }

    public void PatientScheduele(User patient)
    {

        Console.WriteLine($"upcoming appointments for {patient.Username},");
        for (int i = 0; i < bookings.Count; i++)
        {
            Booking b = bookings[i];
            if (b.status == BookingStatus.approved && b.Patient == patient)
            {
                Console.WriteLine($"booking: {i} time: {b.Start}, status: {b.status}");
            }
        }

    }

    public void DoctorScheduele(User doctor)
    {

        Console.WriteLine($"upcoming appointments for {doctor.Username},");
        for (int i = 0; i < bookings.Count; i++)
        {
            Booking b = bookings[i];
            if (b.status == BookingStatus.approved && b.Doctor == doctor)
            {
                Console.WriteLine($"booking: {i} time: {b.Start}, status: {b.status}");
            }
        }

    }

    public void CancelBooking(User patient)
    {
        Console.WriteLine("Your apointments:");
        for (int i = 0; i < bookings.Count; i++)
        {
            Booking b = bookings[i];
            if (b.Patient == patient)
            {
                Console.WriteLine($"Appointment: {i}, Doctor: {b.Doctor} time: {b.Start}, status: {b.status}");
            }
        }
        Console.WriteLine("Enter the index of the appointment to cancel");
        int index = Convert.ToInt32(Console.ReadLine());


        Booking Selectedbooking = bookings[index];
        bookings.Remove(Selectedbooking);
        Console.WriteLine("Appontment has been canceled.");
    }
}