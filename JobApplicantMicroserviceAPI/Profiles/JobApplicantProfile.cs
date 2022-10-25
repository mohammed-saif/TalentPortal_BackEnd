using AutoMapper;
using JobApplicantMicroserviceAPI.Models.Domain;
using JobApplicantMicroserviceAPI.Models.DTO;

namespace JobApplicantMicroserviceAPI.Profiles
{
        public class JobApplicantProfile : Profile
        {
            public JobApplicantProfile()
            {
                CreateMap<JobApplicant, JobApplicantDTO>().ReverseMap();
            }
        }
}
