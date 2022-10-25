using AutoMapper;
using UserSkillMicroserviceAPI.Models.Domain;
using UserSkillMicroserviceAPI.Models.DTO;

namespace UserSkillMicroserviceAPI.Profiles
{
    public class UserSkillProfile : Profile
    {
        public UserSkillProfile()
        {
            CreateMap<UserSkill, UserSkillDTO>().ReverseMap();
        }
    }
}
