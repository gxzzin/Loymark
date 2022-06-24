using AutoMapper;
using UsersControl.DTO;
using UsersControl.Models;

namespace UsersControl.AutoMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            //Source --> Dest...
            CreateMap<User, UserReadDTO>().ForMember(dest => dest.Birthday, opt => opt.MapFrom(srs => srs.Birthday.ToString("yyyy-MM-dd")))
                                          .ForMember(dest => dest.CountryName, opt => opt.MapFrom(srs => srs.Country.CountryName));

            CreateMap<UserCreateDTO, User>();

            CreateMap<UserUpdateDTO, User>();
        }
    }
}