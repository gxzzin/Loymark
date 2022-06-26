using AutoMapper;
using UsersControl.DTO;
using UsersControl.Models;

namespace UsersControl.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Source --> Dest...
            CreateMap<User, UserReadDTO>().ForMember(dest => dest.Birthday, opt => opt.MapFrom(srs => srs.Birthday.ToString("yyyy-MM-dd")))
                                          .ForMember(dest => dest.CountryNameAndCode, opt => opt.MapFrom(srs => $"{srs.Country.CountryName} ({srs.Country.Alpha3Code})"));

            CreateMap<UserCreateDTO, User>();

            CreateMap<UserUpdateDTO, User>();

            CreateMap<Country, CountryReadDTO>().ForMember(dest => dest.NameAndCode, opt => opt.MapFrom(srs => $"{srs.CountryName} ({srs.Alpha3Code})"));
        }
    }
}