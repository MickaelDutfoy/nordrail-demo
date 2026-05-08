namespace backend.Services;

public class CityService
{
    private readonly List<string> _cities =
    [
        "Trondheim",
        "Oslo",
        "Bodø",
        "Bergen",
        "Narvik",
        "Tromsø",
        "Ålesund",
        "Stavanger"
    ];

    public IReadOnlyList<string> GetAll()
    {
        return _cities;
    }
}