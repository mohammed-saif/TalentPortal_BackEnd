using AutoMapper;
using RecruiterMicroserviceAPI.Models.Domain;
using RecruiterMicroserviceAPI.Models.DTO;

namespace RecruiterMicroserviceAPI.Profiles
{
    public class RecruiterProfile : Profile
    {
        public RecruiterProfile()
        {
            CreateMap<Recruiter, RecruiterDTO>().ReverseMap();
        }
    }
}
