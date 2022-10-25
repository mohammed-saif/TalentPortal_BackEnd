using JobSkillMicroservicesAPI.Models.Domain;

namespace JobSkillMicroservicesAPI.Repositories
{
    public interface IJobSkillRepository
    {
        Task<IEnumerable<JobSkill>> GetAllJobSkills();
        Task<JobSkill> PostOrUpdateJobSkill(int jobId, int skillId);
        Task<IEnumerable<JobSkill>> DeleteAllJobSkills(int jobId);
        Task<JobSkill> DeleteJobSkill(int jobId, int skillId);
        Task<JobSkill> UpdateJobSkill(int jobId, int skillId1,int skillid2);
        Task<IEnumerable<JobSkill>> GetAllJobSkillsByJobId(int jobId);
    }
}
