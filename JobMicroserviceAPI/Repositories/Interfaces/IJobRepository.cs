using JobMicroserviceAPI.Models.Domain;

namespace JobMicroserviceAPI.Repositories.Interfaces
{
    public interface IJobRepository 
    {
        //get
        Task<IEnumerable<Job>> GetAllJobsAsync();

        Task<Job> GetJobByIdAsync(int jobId);

        Task<IEnumerable<Job>> GetJobsByIdListAsync(List<int> jobIdList); // doesnt know whether required

        Task<IEnumerable<Job>> GetJobsBySearchAsync(string searchText);

        //post
        Task<Job> PostJobAsync( Job job);


        //put
        Task<Job> UpdateJobAsync(int jobId, Job job);  


        //update
        Task<Job> DeleteJobAsync(int jobId);

   




    }
}
