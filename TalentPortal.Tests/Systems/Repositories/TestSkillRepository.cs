using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SkillAPI.Models.Domain;
using SkillMicroserviceAPI.Data;
using SkillMicroserviceAPI.Repositories;
using TalentPortal.Tests.MockData;

namespace TalentPortal.Tests.Systems.Repositories
{
    public class TestSkillRepository:IDisposable
    {
        private readonly SkillDbContext context;
        public TestSkillRepository()
        {
            var options = new DbContextOptionsBuilder<SkillDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            context = new SkillDbContext(options);
            context.Database.EnsureCreated();
        }



        [Fact]
        public async Task ListAllSkills_ShouldReturnAllSkills()
        {          
            //Arrange
            context.Skills.AddRange(SkillMockData.GetAllSkills());
            context.SaveChanges();
            var sut = new SkillRepository(context);
            //Act
            var result = await sut.ListAllSkills();

            //Assert
            result.Should().HaveCount(SkillMockData.GetAllSkills().Count);
        }


        [Fact]
        public async Task AddSkill_ShouldReturnSingleUpdatedSkill()
        {
            //Arrange
            context.Skills.AddRange(SkillMockData.SingleSkills());
            context.SaveChanges();
            var sut = new SkillRepository(context);
            Skill newSkill = new Skill() { SkillId = 1, SkillName = "c++" };
            //Act
            var result = await sut.AddSkill(newSkill);
            //Assert
            result.Should().BeOfType<Skill>();

        }

        [Fact]
        public async Task RemoveSkill_ShouldReturnSingleUpdatedSkill()
        {
            //Arrange
            context.Skills.AddRange(SkillMockData.SingleSkills());
            context.SaveChanges();
            var sut = new SkillRepository(context);
            int id = 1;
            //Skill newSkill = new Skill() { SkillId = 1, SkillName = "c++" };
            //Act
            var result = await sut.RemoveSkill(id);
            //Assert
            result.Should().BeOfType<Skill>();

        }
        [Fact]
        public async Task GetSkillsBySearchAsync_ShouldReturnSingleUpdatedSkill()
        {
            //Arrange
            context.Skills.AddRange(SkillMockData.GetAllSkillsSearchText());
            context.SaveChanges();
            var sut = new SkillRepository(context);
            string searchText = "c";
            //Skill newSkill = new Skill() { SkillId = 1, SkillName = "c++" };
            //Act
            var result = await sut.GetSkillsBySearchAsync(searchText);
            //Assert
            result.Should().HaveCount(SkillMockData.GetAllSkillsSearchText().Count);

        }





        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
