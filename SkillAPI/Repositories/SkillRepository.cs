using Microsoft.EntityFrameworkCore;
using SkillAPI.Models.Domain;
using SkillMicroserviceAPI.Data;
using SkillMicroserviceAPI.Repositories;
using SkillMicroserviceAPI.Repositories.Interfaces;

namespace SkillMicroserviceAPI.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly SkillDbContext skillDbContext;
        public SkillRepository(SkillDbContext _skillDbContext)
        {
            this.skillDbContext = _skillDbContext;
        }

        public async Task<IEnumerable<Skill>> ListAllSkills()
        {
            var skills = await skillDbContext.Skills.ToListAsync();
            return skills;
        }

        public async Task<Skill> GetSkillByIdAsync(int SkillId)
        {
            var skill = await skillDbContext.Skills.FirstOrDefaultAsync(x => x.SkillId == SkillId);
            return skill;
        }

        public async Task<Skill> AddSkill(Skill skill)
        {
            var checkskill = await skillDbContext.Skills.FirstOrDefaultAsync(x => x.SkillId == skill.SkillId);
            if (checkskill == null)
            {
                await skillDbContext.Skills.AddAsync(skill);
                await skillDbContext.SaveChangesAsync();

            }
            return skill;
        }

        public async Task<Skill> RemoveSkill(int SkillId)
        {
            var skill = await skillDbContext.Skills.FirstOrDefaultAsync(x => x.SkillId == SkillId);

            if (skill != null)
            {
                skillDbContext.Skills.Remove(skill);
                await skillDbContext.SaveChangesAsync();

                return skill;
            }
            else
            {
                return null;
            }
        }
        public async Task <IEnumerable<Skill>> GetSkillsBySearchAsync(string searchText)
        {

            List<Skill> skill = await skillDbContext.Skills.Where(x => x.SkillName.ToLower().Contains(searchText.ToLower())).ToListAsync();

            return skill;
        }
    }
}


      
            