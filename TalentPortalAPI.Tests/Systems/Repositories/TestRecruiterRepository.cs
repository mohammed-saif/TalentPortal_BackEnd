using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RecruiterMicroserviceAPI.Data;
using RecruiterMicroserviceAPI.Models.Domain;
using RecruiterMicroserviceAPI.Repositories;
using RecruiterMicroserviceAPI.Tests.MockData;

namespace RecruiterMicroserviceAPI.Tests.Systems.Repositories
{
    public class TestRecruiterRepository : IDisposable
    {
        private readonly RecruiterDbContext recruiterDbContext;

        public TestRecruiterRepository()
        {
            var options = new DbContextOptionsBuilder<RecruiterDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            recruiterDbContext = new RecruiterDbContext(options);
            recruiterDbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllRecruiters_ShouldReturnAllRecruiters()
        {
            recruiterDbContext.Recruiters.AddRange(RecruitersMockData.AllRecruiters());
            recruiterDbContext.SaveChanges();

            var sut = new RecruiterRepository(recruiterDbContext);

            var result = await sut.GetAllRecruiters();

            result.GetType().Should().Be(typeof(List<Recruiter>));
        }

        [Fact]
        public async Task GetRecruiterByIdAsync_ShouldReturnRecruitersById()
        {
            recruiterDbContext.Recruiters.AddRange(RecruitersMockData.AllRecruiters());
            recruiterDbContext.SaveChanges();

            var sut = new RecruiterRepository(recruiterDbContext);

            var result = await sut.GetRecruiterByIdAsync(1);

            result.GetType().Should().Be(typeof(List<Recruiter>));
        }

        [Fact]
        public async Task AddRecruiter_ShouldReturnValidAddedRecruiter()
        {
            recruiterDbContext.Recruiters.AddRange(RecruitersMockData.AllRecruiters());
            recruiterDbContext.SaveChanges();

            var sut = new RecruiterRepository(recruiterDbContext);

            var result = await sut.AddRecruiter(RecruitersMockData.ValidRecruiter());

            result.GetType().Should().Be(typeof(Recruiter));

        }

        [Fact]
        public async Task AddRecruiter_ShouldReturnNullBecauseInvalidAddedRecruiter()
        {
            recruiterDbContext.Recruiters.AddRange(RecruitersMockData.AllRecruiters());
            recruiterDbContext.SaveChanges();

            var sut = new RecruiterRepository(recruiterDbContext);

            var result = await sut.AddRecruiter(RecruitersMockData.InvalidRecuiter());

            result.Should().Be(null);

        }

        [Fact]
        public async Task DeleteRecruiter_ShouldReturnDeletedRecruiter()
        {
            recruiterDbContext.Recruiters.AddRange(RecruitersMockData.AllRecruiters());
            recruiterDbContext.SaveChanges();

            var sut = new RecruiterRepository(recruiterDbContext);

            var result = await sut.DeleteRecruiter(RecruitersMockData.ValidRecruiterForDelete());

            result.GetType().Should().Be(typeof(Recruiter));
        }

        [Fact]
        public async Task DeleteRecruiter_ShouldReturnNullBecauseRecruiterTBDDoesNotExist()
        {
            recruiterDbContext.Recruiters.AddRange(RecruitersMockData.AllRecruiters());
            recruiterDbContext.SaveChanges();

            var sut = new RecruiterRepository(recruiterDbContext);

            var result = await sut.DeleteRecruiter(RecruitersMockData.InvalidRecruiterForDelete());

            result.Should().Be(null);
        }

        public void Dispose()
        {
            recruiterDbContext.Database.EnsureDeleted();
            recruiterDbContext.Dispose();
        }
    }
}
