using AutoMapper;
using FluentAssertions;
using JobMicroserviceAPI.Controllers;
using JobMicroserviceAPI.Models.Domain;
using JobMicroserviceAPI.Repositories.Interfaces;
using JobMicroserviceAPI.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JobMicroserviceAPI.Tests.Systems.Controllers
{
    public  class TestJobController
    {
        [Fact]
        public async Task GetAllJobsAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();

            jobRepository.Setup(x => x.GetAllJobsAsync()).ReturnsAsync(JobsMockData.GetJobs());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetAllJobsAsync();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetAllJobsAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();

            jobRepository.Setup(x => x.GetAllJobsAsync()).ReturnsAsync(JobsMockData.EmptyJobsList());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetAllJobsAsync();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }

        [Fact]
        public async Task GetJobByIdAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();

            jobRepository.Setup(x => x.GetJobByIdAsync(1)).ReturnsAsync(JobsMockData.Job());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetJobByIdAsync(1);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetJobByIdAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();

            jobRepository.Setup(x => x.GetJobByIdAsync(1)).ReturnsAsync(JobsMockData.EmptyJob());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetJobByIdAsync(1);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }

        [Fact]
        public async Task GetJobsByIdListAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();
            var jobIdList = new Mock<List<int>>();

            jobRepository.Setup(x => x.GetJobsByIdListAsync(jobIdList.Object)).ReturnsAsync(JobsMockData.GetJobs());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetJobsByIdListAsync(jobIdList.Object);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetJobsByIdListAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();
            var jobIdList = new Mock<List<int>>();

            jobRepository.Setup(x => x.GetJobsByIdListAsync(jobIdList.Object)).ReturnsAsync(JobsMockData.EmptyJobsList());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetJobsByIdListAsync(jobIdList.Object);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }

        [Fact]
        public async Task GetJobsBySearchAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();

            jobRepository.Setup(x => x.GetJobsBySearchAsync(" ")).ReturnsAsync(JobsMockData.GetJobs());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetJobsBySearchAsync(" ");

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetJobsBySearchAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();

            jobRepository.Setup(x => x.GetJobsBySearchAsync(" ")).ReturnsAsync(JobsMockData.EmptyJobsList());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetJobsBySearchAsync(" ");

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }

        [Fact]
        public async Task PostJobAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();
            var job = new Mock<Job>();

            jobRepository.Setup(x => x.PostJobAsync(job.Object)).ReturnsAsync(JobsMockData.Job());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.PostJobAsync(job.Object);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task PostJobAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();
            var job = new Mock<Job>();


            var sut = new JobController(jobRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");

            //Act
            var result = await sut.PostJobAsync(job.Object);

            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);

        }

        [Fact]
        public async Task UpdateJobAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();
            var job = new Mock<Job>();

            jobRepository.Setup(x => x.UpdateJobAsync(1, job.Object)).ReturnsAsync(JobsMockData.Job());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.UpdateJobAsync(1, job.Object);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task UpdateJobAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();
            var job = new Mock<Job>();

            jobRepository.Setup(x => x.UpdateJobAsync(1, job.Object)).ReturnsAsync(JobsMockData.EmptyJob());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.UpdateJobAsync(1, job.Object);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task UpdateJobAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();
            var job = new Mock<Job>();


            var sut = new JobController(jobRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");

            //Act
            var result = await sut.UpdateJobAsync(1, job.Object);

            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);

        }

        [Fact]
        public async Task DeleteJobAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();

            jobRepository.Setup(x => x.DeleteJobAsync(1)).ReturnsAsync(JobsMockData.Job());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.DeleteJobAsync(1);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteJobAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var jobRepository = new Mock<IJobRepository>();
            var mapper = new Mock<IMapper>();

            jobRepository.Setup(x => x.DeleteJobAsync(1)).ReturnsAsync(JobsMockData.EmptyJob());

            var sut = new JobController(jobRepository.Object, mapper.Object);

            //Act
            var result = await sut.DeleteJobAsync(1);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
    }
}
