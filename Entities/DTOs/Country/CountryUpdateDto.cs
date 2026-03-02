namespace Entities.DTOs.Country;

public class CountryUpdateDto
{
    public string Name {get; set;}
    public string IsoCode {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
