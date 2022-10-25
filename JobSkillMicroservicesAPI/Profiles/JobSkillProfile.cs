using AutoMapper;
using JobSkillMicroservicesAPI.Models.Domain;
using JobSkillMicroservicesAPI.Models.DTO;

namespace JobSkillMicroserviceAPI.Profiles
{
    public class JobSkillProfile:Profile
    {
        public JobSkillProfile()
        {
            CreateMap<JobSkill, JobSkillDto>().ReverseMap();
        }
    }
}
