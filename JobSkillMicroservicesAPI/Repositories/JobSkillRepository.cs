using JobSkillMicroservicesAPI.Data;
using JobSkillMicroservicesAPI.Models.Domain;
using JobSkillMicroservicesAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSkillMicroserviceAPI.Repositories
{
    public class JobSkillRepository:IJobSkillRepository
    {
        private readonly JobSkillDbContext jobSkillDbContext;

        public JobSkillRepository(JobSkillDbContext jobSkillDbContext)
        {
            this.jobSkillDbContext = jobSkillDbContext;
        }

        public async Task<IEnumerable<JobSkill>> GetAllJobSkills()
        {
            return await jobSkillDbContext.JobSkills.ToListAsync();
        }
        public async Task<IEnumerable<JobSkill>> GetAllJobSkillsByJobId(int jobId)
        {
            var jobSkillData = await jobSkillDbContext.JobSkills.Where(x => x.JobId == jobId).ToListAsync();
            List<JobSkill> jobSkills = new List<JobSkill>();
            if(jobSkillData != null)
            {
                foreach (var item in jobSkillData)
                {
                    jobSkills.Add(item);
                }
                return jobSkills;
            }
            else
            {
                return null;
            }

        }


        // update a skill required by a job
        public async Task<JobSkill> PostOrUpdateJobSkill(int jobId, int skillId)
        {
            //var skill = await jobSkillDbContext.JobSkills.Where(x => x.SkillId == skillId).SingleAsync();

            if (jobId == 0||skillId==0)
            {
                return null;
            }
            else
            {
           
                var jobSkill = new JobSkill()
                {
                    JobId = jobId,
                    SkillId = skillId,
                };

                await jobSkillDbContext.JobSkills.AddAsync(jobSkill);
                await jobSkillDbContext.SaveChangesAsync();
                return jobSkill;
            }


        }

        public async Task<IEnumerable<JobSkill>> DeleteAllJobSkills(int JobId)
        {
            var jobskills = await jobSkillDbContext.JobSkills.Where(x => x.JobId == JobId).ToListAsync();

            if (jobskills != null)
            {
                foreach (var js in jobskills)
                {
                    jobSkillDbContext.JobSkills.Remove(js);
                    await jobSkillDbContext.SaveChangesAsync();
                }

                return jobskills;
            }
            else
            {
                return null;
            }
        }
        //deleting skill whose jobid and skillid are matching parameters
        public async Task<JobSkill> DeleteJobSkill(int jobId, int skillId)
        {
            //var skilln = await jobSkillDbContext.JobSkills.FirstOrDefaultAsync(x => x.SkillId == skillId);
            var jobSkill = await jobSkillDbContext.JobSkills.FirstOrDefaultAsync(x => x.JobId == jobId && x.SkillId == skillId);
            Console.WriteLine("cdhjvadcj");
            if (jobSkill!=null)
            {
                jobSkillDbContext.JobSkills.Remove(jobSkill);
                await jobSkillDbContext.SaveChangesAsync();
                return jobSkill;
            }
            else
            {
                return null;
            }
        }

        //here updating skillid by matching the jobid, there is a chance of error here since no interdependencies, we cant check the skill id is valid or not, here skill id can be anything.
        public async Task<JobSkill> UpdateJobSkill(int jobId, int skillId1,int skillId2)
        {
            var jobSkill = await jobSkillDbContext.JobSkills.FirstOrDefaultAsync(x => x.SkillId == skillId1 && x.JobId==jobId);
            if(jobSkill == null)
            {
                return null;
            }
            else
            {
                jobSkill.SkillId = skillId2;
                await jobSkillDbContext.SaveChangesAsync();
                return jobSkill;
            }
        }

    }
}
