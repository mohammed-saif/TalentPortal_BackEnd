using RecruiterMicroserviceAPI.Data;
using RecruiterMicroserviceAPI.Models.Domain;
using RecruiterMicroserviceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RecruiterMicroserviceAPI.Repositories
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly RecruiterDbContext recruiterDbContext;

        public RecruiterRepository(RecruiterDbContext _recruiterDbContext)
        {
            recruiterDbContext = _recruiterDbContext;
        }

        // Return a list of all recruiters
        public async Task<IEnumerable<Recruiter>> GetAllRecruiters()
        {
            var recruiters = await recruiterDbContext.Recruiters.ToListAsync();
            return recruiters;
            
        }

        public async Task<IEnumerable<Recruiter>> GetRecruiterByIdAsync(int UserId)
        {
            var recruiters = await recruiterDbContext.Recruiters.Where(x => x.UserId == UserId).ToListAsync();
            return recruiters;
        }

        // Add a recruiter (This will only be called in the jobrepository because only when a job is posted
        public async Task<Recruiter> AddRecruiter(Recruiter recruiter)
        {
            var doesexist = await recruiterDbContext.Recruiters.FirstOrDefaultAsync(x => x.UserId == recruiter.UserId && x.JobId == recruiter.JobId);
            if(doesexist == null)
            {

                await recruiterDbContext.Recruiters.AddAsync(recruiter);
                await recruiterDbContext.SaveChangesAsync();
                return recruiter;

            }
            else
            {
                return null;
            }
            
        }

        public async Task<Recruiter> DeleteRecruiter(Recruiter recruiter)
        {
            var r = await recruiterDbContext.Recruiters.FirstOrDefaultAsync(x => x.UserId == recruiter.UserId && x.JobId == recruiter.JobId);
            if (r != null)
            {
                recruiterDbContext.Recruiters.Remove(r);
                await recruiterDbContext.SaveChangesAsync();

                return r;
            }
            else
            {
                return null;
            }

            
            //if (r != null)
            //{
            //    recruiterDbContext.Recruiters.Remove(r);
            //    await recruiterDbContext.SaveChangesAsync();

            //    return r;
            //}
            //else
            //{
            //    return null;
            //}
        }
    }
}
