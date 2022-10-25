using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSkillMicroserviceAPI.Models.Domain;

namespace UserSkillMicroservice.Tests.MockData
{
    internal class UserSkillMockData
    {
        public static List<UserSkill> GetUserSkills()
        {
            var userSkillList = new List<UserSkill>()
            {
                 new UserSkill{UserSkillId=11,UserId=1,SkillId=2 },
                 new UserSkill{UserSkillId=12,UserId=1,SkillId=3 },
                 new UserSkill{UserSkillId=13,UserId=2,SkillId=1 },
                 new UserSkill{UserSkillId=14,UserId=2,SkillId=4 },
                 new UserSkill{UserSkillId=15,UserId=3,SkillId=1 }

            };
            return userSkillList;

        }
        public static List<UserSkill> GetEmpty()
        {
            return new List<UserSkill>();
        }


        //public static Job Job()
        //{
        //    return new Job()
        //    {
        //        JobId = 3,
        //        JobName = "UI/UX developer",
        //        Description = "frontend developer is required",
        //        Experience = 1,
        //        Location = "Kochi",
        //        CountOfApplicants = 0,
        //        OpenApplicationCount = 0
        //    };
        //}


        public static UserSkill UserSkill()
        {
            return new UserSkill()
            {
                UserSkillId = 16,
                UserId = 2,
                SkillId = 1


            };
        }

        public static UserSkill EmptyUserSkill()
        {
            return null;

        }




    }
}
