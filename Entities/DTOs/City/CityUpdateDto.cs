namespace Entities.DTOs.City;

public class CityUpdateDto
{
    public string Name {get; set;}
    public Guid CountryId {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
