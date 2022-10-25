using AutoMapper;
using SkillAPI.Models.Domain;
using SkillMicroserviceAPI.Models.DTO;

namespace SkillMicroserviceAPI.Profiles
{
    public class SkillProfile:Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>().ReverseMap();
        }

    }
}
