using AutoMapper;
using FluentAssertions;
using JobSkillMicroserviceAPI.Tests.MockData;
using JobSkillMicroservicesAPI.Controllers;
using JobSkillMicroservicesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JobSkillMicroserviceAPI.Tests.Systems.Controllers
{
    public class TestJobSkillController
    {
        [Fact]
        public async Task GetAllJobSkills_ShouldBeStatusCode200()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            jobSkillRepository.Setup(x => x.GetAllJobSkills()).ReturnsAsync(JobSkillsMockData.GetAllJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetAllJobSkills();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetAllJobSkills_ShouldBeStatusCode204()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            //string searchText = "string";
            jobSkillRepository.Setup(x => x.GetAllJobSkills()).ReturnsAsync(JobSkillsMockData.GetListedEmptyJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetAllJobSkills();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task GetAllJobSkillsByJobId_ShouldBeStatusCode200()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int jobId = 1;
            jobSkillRepository.Setup(x => x.GetAllJobSkillsByJobId(jobId)).ReturnsAsync(JobSkillsMockData.GetAllJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetAllJobsById(jobId);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetAllJobSkillsByJobId_ShouldBeStatusCode204()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int jobId = 1;
            //string searchText = "string";
            jobSkillRepository.Setup(x => x.GetAllJobSkillsByJobId(jobId)).ReturnsAsync(JobSkillsMockData.GetListedEmptyJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetAllJobsById(jobId);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }








        [Fact]
        public async Task PostOrUpdateJobSkills_ShouldBeStatusCode200()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int jobId = 1;
            int skillId = 2;
            jobSkillRepository.Setup(x => x.PostOrUpdateJobSkill(jobId, skillId)).ReturnsAsync(JobSkillsMockData.SingleJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.PostOrUpdateJobSkills(jobId, skillId);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task PostOrUpdateJobSkills_ShouldBeStatusCode404()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int jobId = 1;
            int skillId = 2;
            jobSkillRepository.Setup(x => x.PostOrUpdateJobSkill(jobId, skillId)).ReturnsAsync(JobSkillsMockData.CompleteEmptyJobSkill());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.PostOrUpdateJobSkills(jobId, skillId);

            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }


        [Fact]
        public async Task DeleteAllJobSkills_ShouldBeStatusCode200()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;
            //string jobSkill = "skahdb";
            jobSkillRepository.Setup(x => x.DeleteAllJobSkills(id)).ReturnsAsync(JobSkillsMockData.GetAllJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.DeleteAllJobSkills(id);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DeleteAllJobSkills_ShouldBeStatusCode204()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;
            //string jobSkill = "skahdb";
            jobSkillRepository.Setup(x => x.DeleteAllJobSkills(id)).ReturnsAsync(JobSkillsMockData.GetListedEmptyJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.DeleteAllJobSkills(id);
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task DeleteJobSkill_ShouldBeStatusCode200()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int jobId = 1;
            int skillId = 2;
            //string jobSkill = "skahdb";
            jobSkillRepository.Setup(x => x.DeleteJobSkill(jobId,skillId)).ReturnsAsync(JobSkillsMockData.SingleJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.DeleteJobSkill(jobId,skillId);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DeleteJobSkill_ShouldBeStatusCode204()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int jobId = 1;
            int skillId = 2;
            jobSkillRepository.Setup(x => x.DeleteJobSkill(jobId,skillId)).ReturnsAsync(JobSkillsMockData.CompleteEmptyJobSkill());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.DeleteJobSkill(jobId,skillId);
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task UpdateSkillByJobIdAndSkillId_ShouldBeStatusCode200()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int jobId = 1;
            int skillId1 = 2;
            int skillId2 = 3;
            jobSkillRepository.Setup(x => x.UpdateJobSkill(jobId, skillId1,skillId2)).ReturnsAsync(JobSkillsMockData.SingleJobSkills());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.UpdateSkillByJobIdAndSkillId(jobId, skillId1,skillId2);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task UpdateSkillByJobIdAndSkillId_ShouldBeStatusCode404()
        {
            //Arrange
            var jobSkillRepository = new Mock<IJobSkillRepository>();
            var mapper = new Mock<IMapper>();
            int jobId = 1;
            int skillId1 = 2;
            int skillId2 = 3;
            jobSkillRepository.Setup(x => x.UpdateJobSkill(jobId, skillId1,skillId2)).ReturnsAsync(JobSkillsMockData.CompleteEmptyJobSkill());
            var sut = new JobSkillController(jobSkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.UpdateSkillByJobIdAndSkillId(jobId, skillId1,skillId2);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }




    }
}
