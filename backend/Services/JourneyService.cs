using backend.Models;

namespace backend.Services;

public class JourneyService
{
    private readonly TripService _tripService;

    public JourneyService(TripService tripService)
    {
        _tripService = tripService;
    }

    public IReadOnlyList<Journey> SearchJourneys(string from, string to)
    {
        var allTrips = _tripService.GetAllTrips();

        var journeys = new List<Journey>();

        // Direct journeys
        var directTrips = allTrips
            .Where(trip =>
                trip.FromCity.Name == from &&
                trip.ToCity.Name == to);

        foreach (var trip in directTrips)
        {
            journeys.Add(new Journey
            {
                Id = $"direct-{trip.Id}",
                Segments = [trip],
                TotalPrice = trip.Price,
                TotalDuration = CalculateTotalDuration([trip]),
                SegmentCount = 1
            });
        }

        // One connection max
        var firstSegments = allTrips
            .Where(trip => trip.FromCity.Name == from);

        foreach (var firstTrip in firstSegments)
        {
            var secondSegments = allTrips
                .Where(trip =>
                    trip.FromCity.Name == firstTrip.ToCity.Name &&
                    trip.ToCity.Name == to);

            foreach (var secondTrip in secondSegments)
            {
                if (!HasValidConnection(firstTrip, secondTrip))
                {
                    continue;
                }

                var segments = new List<Trip>
                {
                    firstTrip,
                    secondTrip
                };

                journeys.Add(new Journey
                {
                    Id = $"connection-{firstTrip.Id}-{secondTrip.Id}",
                    Segments = segments,
                    TotalPrice = firstTrip.Price + secondTrip.Price,
                    TotalDuration = CalculateTotalDuration(segments),
                    SegmentCount = segments.Count
                });
            }
        }

        return journeys;
    }

    private bool HasValidConnection(Trip firstTrip, Trip secondTrip)
    {
        var firstArrival =
            TimeSpan.Parse(firstTrip.ArrivalTime);

        var secondDeparture =
            TimeSpan.Parse(secondTrip.DepartureTime);

        var connectionTime =
            secondDeparture - firstArrival;

        return connectionTime >= TimeSpan.FromMinutes(20);
    }

    private TimeSpan CalculateTotalDuration(List<Trip> segments)
    {
        var firstDeparture = TimeSpan.Parse(segments.First().DepartureTime);
        var lastArrival = TimeSpan.Parse(segments.Last().ArrivalTime);

        return lastArrival - firstDeparture;
    }
}