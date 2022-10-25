using FluentAssertions;
using JobApplicantMicroserviceAPI.Data;
using JobApplicantMicroserviceAPI.Models.Domain;
using JobApplicantMicroserviceAPI.Repository;
using JobApplicantMicroserviceAPI.Test.MockData;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace JobApplicantMicroserviceAPI.Test.Systems.Repository
{
    public class TestJobApplicantRepository : IDisposable
    {
        private readonly JobApplicantMicroserviceAPIDbContext context;
        public TestJobApplicantRepository()
        {
            var options = new DbContextOptionsBuilder<JobApplicantMicroserviceAPIDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new JobApplicantMicroserviceAPIDbContext(options);
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task DeleteJobApplicantAsync_ShouldReturnUser()
        {
            context.JobApplicants.AddRange(JobApplicantMockData.ValidJobApplicant());


            context.SaveChanges();
            var sut = new JobApplicantRepository(context);

            var result = await sut.DeleteJobApplicant(4,208);

            result.GetType().Should().Be(typeof(JobApplicant));
        }

        [Fact]
        public async Task FindApplicationStatusAsync_ShouldReturnJobApplicantStatus()
        {

            context.JobApplicants.AddRange(JobApplicantMockData.ValidJobApplicant());
            context.SaveChanges();
            var sut = new JobApplicantRepository(context);

            var result = await sut.FindApplicationStatus(4,208);

            result.Should().NotBeNull();
        }
        [Fact]
        public async Task ListAllJobApplicantsAsync_ShouldReturnJobApplicants()
        {
            context.JobApplicants.AddRange(JobApplicantMockData.ListAllJobApplicant());


            context.SaveChanges();
            var sut = new JobApplicantRepository(context);

            var result = await sut.ListAllJobApplicants();

            result.GetType().Should().Be(typeof(List<JobApplicant>));
        }
        public async Task ListApplicantJobsAsync_ShouldReturnJobApp()
        {
            context.JobApplicants.AddRange(JobApplicantMockData.ListAllJobApplicant());


            context.SaveChanges();
            var sut = new JobApplicantRepository(context);

            var result = await sut.ListApplicantJobs(4);

            result.GetType().Should().Be(typeof(JobApplicant));
        }

        [Fact]
        public async Task PostJobApplicationAsync_ShouldReturnUser()
        {
            context.JobApplicants.AddRange(JobApplicantMockData.ValidJobApplicant());


            context.SaveChanges();
            
            var sut = new JobApplicantRepository(context);
            var jobApplicant = new JobApplicant()
            {
                ApplicationStatus = "submitted",
                JobId = 301,
                UserId = 20
            };
            var result = await sut.PostJobApplication(jobApplicant);

            result.GetType().Should().Be(typeof(JobApplicant));
        }
  



        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
