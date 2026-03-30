using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Entities;

namespace ECommerceApp.Core.Mappers;

public class ApplicationUserToUserDTOMappingProfile : Profile
{
    public ApplicationUserToUserDTOMappingProfile()
    {
        CreateMap<ApplicationUser, UserDTO>()
        .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
        .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
    }
}
