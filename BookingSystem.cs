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
            else
            {
                Console.WriteLine("No bookings to handle");
                break;
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
            if (b.Patient == patient)
            {
                Console.WriteLine($"booking: {i} time: {b.Start}, status: {b.status}");
            }
            else
            {
                Console.WriteLine("No up coming bookings");
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
            else
            {
                Console.WriteLine("No upcoming bookings");
            }
        }

    }

    public void CancelBooking(User patient)
    {
        bool hasBookings = false;

        Console.WriteLine("Your apointments:");
        for (int i = 0; i < bookings.Count; i++)
        {
            Booking b = bookings[i];
            if (b.Patient == patient)
            {
                Console.WriteLine($"Appointment Index: {i}, Doctor: {b.Doctor.Username} time: {b.Start}, status: {b.status}");
                hasBookings = true;
            }
        }

        if (hasBookings != true)
        {
            Console.WriteLine("you have no Appointments to cancel...");
        }
        else
            Console.WriteLine("Enter the index of the appointment to cancel");
        if (int.TryParse(Console.ReadLine(), out int index))
        {

            Booking Selectedbooking = bookings[index];


            bookings.Remove(Selectedbooking);
            Console.WriteLine("Appontment has been canceled.");
        }

    }



    public void CreatAppointment(User doctor, User patient, DateTime time)
    {
        Console.WriteLine($"new Appointment for Dr.{doctor.Username}");
        Console.WriteLine($"Patient is: {patient.Username}");
        Console.WriteLine($"Time: {time}");
        Console.WriteLine("Booking has been approved and added to schedule");
        int newId = bookings.Count + 1;
        Booking booking = new Booking(newId, patient, doctor, time);
        booking.status = BookingStatus.approved;
        bookings.Add(booking);


    }
}