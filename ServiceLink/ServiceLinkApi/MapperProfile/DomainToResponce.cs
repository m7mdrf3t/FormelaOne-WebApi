using AutoMapper;
using ServiceLink.Core.DbSet;
using ServiceLink.Core.Dto.Requests;
using ServiceLink.Core.Dto.Responses;

namespace ServiceLinkApi.MapperProfile;

public class DomainToResponce : Profile
{
    public DomainToResponce()
    {
        CreateMap<Achievement , DriveAchivementResponce>()
            .ForMember(
                dest => dest.wins , opt => opt.MapFrom( src => src.RaceWins ));

        CreateMap<Driver , GetDriveResponce>()
            .ForMember(
                dest => dest.Fullname , opt => opt.MapFrom( src => src.username))
            .ForMember(
                dest => dest.DriveID , opt => opt.MapFrom( src => src.Id));
                
            
    }
}
