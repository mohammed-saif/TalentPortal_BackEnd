using UserSkillMicroserviceAPI.Models.Domain;

namespace UserSkillMicroserviceAPI.Repositories.Interfaces
{
    public interface IUserSkillRepository
    {
        Task<IEnumerable<UserSkill>> ListAllUserSkills();
        // Task<UserSkill> GetUserSkillById(int userId);
        Task<IEnumerable<UserSkill>> GetUserSkillById(int userId);
        Task<UserSkill> AddUserSkill(UserSkill userSkill);
        Task<UserSkill> DeleteUserSkill(int skillId, int userId);
    }
}
