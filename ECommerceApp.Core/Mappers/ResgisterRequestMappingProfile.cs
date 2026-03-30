using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Entities;

namespace ECommerceApp.Core.Mappers;

public class ResgisterRequestMappingProfile : Profile
{
    public ResgisterRequestMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
        .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
        .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
    }
}
