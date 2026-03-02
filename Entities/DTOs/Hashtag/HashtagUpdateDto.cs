namespace Entities.DTOs.Hashtag;

public class HashtagUpdateDto
{
    public string TagValue {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
