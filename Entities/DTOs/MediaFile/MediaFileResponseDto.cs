namespace Entities.DTOs.MediaFile;

public class MediaFileResponseDto
{
    public Guid Id {get; set;}
    public string FileName {get; set;}
    public string FilePath {get; set;}
    public string FileType {get; set;}
    public long? FileSize {get; set;} = null!;
    public byte[] FileData {get; set;}
    public Guid ProfileId {get; set;}
    public Guid? PostId {get; set;} = null!;
    public Guid? MessageId {get; set;} = null!;
}
