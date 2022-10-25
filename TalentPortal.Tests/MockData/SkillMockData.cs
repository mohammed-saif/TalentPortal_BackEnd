using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillAPI.Models.Domain;

namespace TalentPortal.Tests.MockData
{
    internal class SkillMockData
    {
        public static List<Skill> GetAllSkills()
        {
            return new List<Skill>() {
                new Skill(){SkillId=1,SkillName="c programming"},
                new Skill(){SkillId=2,SkillName= "Java" },
                new Skill(){SkillId=3,SkillName="C sharp" },
            };
        }

        public static List<Skill> GetAllSkillsSearchText()
        {
            return new List<Skill>() {
                new Skill(){SkillId=1,SkillName="c programming"},
                new Skill(){SkillId=2,SkillName= "C++" },
                new Skill(){SkillId=3,SkillName="C sharp" },
            };
        }
        public static List<Skill> GetListedEmptySkills()
        {
            return new List<Skill>();
        }
        public static Skill SingleSkills()
        {
            return new Skill { SkillId = 1, SkillName = "a" };
        }
        public static Skill CompleteEmptySkill()
        {
            return null;
        }
    }
}
