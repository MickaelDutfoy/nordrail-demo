using backend.Models;

namespace backend.Services;

public class BookingService
{
    private readonly TripService _tripService;

    private readonly List<Booking> _bookings = [];

    private int _nextId = 1;

    public BookingService(TripService tripService)
    {
        _tripService = tripService;
    }

    public Booking CreateBooking(CreateBookingRequest request)
    {
        var segments = request.TripIds
            .Select(id => _tripService.GetTripById(id))
            .ToList();

        if (segments.Any(segment => segment is null))
        {
            throw new InvalidOperationException("One or more trips were not found.");
        }

        var validSegments = segments
            .Select(segment => segment!)
            .ToList();

        var booking = new Booking
        {
            Id = _nextId++,
            Segments = validSegments,
            TotalPrice = validSegments.Sum(segment => segment.Price),
            TotalDuration = CalculateTotalDuration(validSegments),
            CreatedAt = DateTime.UtcNow
        };

        _bookings.Add(booking);

        return booking;
    }

    public IReadOnlyList<Booking> GetAllBookings()
    {
        return _bookings;
    }

    private TimeSpan CalculateTotalDuration(List<Trip> segments)
    {
        var firstDeparture = TimeSpan.Parse(segments.First().DepartureTime);
        var lastArrival = TimeSpan.Parse(segments.Last().ArrivalTime);

        return lastArrival - firstDeparture;
    }

    public Booking? GetBookingById(int id)
    {
        return _bookings.FirstOrDefault(booking => booking.Id == id);
    }

    public bool DeleteBooking(int id)
    {
        var booking = GetBookingById(id);

        if (booking is null)
        {
            return false;
        }

        _bookings.Remove(booking);

        return true;
    }
}