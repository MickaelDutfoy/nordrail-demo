using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class BookingService
{
    private readonly NordRailDbContext _context;

    public BookingService(NordRailDbContext context)
    {
        _context = context;
    }

    public Booking CreateBooking(CreateBookingRequest request)
    {
        var segments = _context.Trips
            .Include(trip => trip.FromCity)
            .Include(trip => trip.ToCity)
            .Where(trip => request.TripIds.Contains(trip.Id))
            .ToList()
            .OrderBy(trip => request.TripIds.IndexOf(trip.Id))
            .ToList();

        if (segments.Count != request.TripIds.Count)
        {
            throw new InvalidOperationException("One or more trips were not found.");
        }

        var booking = new Booking
        {
            Segments = segments,
            TotalPrice = segments.Sum(segment => segment.Price),
            TotalDuration = CalculateTotalDuration(segments),
            CreatedAt = DateTime.UtcNow
        };

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return booking;
    }

    public IReadOnlyList<Booking> GetAllBookings()
    {
        return _context.Bookings
            .Include(booking => booking.Segments)
                .ThenInclude(segment => segment.FromCity)
            .Include(booking => booking.Segments)
                .ThenInclude(segment => segment.ToCity)
            .ToList();
    }

    public Booking? GetBookingById(int id)
    {
        return _context.Bookings
            .Include(booking => booking.Segments)
                .ThenInclude(segment => segment.FromCity)
            .Include(booking => booking.Segments)
                .ThenInclude(segment => segment.ToCity)
            .FirstOrDefault(booking => booking.Id == id);
    }

    public bool DeleteBooking(int id)
    {
        var booking = GetBookingById(id);

        if (booking is null)
        {
            return false;
        }

        _context.Bookings.Remove(booking);
        _context.SaveChanges();

        return true;
    }

    private TimeSpan CalculateTotalDuration(List<Trip> segments)
    {
        var firstDeparture = TimeSpan.Parse(segments.First().DepartureTime);
        var lastArrival = TimeSpan.Parse(segments.Last().ArrivalTime);

        return lastArrival - firstDeparture;
    }
}