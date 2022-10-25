using JobApplicantMicroserviceAPI.Models.Domain;

public interface IJobApplicantRepository
{
      Task<IEnumerable<JobApplicant>> ListAllJobApplicants(); // works as intended
    Task<JobApplicant> PostJobApplication(JobApplicant jobapplicant);
    Task<JobApplicant> UpdateJobApplicationStatus(int UserId, int JobId, string newApplicationStatus);
    Task<JobApplicant> FindApplicationStatus(int UserId, int JobId); // works as intended
    Task<IEnumerable<JobApplicant>> ListApplicantJobs(int UserId); // works as intended

    // Task<JobApplicant> UpdateJobApplication(int UserId, int JobId, Byte[] UserResume);

    Task<JobApplicant> DeleteJobApplicant(int UserId, int JobId);
    Task<IEnumerable<JobApplicant>> ListApplicantsbyJobId(int JobId);

    Task<JobApplicant> ValidatingApplicant(int UserId, int JobId);

}