using FluentAssertions;
using JobSkillMicroserviceAPI.Repositories;
using JobSkillMicroserviceAPI.Tests.MockData;
using JobSkillMicroservicesAPI.Data;
using JobSkillMicroservicesAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobSkillMicroservicesAPI.Tests.Systems.Repositories
{
    public class TestJobSkillRepository:IDisposable
    {
    
        private readonly JobSkillDbContext context;
        public TestJobSkillRepository()
        {
            var options = new DbContextOptionsBuilder<JobSkillDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            context = new JobSkillDbContext(options);
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllJobSkills_ShouldReturnAllJobSkills()
        {
            //Arrange
            context.JobSkills.AddRange(JobSkillsMockData.GetAllJobSkills());
            context.SaveChanges();
            var sut = new JobSkillRepository(context);

            //Act
            var result = await sut.GetAllJobSkills();

            //Assert
            result.Should().HaveCount(JobSkillsMockData.GetAllJobSkills().Count);
        }







        [Fact]
        public async Task GetAllJobSkillsByJobid_ShouldReturnJobSkillsByJobId()
        {
            //Arrange
            context.JobSkills.AddRange(JobSkillsMockData.GetAllJobSkillsByJobId());
            context.SaveChanges();
            var sut = new JobSkillRepository(context);
            int id = 1;
            //Act
            var result = await sut.GetAllJobSkillsByJobId(id);

            //Assert
            result.Should().HaveCount(JobSkillsMockData.GetAllJobSkillsByJobId().Count);
            //result.GetType().Should().NotBeNull();
        }
        [Fact]
        public async Task PostOrUpdateJobSkill_ShouldReturnSingleJobSkill()
        {
            //Arrange
            context.JobSkills.AddRange(JobSkillsMockData.SingleJobSkills());
            context.SaveChanges();
            var sut = new JobSkillRepository(context);
            int id = 1;
            int skillId = 1;
            //Act
            var result = await sut.PostOrUpdateJobSkill(id,skillId);
            //JobSkill result = JobSkillsMockData.AddResult();

            //Assert
            result.Should().BeOfType<JobSkill>();
            //result.GetType().Should().NotBeNull();
        }
        [Fact]
        public async Task DeleteAllJobSkills_ShouldReturnAllDeletedSkills()
        {
            //Arrange
            context.JobSkills.AddRange(JobSkillsMockData.GetAllJobSkillsByJobId());
            context.SaveChanges();
            var sut = new JobSkillRepository(context);
            int id = 1;
            //Act
            var result = await sut.DeleteAllJobSkills(id);
            //JobSkill result = JobSkillsMockData.AddResult();

            //Assert
            result.Should().HaveCount(JobSkillsMockData.GetAllJobSkillsByJobId().Count);
            //result.GetType().Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteJobSkill_ShouldReturnAllDeleteSingleJob()
        {
            //Arrange
            context.JobSkills.AddRange(JobSkillsMockData.SingleJobSkills());
            context.SaveChanges();
            var sut = new JobSkillRepository(context);
            int id = 1;
            int skillId = 1;
            //Act
            var result = await sut.DeleteJobSkill(id,skillId);
            //JobSkill result = JobSkillsMockData.AddResult();

            //Assert
            result.Should().BeOfType<JobSkill>();
            //result.GetType().Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateJobSkill_ShouldReturnAllDeleteSingleJob()
        {
            //Arrange
            context.JobSkills.AddRange(JobSkillsMockData.SingleJobSkills());
            context.SaveChanges();
            var sut = new JobSkillRepository(context);
            int id = 1;
            int skillId = 1;
            int skillId2 = 2;
            //Act
            var result = await sut.UpdateJobSkill(id, skillId,skillId2);
            //JobSkill result = JobSkillsMockData.AddResult();

            //Assert
            result.Should().BeOfType<JobSkill>();
            //result.GetType().Should().NotBeNull();
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
