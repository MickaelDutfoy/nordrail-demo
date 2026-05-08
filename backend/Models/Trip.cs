namespace backend.Models;

public class Trip
{
    public int Id { get; set; }

    public string From { get; set; } = string.Empty;

    public string To { get; set; } = string.Empty;

    public string DepartureTime { get; set; } = string.Empty;

    public decimal Price { get; set; }
}