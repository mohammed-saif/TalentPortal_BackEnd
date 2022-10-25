using AutoMapper;
using FluentAssertions;
using JobMicroserviceAPI.Controllers;
using JobMicroserviceAPI.Data;
using JobMicroserviceAPI.Models.Domain;
using JobMicroserviceAPI.Repositories;
using JobMicroserviceAPI.Repositories.Interfaces;
using JobMicroserviceAPI.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace JobMicroserviceAPI.Tests.Systems.Repositories
{
    public class TestJobRepository : IDisposable
    {
        private readonly JobMicroserviceDbContext context;
        public TestJobRepository()
        {
            var options = new DbContextOptionsBuilder<JobMicroserviceDbContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            context = new JobMicroserviceDbContext(options);
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllJobsAsync_ShouldReturnJobsList()
        {
            //Arrange
            context.Jobs.AddRange(JobsMockData.GetJobs());
            context.SaveChanges();
            var sut = new JobRepository(context);

            //Act
            var result = await sut.GetAllJobsAsync();

            //Assert
            result.GetType().Should().Be(typeof(List<Job>));    
        }

        [Fact]
        public async Task GetJobByIdAsync_ShouldReturnJob()
        {
            //Arrange
            context.Jobs.AddRange(JobsMockData.GetJobs());
            context.SaveChanges();
            var sut = new JobRepository(context);

            //Act
            var result = await sut.GetJobByIdAsync(1);

            //Assert
            result.GetType().Should().Be(typeof(Job));
        }

        [Fact]
        public async Task GetJobsByIdListAsync_ShouldReturnJobsList()
        {
            //Arrange
            context.Jobs.AddRange(JobsMockData.GetJobs());
            context.SaveChanges();
            var sut = new JobRepository(context);
            var x = new List<int> { 1,2,3};
            //Act
            var result = await sut.GetJobsByIdListAsync(x);

            //Assert
            result.GetType().Should().Be(typeof(List<Job>));
        }

        [Fact]
        public async Task GetJobsBySearchAsync_ShouldReturnJobsList()
        {
            //Arrange
            context.Jobs.AddRange(JobsMockData.GetJobs());
            context.SaveChanges();
            var sut = new JobRepository(context);

            //Act
            var result = await sut.GetJobsBySearchAsync(" ");

            //Assert
            result.GetType().Should().Be(typeof(List<Job>));
        }

        [Fact]
        public async Task PostJobAsync_ShouldReturnJob()
        {
            //Arrange
            context.Jobs.AddRange(JobsMockData.GetJobs());
            context.SaveChanges();
            var sut = new JobRepository(context);
            var job = new Job()
            {
                CompanyName = "exalture",
                JobDescription = "hr required",
                JobLocation = "infopark kochi",
                JobName = "HR",
                JobType = "Full-time"
            };
            //Act
            var result = await sut.PostJobAsync(job);

            //Assert
            result.GetType().Should().Be(typeof(Job));
        }

        [Fact]
        public async Task UpdateJobAsync_ShouldReturnJob()
        {
            //Arrange
            context.Jobs.AddRange(JobsMockData.GetJobs());
            context.SaveChanges();
            var sut = new JobRepository(context);
            var job = new Job()
            {
                CompanyName = "exalture",
                JobDescription = "hr required",
                JobLocation = "infopark kochi",
                JobName = "HR",
                JobType = "Full-time"
            };
            //Act
            var result = await sut.UpdateJobAsync(9,job);

            //Assert
            result.GetType().Should().Be(typeof(Job));
        }

        [Fact]
        public async Task DeleteJobAsync_ShouldReturnJob()
        {
            //Arrange
            context.Jobs.AddRange(JobsMockData.GetJobs());
            context.SaveChanges();
            var sut = new JobRepository(context);
            
            //Act
            var result = await sut.DeleteJobAsync(2);

            //Assert
            result.GetType().Should().Be(typeof(Job));
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
