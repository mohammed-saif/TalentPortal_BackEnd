using RecruiterMicroserviceAPI.Models.Domain;

namespace RecruiterMicroserviceAPI.Repositories.Interfaces
{
    public interface IRecruiterRepository
    {
        Task<IEnumerable<Recruiter>> GetAllRecruiters();
        Task<IEnumerable<Recruiter>> GetRecruiterByIdAsync(int UserId);
        Task<Recruiter> AddRecruiter(Recruiter recruiter);
        Task<Recruiter> DeleteRecruiter(Recruiter recruiter);
    }
}
