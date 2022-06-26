using AutoMapper;
using Newtonsoft.Json;
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
                                          .ForMember(dest => dest.CountryNameAndCode, opt => opt.MapFrom(srs => $"{srs.Country.CountryName} ({srs.Country.Alpha3Code})"))
                                          .ForMember(dest => dest.TotalActivities, opt => opt.MapFrom(srs => srs.Activities.Count));

            CreateMap<UserCreateDTO, User>();

            CreateMap<UserUpdateDTO, User>();

            CreateMap<Country, CountryReadDTO>().ForMember(dest => dest.NameAndCode, opt => opt.MapFrom(srs => $"{srs.CountryName} ({srs.Alpha3Code})"));

            CreateMap<Activity, ActivityReadDTO>().ForMember(dest => dest.User, opt => opt.MapFrom((srs, dest) =>
            {
                //Si la accion es cualquier otra menos delete...
                if (srs.ActivityType != "d")
                    return srs.User; //Mapperar desde su relacion...

                //De lo contrario seralizar el objecto partiendo de su data json guardada al momento de la eliminacion...    
                return JsonConvert.DeserializeObject<User>(srs.UserData);
            }));
        }
    }
}