using JobMicroserviceAPI.Data;
using JobMicroserviceAPI.Models.Domain;
using JobMicroserviceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace JobMicroserviceAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobMicroserviceDbContext jobMicroserviceDbContext;

        public JobRepository(JobMicroserviceDbContext jobMicroserviceDbContext)
        {
                this.jobMicroserviceDbContext = jobMicroserviceDbContext;   
        }


        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            var jobs = await jobMicroserviceDbContext.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<Job> GetJobByIdAsync(int jobId)
        {
            var job = await jobMicroserviceDbContext.Jobs.SingleOrDefaultAsync(x => x.Id == jobId);

            return job;


        }

        public async  Task<IEnumerable<Job>> GetJobsByIdListAsync(List<int> jobIdList)
        {
            var jobs = new List<Job>();
            if(jobIdList != null)
            {
                foreach(var j in jobIdList)
                {
                    var job = await jobMicroserviceDbContext.Jobs.SingleOrDefaultAsync(x => x.Id == j);
                    if(job != null)
                    {
                        jobs.Add(job);
                    }
                }
            }

            return jobs;
        }

        public async Task<IEnumerable<Job>> GetJobsBySearchAsync(string searchText)
        {
            var jobs = new List<Job>();
            foreach (var text in searchText.Split(" "))
            {
                var query = await jobMicroserviceDbContext.Jobs.Where(x => x.JobName.Contains(text) || x.JobDescription.Contains(text) || x.JobLocation.Contains(text)).ToListAsync();

                if (query != null)
                {
                    foreach (var job in query)
                    {
                        jobs.Add(job);
                    }
                }  
            }
            return jobs.Distinct().ToList();
        }



        public async Task<Job> PostJobAsync(Job job)
        {

            job.JobPostDate = DateTime.Now; 

            job.JobPostDate = DateTime.Now;

            await jobMicroserviceDbContext.Jobs.AddAsync(job);
            await jobMicroserviceDbContext.SaveChangesAsync();

            return job;
        }

        public async Task<Job> UpdateJobAsync(int jobId, Job job)
        {
            var oldJob = await jobMicroserviceDbContext.Jobs.FirstOrDefaultAsync(x => x.Id == jobId);

            if (oldJob != null)
            {
                oldJob.JobName = job.JobName;
                oldJob.JobDescription = job.JobDescription;
                oldJob.JobLocation = job.JobLocation;
                oldJob.JobPostDate = oldJob.JobPostDate;
                oldJob.CompanyName = job.CompanyName;
                oldJob.CompanySize = job.CompanySize;
                oldJob.Status = job.Status;
                oldJob.Openings = job.Openings;
                oldJob.CountOfApplicants = job.CountOfApplicants;
                oldJob.JobType = job.JobType;
                oldJob.MaxPackage = job.MaxPackage; 
                oldJob.MinExp = job.MinExp; 
                oldJob.MinPackage = job.MinPackage; 
                oldJob.Perk = job.Perk;
                oldJob.OpenApplicationCount = job.OpenApplicationCount;

                jobMicroserviceDbContext.Update(oldJob);
                await jobMicroserviceDbContext.SaveChangesAsync();
            }

            return job;
        }

        public async Task<Job> DeleteJobAsync(int jobId)
        {
            var job = await jobMicroserviceDbContext.Jobs.FirstOrDefaultAsync(x => x.Id == jobId);
            if (job != null)
            {
                
                jobMicroserviceDbContext.Jobs.Remove(job);
                await jobMicroserviceDbContext.SaveChangesAsync(); 
            }

            return job;
        }

    }
}
