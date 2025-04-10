using AutoMapper;
using ParkingManagement.Core.DTOS;
using ParkingManagement.Core.Entities;
namespace ParkingManagement.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, SignUpClientDTO>().ReverseMap();
            CreateMap<GetUserByIdDTO, User>().ReverseMap();

            CreateMap<AddParkingDTO, Parking>()
            .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture != null ? src.Picture.FileName : null)) 
            .ForMember(dest => dest.ParkingDays, opt => opt.Ignore()) 
            .ForMember(dest => dest.artisanClientServices, opt => opt.Ignore());


            CreateMap<UpdateParkingDTO, Parking>()
            .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture != null ? src.Picture.FileName : null))
            .ForMember(dest => dest.ParkingDays, opt => opt.Ignore())
            .ForMember(dest => dest.artisanClientServices, opt => opt.Ignore());
        }
    }
}
