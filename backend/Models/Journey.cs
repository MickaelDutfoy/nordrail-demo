namespace backend.Models;

public class Journey
{
    public string Id { get; set; } = string.Empty;

    public List<Trip> Segments { get; set; } = [];

    public decimal TotalPrice { get; set; }
}