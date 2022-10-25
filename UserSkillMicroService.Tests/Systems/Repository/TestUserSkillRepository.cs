using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UserSkillMicroservice.Tests.MockData;
using UserSkillMicroserviceAPI.Data;
using UserSkillMicroserviceAPI.Models.Domain;
using UserSkillMicroserviceAPI.Repositories;

namespace UserSkillMicroservice.Tests.Systems.Repository
{
    public class TestUserSkillRepository : IDisposable
    {
        private readonly UserSkillMicroServiceDbContext context;


        public TestUserSkillRepository()
        {
            var options = new DbContextOptionsBuilder<UserSkillMicroServiceDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            context = new UserSkillMicroServiceDbContext(options);
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnUserList()
        {
            context.UserSkills.AddRange(UserSkillMockData.GetUserSkills());
            context.SaveChanges();

            var sut = new UserSkillRepository(context);
            var result = await sut.ListAllUserSkills();

            result.Should().HaveCount(UserSkillMockData.GetUserSkills().Count);
            //result.Should().BeNull()
        }

        [Fact]
        public async Task Getby_IDShouldReturnUser()
        {
            context.UserSkills.AddRange(UserSkillMockData.GetUserSkills());
            context.SaveChanges();

            int userId = 2;
            var sut = new UserSkillRepository(context);
            var result = await sut.GetUserSkillById(userId);
            result.Should().HaveCount(2);

        }

        [Fact]
        public async Task Delete_User_Skill_by_ID()
        {
            context.UserSkills.AddRange(UserSkillMockData.GetUserSkills());
            context.SaveChanges();

            int skillId = 1;
            int userId = 2;
            var sut = new UserSkillRepository(context);
            var result = await sut.DeleteUserSkill(skillId, userId);
            result.GetType().Should().Be(typeof(UserSkill));


        }

        [Fact]

        public async Task Add_UserSkill_by_ID()
        {
            context.UserSkills.AddRange(UserSkillMockData.GetUserSkills());
            context.SaveChanges();

            var userSkill= new UserSkill();
            var sut = new UserSkillRepository(context);
            var result = await sut.AddUserSkill(userSkill);
            result.GetType().Should().Be(typeof(UserSkill));

        }





        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
