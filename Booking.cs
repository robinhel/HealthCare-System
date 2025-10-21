namespace App;

public class Booking
{
    public int Id { get; set; }
    public User Patient { get; set; }
    public User Doctor { get; set; }
    public DateTime Start { get; set; }
    public BookingStatus status;


    public Booking(int id, User patient, User doctor, DateTime start)
    {
        Id = id;
        Patient = patient;
        Doctor = doctor;
        Start = start;
        status = BookingStatus.pending;
    }
}