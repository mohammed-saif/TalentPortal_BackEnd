using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecruiterMicroserviceAPI.Controllers;
using RecruiterMicroserviceAPI.Models.Domain;
using RecruiterMicroserviceAPI.Repositories.Interfaces;
using RecruiterMicroserviceAPI.Tests.MockData;

namespace RecruiterMicroserviceAPI.Tests.Systems.Controllers
{
    public class TestRecruiterController
    {
        [Fact]
        public async Task GetAllRecruiters_ShouldReturn200StatusCode()
        {
            // Arrange
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();

            recruiterRepository.Setup(x => x.GetAllRecruiters()).ReturnsAsync(RecruitersMockData.AllRecruiters());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);

            // Act
            var result = await sut.GetRecruiters();

            // Assert 
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetRecruiterByIdAsync_ShouldReturn200StatusCode()
        {
            // Arrange
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();
            var UserId = 1;

            recruiterRepository.Setup(x => x.GetRecruiterByIdAsync(UserId)).ReturnsAsync(RecruitersMockData.AllRecruiters());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);

            // Act
            var result = await sut.GetRecruiterByIdAsync(UserId);

            // Assert 
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetRecruiterByIdAsync_ShouldReturn204StatusCode()
        {
            // Arrange
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();
            var UserId = 1;

            recruiterRepository.Setup(x => x.GetRecruiterByIdAsync(UserId)).ReturnsAsync(RecruitersMockData.EmptyRecruitersList());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);

            // Act
            var result = await sut.GetRecruiterByIdAsync(UserId);

            // Assert 
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task GetAllRecruiters_ShouldReturn204StatusCode()
        {
            // Arrange 
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();

            recruiterRepository.Setup(x => x.GetAllRecruiters()).ReturnsAsync(RecruitersMockData.EmptyRecruitersList());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);

            // Act
            var result = await sut.GetRecruiters();

            // Assert 
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }

        [Fact]
        public async Task AddRecruiter_ShouldReturn200StatusCode()
        {
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();
            var recruiter = new Mock<Recruiter>();

            recruiterRepository.Setup(x => x.AddRecruiter(recruiter.Object)).ReturnsAsync(RecruitersMockData.ValidRecruiter());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);

            // Act
            var result = await sut.AddRecruiter(recruiter.Object);

            // Assert 
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task AddRecruiter_ShouldReturn400StatusCode()
        {
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();
            var recruiter = new Mock<Recruiter>();

            recruiterRepository.Setup(x => x.AddRecruiter(recruiter.Object)).ReturnsAsync(RecruitersMockData.InvalidRecuiter());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");

            // Act
            var result = await sut.AddRecruiter(recruiter.Object);

            // Assert 
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task AddRecruiter_ShouldReturn409StatusCode()
        {
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();
            var recruiter = new Mock<Recruiter>();

            recruiterRepository.Setup(x => x.AddRecruiter(recruiter.Object)).ReturnsAsync(RecruitersMockData.NullRecruiter());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);

            // Act
            var result = await sut.AddRecruiter(recruiter.Object);

            // Assert 
            result.GetType().Should().Be(typeof(ConflictResult));
            (result as ConflictResult).StatusCode.Should().Be(409);
        }

        [Fact]
        public async Task DeleteRecruiter_ShouldReturn200StatusCode()
        {
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();
            var recruiter = new Mock<Recruiter>();

            recruiterRepository.Setup(x => x.DeleteRecruiter(recruiter.Object)).ReturnsAsync(RecruitersMockData.ValidRecruiter());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);

            // Act
            var result = await sut.DeleteRecruiter(recruiter.Object);

            // Assert 
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact] 
        public async Task DeleteRecruiter_ShouldBe204StatusCode()
        {
            var recruiterRepository = new Mock<IRecruiterRepository>();
            var mapper = new Mock<IMapper>();
            var recruiter = new Mock<Recruiter>();

            recruiterRepository.Setup(x => x.DeleteRecruiter(recruiter.Object)).ReturnsAsync(RecruitersMockData.NullRecruiter());

            var sut = new RecruiterController(recruiterRepository.Object, mapper.Object);

            // Act
            var result = await sut.DeleteRecruiter(recruiter.Object);

            // Assert 
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
    }
}
