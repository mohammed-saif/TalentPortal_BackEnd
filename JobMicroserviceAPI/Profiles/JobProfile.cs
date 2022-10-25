using AutoMapper;
using JobMicroserviceAPI.Models.Domain;
using JobMicroserviceAPI.Models.DTO;

namespace JobMicroserviceAPI.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDto>().ReverseMap();
        }
    }


}
