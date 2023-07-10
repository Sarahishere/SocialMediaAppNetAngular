
using AutoMapper;
using SocialMedia.Persistence.Data.DTOs.Incoming;
using SocialMedia.Persistence.Data.DTOs.Outgoing;
using SocialMedia.Persistence.Entities;

namespace SocialMedia.Endpoint.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser,UserReturnDto>()
            .ForMember(dest => dest.PhotoUrl, 
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<Photo,PhotoReturnDto>();
            CreateMap<MemberUpdateDto,AppUser>();
        }
        
    }
}