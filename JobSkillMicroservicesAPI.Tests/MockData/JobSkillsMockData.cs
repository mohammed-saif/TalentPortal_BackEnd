using JobSkillMicroservicesAPI.Models.Domain;

namespace JobSkillMicroserviceAPI.Tests.MockData
{
    internal class JobSkillsMockData
    {
        public static List<JobSkill> GetAllJobSkills()
        {
            return new List<JobSkill>() {
                new JobSkill(){JobSkillId=1,JobId=1,SkillId=1 },
                new JobSkill(){JobSkillId=2,JobId=2,SkillId=2 },
                new JobSkill(){JobSkillId=3,JobId=1,SkillId=3 },
            };
        }

        public static List<JobSkill> GetAllJobSkillsByJobId()
        {
            return new List<JobSkill>() {
                new JobSkill(){JobSkillId=1,JobId=1,SkillId=1 },
                new JobSkill(){JobSkillId=3,JobId=1,SkillId=3 },
            };
        }

        public static List<JobSkill> GetListedEmptyJobSkills()
        {
            return new List<JobSkill>();
        }
        public static JobSkill SingleJobSkills()
        {
            return new JobSkill { JobId = 1, JobSkillId = 1, SkillId = 1 };
        }

        public static JobSkill SingleJobSkillsSkillIdModified()
        {
            return new JobSkill { JobId = 1, JobSkillId = 1, SkillId = 2 };
        }
        public static JobSkill CompleteEmptyJobSkill()
        {
            return null;
        }
    }
}
