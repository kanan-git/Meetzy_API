namespace Entities.DTOs.Country;

public class CountryCreateDto
{
    public string Name {get; set;}
    public string IsoCode {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
