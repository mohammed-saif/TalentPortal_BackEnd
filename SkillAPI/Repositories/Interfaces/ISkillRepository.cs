using SkillAPI.Models.Domain;

namespace SkillMicroserviceAPI.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> ListAllSkills();
        Task<Skill> AddSkill(Skill skill);
        Task<Skill> RemoveSkill(int SkillId);
        Task<IEnumerable<Skill>> GetSkillsBySearchAsync(string searchText);
        Task<Skill> GetSkillByIdAsync(int SkillId);
    }
}
