using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using UserMicroserviceAPI.Data;
using UserMicroserviceAPI.Repositories;
using UserMicroserviceAPI.Repository;
using UserMicroserviceAPI.Services;
using UserMicroserviceAPI.Tests.MockData;

namespace UserMicroserviceAPI.Tests.Systems.Repositories
{
    public class TestJwtAuthenticationManager : IDisposable
    {
        private readonly UserDbContext context;
       
        public TestJwtAuthenticationManager()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new UserDbContext(options);
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task Authenticate_ShouldReturnToken()
        {
            context.Users.AddRange(UserMockData.GetUsers());
            var userRepository = new Mock<UserRepository>(context);
            string key = Guid.NewGuid().ToString();
            context.SaveChanges();
            var sut = new JwtAuthenticationManager(userRepository.Object, key);

            var result = sut.Authenticate("Smr66", "smrbb33@9");

            result.GetType().Should().Be(typeof(String));
        }
        [Fact]
        public async Task Authenticate_ShouldReturnNull()
        {
            context.Users.AddRange(UserMockData.GetUsers());
            var userRepository = new Mock<UserRepository>(context);
            string key = Guid.NewGuid().ToString();
            context.SaveChanges();
            var sut = new JwtAuthenticationManager(userRepository.Object, key);

            var result = sut.Authenticate("Smr", "smr33@9");

            result.Should().BeNull();
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
