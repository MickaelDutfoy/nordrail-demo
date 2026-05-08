using backend.Models;

namespace backend.Services;

public class TripService
{
    private readonly List<Trip> _trips =
    [
        new Trip
        {
            Id = 1,
            From = "Trondheim",
            To = "Oslo",
            DepartureTime = "08:30",
            Price = 799
        },

        new Trip
        {
            Id = 2,
            From = "Oslo",
            To = "Bergen",
            DepartureTime = "10:15",
            Price = 599
        },

        new Trip
        {
            Id = 3,
            From = "Bodø",
            To = "Trondheim",
            DepartureTime = "07:00",
            Price = 999
        }
    ];

    public IReadOnlyList<Trip> GetTrips(string from, string to)
    {
        return _trips
            .Where(trip =>
                trip.From == from &&
                trip.To == to)
            .ToList();
    }
}