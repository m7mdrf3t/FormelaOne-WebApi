using AutoMapper;
using ServiceLink.Core.DbSet;
using ServiceLink.Core.Dto.Requests;

namespace ServiceLinkApi.MapperProfile;

public class RequestToDomain : Profile
{
     public RequestToDomain()
     {
        CreateMap<CreateDriveAchivementRequest , Achievement>()
                .ForMember(
                    dest => dest.RaceWins , opt => opt.MapFrom( src => src.wins ))
                .ForMember(
                    dest => dest.FastestLab , opt => opt.MapFrom(src => src.FastestLab))
                .ForMember(
                    dest => dest.status , opt => opt.MapFrom(src => 1))
                .ForMember (
                    dest => dest.AddTime , opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                    dest => dest.UpdateTime , opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                    dest => dest.DriverID , opt => opt.MapFrom(src => src.DriverId));

        CreateMap<UpdateDriveAchivementRequest , Achievement>()
                .ForMember(
                    dest => dest.RaceWins , opt => opt.MapFrom( src => src.wins ))
                .ForMember(
                    dest => dest.UpdateTime , opt => opt.MapFrom(src => DateTime.UtcNow));


        CreateMap<CreatedDriverRequest , Driver>()
                .ForMember(
                    dest => dest.status , opt => opt.MapFrom(src => 1))
                .ForMember(
                    dest => dest.AddTime , opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                    dest => dest.UpdateTime , opt => opt.MapFrom(src => DateTime.UtcNow))

                .ForMember(dest => dest.Achievements, opt => opt.Ignore()) // Ignoring Achievements for now
                .ForMember(dest => dest.Id, opt => opt.Ignore())
            ;

                

        CreateMap<UpdateDriverRequest ,Driver>()
                .ForMember(
                    dest => dest.UpdateTime , opt => opt.MapFrom(src => DateTime.UtcNow));
     }
}
