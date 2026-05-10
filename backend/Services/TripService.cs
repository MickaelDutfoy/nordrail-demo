using backend.Models;

namespace backend.Services;

public class TripService
{
    private readonly List<Trip> _trips =
    [
        new Trip
        {
            Id = 1,
            FromCity = new City { Name = "Oslo" },
            ToCity = new City { Name = "Trondheim" },
            DepartureTime = "07:00",
            ArrivalTime = "12:30",
            Price = 649
        }
    ];

    public IReadOnlyList<Trip> GetAllTrips()
    {
        return _trips;
    }

    public IReadOnlyList<Trip> GetTrips(string from, string to)
    {
        return _trips
            .Where(trip =>
                trip.FromCity.Name == from &&
                trip.ToCity.Name == to)
            .ToList();
    }

    public Trip? GetTripById(int id)
    {
        return _trips.FirstOrDefault(trip => trip.Id == id);
    }
}