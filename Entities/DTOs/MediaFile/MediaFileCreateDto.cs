namespace Entities.DTOs.MediaFile;

public class MediaFileCreateDto
{
    public string FileName {get; set;}
    public string FilePath {get; set;}
    public string FileType {get; set;}
    public long? FileSize {get; set;} = null!;
    public byte[] FileData {get; set;}
    public Guid ProfileId {get; set;}
    public Guid? PostId {get; set;} = null!;
    public Guid? MessageId {get; set;} = null!;
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
