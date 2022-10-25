using AutoMapper;
using UserMicroserviceAPI.Models.Domain;
using UserMicroserviceAPI.Models.DTO;

namespace UserMicroserviceAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
