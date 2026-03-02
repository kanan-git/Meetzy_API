namespace Entities.DTOs.Profile;

public class ProfileResponseDto
{
    // public string ProfilePictureUrl {get; set;}
    // public string CoverPictureUrl {get; set;}
    public Guid Id {get; set;}
    public string? Bio {get; set;} = null!;
    public string FeedPageUrl {get; set;}
    public string? Addressline {get; set;} = null!;
    public string CurrentStatus {get; set;}
    public bool IsPrivate {get; set;}
    public string? IpV4Address {get; set;} = null!;
    public string? IpV6Address {get; set;} = null!;
    public string? OwnerId {get; set;} = null!;
    public Guid? CityId {get; set;} = null!;
    public Guid? ProfileImageId {get; set;} = null!;
}
