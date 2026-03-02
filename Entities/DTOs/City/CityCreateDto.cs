namespace Entities.DTOs.City;

public class CityCreateDto
{
    public string Name {get; set;}
    public Guid CountryId {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
