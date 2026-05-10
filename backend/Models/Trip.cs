namespace backend.Models;

public class Trip
{
    public int Id { get; set; }

    public int FromCityId { get; set; }
    public City FromCity { get; set; } = null!;

    public int ToCityId { get; set; }
    public City ToCity { get; set; } = null!;

    public string DepartureTime { get; set; } = string.Empty;

    public string ArrivalTime { get; set; } = string.Empty;

    public decimal Price { get; set; }
}