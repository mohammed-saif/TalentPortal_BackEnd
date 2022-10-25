using AutoMapper;
using FluentAssertions;
using JobApplicantMicroserviceAPI.Controllers;
using JobApplicantMicroserviceAPI.Models.Domain;
using JobApplicantMicroserviceAPI.Repository;
using JobApplicantMicroserviceAPI.Test.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicantMicroserviceAPI.Test.Systems.Controllers
{
    public class TestJobApplicantController
    {
        [Fact]
        public async Task ListAllJobApplicantsAsync_Shouldreturn200StatusCode()
        { 

            var jobApplicantRepository = new Mock<IJobApplicantRepository>();

            var _mapper = new Mock<IMapper>();
            //JobApplicant jobApplicant = JobApplicantMockData.ListAllJobApplicants();
            jobApplicantRepository.Setup(x => x.ListAllJobApplicants()).ReturnsAsync(JobApplicantMockData.ListAllJobApplicant());
            var sut = new JobApplicantController(jobApplicantRepository.Object, _mapper.Object);
            var result = await sut.ListAllJobApplicantsAsync();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task ListAllJobApplicants_ShouldReturn204StatusCode()
        {
            var jobApplicantRepository = new Mock<IJobApplicantRepository>();
            var mapper = new Mock<IMapper>();

            jobApplicantRepository.Setup(x => x.ListAllJobApplicants()).ReturnsAsync(JobApplicantMockData.EmptyJobApplicantList());

            var sut = new JobApplicantController(jobApplicantRepository.Object, mapper.Object);

            var result = await sut.ListAllJobApplicantsAsync();

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task DeleteJobAppAsync_ShouldReturn200StatusCode()
        {
            var JobApplicantRepository = new Mock<IJobApplicantRepository>();
            var mapper = new Mock<IMapper>();
           // var jwtAuthenticationManager = new Mock<IJwtAuthenticationManager>();

            JobApplicantRepository.Setup(x => x.DeleteJobApplicant(4,208)).ReturnsAsync(JobApplicantMockData.ValidJobApplicant());

            var sut = new JobApplicantController(JobApplicantRepository.Object, mapper.Object);

            var result = await sut.DeleteJobApp(4,208);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
    
        public async Task DeleteJobAppAsync_ShouldReturn204StatusCode()
        {
            var jobApplicantRepository = new Mock<IJobApplicantRepository>();
            var mapper = new Mock<IMapper>();
            //var jwtAuthenticationManager = new Mock<IJwtAuthenticationManager>();

            jobApplicantRepository.Setup(x => x.DeleteJobApplicant(3,208)).ReturnsAsync(JobApplicantMockData.EmptyJobApplicant());

            var sut = new JobApplicantController(jobApplicantRepository.Object, mapper.Object);

            var result = await sut.DeleteJobApp(3,208);

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task UpdateJobAppStatusAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var jobApplicantRepository = new Mock<IJobApplicantRepository>();
            var _mapper = new Mock<IMapper>();
            JobApplicant jobApppliant = JobApplicantMockData.ValidJobApplicant();
            jobApplicantRepository.Setup(x => x.UpdateJobApplicationStatus(4,208,"rejected")).ReturnsAsync(JobApplicantMockData.ValidJobApplicant());
            var sut = new JobApplicantController(jobApplicantRepository.Object, _mapper.Object);
            //Act
            var result = await sut.UpdateJobAppStatus(4,208,"rejected");
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task UpdateJobAppStatusAsync_ShouldReturn400StatusCode()
         {
             var jobApplicantRepository = new Mock<IJobApplicantRepository>();
             var _mapper = new Mock<IMapper>();
             JobApplicant question = JobApplicantMockData.ValidJobApplicant();
             jobApplicantRepository.Setup(x => x.UpdateJobApplicationStatus(4,208,"submitted")).ReturnsAsync(JobApplicantMockData.EmptyJobApplicant());
             var sut = new JobApplicantController(jobApplicantRepository.Object, _mapper.Object);
             sut.ModelState.AddModelError("Error", "BadRequest");
             //Act
             var result = await sut.UpdateJobAppStatus(4,208,"submitted");
             //Assert
             result.GetType().Should().Be(typeof(BadRequestObjectResult));
             (result as BadRequestObjectResult).StatusCode.Should().Be(400);
         }

        [Fact]
        public async Task PostJobAppAsync_ShouldReturn200StatusCode()
        {
            var jobApplicantRepository = new Mock<IJobApplicantRepository>();
            var mapper = new Mock<IMapper>();
            //var jwtAuthenticationManager = new Mock<IJwtAuthenticationManager>();
            var user = JobApplicantMockData.ValidJobApplicant();
            jobApplicantRepository.Setup(x => x.PostJobApplication(user)).ReturnsAsync(JobApplicantMockData.ValidJobApplicant());

            var sut = new JobApplicantController(jobApplicantRepository.Object, mapper.Object);

            var result = await sut.PostJobApp(user);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task PostJobAppAsync_ShouldReturn400StatusCode()
        {
            var JobApplicantRepository = new Mock<IJobApplicantRepository>();
            var mapper = new Mock<IMapper>();
           // var jwtAuthenticationManager = new Mock<IJwtAuthenticationManager>();
            var user = JobApplicantMockData.ValidJobApplicant();

            var sut = new JobApplicantController(JobApplicantRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("key", "bad request");

            var result = await sut.PostJobApp(user);

            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task ListappjobsAsync_ShouldReturn200StatusCode()
        {
            var jobApplicantRepository = new Mock<IJobApplicantRepository>();
            var mapper = new Mock<IMapper>();
            //var jwtAuthenticationManager = new Mock<IJwtAuthenticationManager>();

            jobApplicantRepository.Setup(x => x.ListApplicantJobs(3)).ReturnsAsync(JobApplicantMockData.ListAllJobApplicant());

            var sut = new JobApplicantController(jobApplicantRepository.Object, mapper.Object);

            var result = await sut.ListappjobsAsync(3);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
         public async Task ListappjobsAsync_ShouldReturn204StatusCode()
         {
             var jobApplicantRepository = new Mock<IJobApplicantRepository>();
             var mapper = new Mock<IMapper>();
             //var jwtAuthenticationManager = new Mock<IJwtAuthenticationManager>();

             jobApplicantRepository.Setup(x => x.ListApplicantJobs(1)).ReturnsAsync(JobApplicantMockData.EmptyJobApplicantJobList());

             var sut = new JobApplicantController(jobApplicantRepository.Object, mapper.Object);

             var result = await sut.ListappjobsAsync(1);

             result.GetType().Should().Be(typeof(NoContentResult));
             (result as NoContentResult).StatusCode.Should().Be(204);
         }

        [Fact]
        public async Task FindAppStatusAsync_ShouldReturn200StatusCode()
        {
            
             var jobApplicantRepository = new Mock<IJobApplicantRepository>();
             var mapper = new Mock<IMapper>();

            

             jobApplicantRepository.Setup(x => x.FindApplicationStatus(4,208)).ReturnsAsync(JobApplicantMockData.ValidJobApplicant());

             var sut = new JobApplicantController(jobApplicantRepository.Object, mapper.Object);

             var result = await sut.FindAppStatusAsync(4,208);

             result.GetType().Should().Be(typeof(OkObjectResult));
             (result as OkObjectResult).StatusCode.Should().Be(200); 
        }

        [Fact]
        public async Task FindAppStatusAsync_ShouldReturn204StatusCode()
        {
            var jobApplicantRepository = new Mock<IJobApplicantRepository>();
            var mapper = new Mock<IMapper>();

            jobApplicantRepository.Setup(x => x.FindApplicationStatus(1,208)).ReturnsAsync(JobApplicantMockData.EmptyJobApplicant());

            var sut = new JobApplicantController(jobApplicantRepository.Object, mapper.Object);

            var result = await sut.FindAppStatusAsync(1,208);

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
    }
}
