using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.MediaFile;

namespace Business.Profiles;

public class MediaFileProfiles:AutoMapper.Profile
{
    public MediaFileProfiles()
    {
        CreateMap<MediaFileCreateDto,MediaFile>();
        CreateMap<MediaFile,MediaFileResponseDto>();
        CreateMap<MediaFileUpdateDto,MediaFile>();
    }
}
