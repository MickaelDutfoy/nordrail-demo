namespace backend.Models;

public class CreateBookingRequest
{
    public List<int> TripIds { get; set; } = [];
}