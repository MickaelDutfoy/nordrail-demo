namespace backend.Models;

public class Booking
{
    public int Id { get; set; }

    public List<Trip> Segments { get; set; } = [];

    public decimal TotalPrice { get; set; }

    public TimeSpan TotalDuration { get; set; }

    public DateTime CreatedAt { get; set; }
}