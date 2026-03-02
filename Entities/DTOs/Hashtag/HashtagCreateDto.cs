namespace Entities.DTOs.Hashtag;

public class HashtagCreateDto
{
    public string TagValue {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
