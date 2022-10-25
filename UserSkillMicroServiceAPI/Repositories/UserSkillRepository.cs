using Microsoft.EntityFrameworkCore;
using UserSkillMicroserviceAPI.Data;
using UserSkillMicroserviceAPI.Models.Domain;
using UserSkillMicroserviceAPI.Repositories.Interfaces;

namespace UserSkillMicroserviceAPI.Repositories
{
    public class UserSkillRepository : IUserSkillRepository
    {
    
        
            private readonly UserSkillMicroServiceDbContext userSkillMicroServiceDbContext;
            //private readonly TalentPortalDbContext talentPortalDbContext;

            public UserSkillRepository(UserSkillMicroServiceDbContext _userSkillMicroServiceDbContext)
            {
                userSkillMicroServiceDbContext = _userSkillMicroServiceDbContext;
            }
            public async Task<UserSkill> AddUserSkill(UserSkill userSkill)
            {
                await userSkillMicroServiceDbContext.UserSkills.AddAsync(userSkill);
                await userSkillMicroServiceDbContext.SaveChangesAsync();
                return userSkill;
            }

            public async Task<UserSkill> DeleteUserSkill(int skillId, int userId)
            {
                {
                    var userskill = await userSkillMicroServiceDbContext.UserSkills.FirstOrDefaultAsync(x => x.SkillId == skillId && x.UserId == userId);
                    if (userskill != null)
                    {
                        userSkillMicroServiceDbContext.UserSkills.Remove(userskill);
                        await userSkillMicroServiceDbContext.SaveChangesAsync();
                        return userskill;
                    }
                    else
                        return null;

                }
            }

        //public async Task<UserSkill> GetUserSkillById(int userId)
        //{
        //    {
        //        var userskill = await userSkillMicroServiceDbContext.UserSkills.FirstOrDefaultAsync(x => x.UserId == userId);
        //        if (userskill == null)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return userskill;
        //        }
        //    }
        //}
        public async Task<IEnumerable<UserSkill>> GetUserSkillById(int userid)
        {
            var userskill = await userSkillMicroServiceDbContext.UserSkills.ToListAsync();
            List<UserSkill> userSkills    = new List<UserSkill>();
            foreach(var item in userskill)
            {
                if(item.UserId == userid)
                {
                    userSkills.Add(item);
                }
            }
            return userSkills;
        }

        public async Task<IEnumerable<UserSkill>> ListAllUserSkills()
            {
               return await userSkillMicroServiceDbContext.UserSkills.ToListAsync();
            }
        }
    }

