using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UserMicroserviceAPI.Data;
using UserMicroserviceAPI.Models.Domain;
using UserMicroserviceAPI.Repositories;
using UserMicroserviceAPI.Tests.MockData;

namespace UserMicroserviceAPI.Tests.Systems.Repositories
{
    public class TestUserRepository : IDisposable
    {
        private readonly UserDbContext context;
        public TestUserRepository()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new UserDbContext(options);
            context.Database.EnsureCreated();
        }


        [Fact]
        public async Task RegisterUserAsync_ShouldReturnUser()
        {
            context.Users.AddRange(UserMockData.GetUsers());


            context.SaveChanges();
            var sut = new UserRepository(context);

            var result = await sut.RegisterUserAsync(UserMockData.User());

            result.GetType().Should().Be(typeof(User));
        }

        [Fact]
        public async Task ReturnUserInformationAsync_ShouldReturnUser()
        {

            context.Users.AddRange(UserMockData.User());
            context.SaveChanges();
            var sut = new UserRepository(context);

            var result = await sut.ReturnUserInformationAsync(4);

            result.GetType().Should().Be(typeof(User));
        }

        [Fact]
        public async Task ReturnUserInformationAsync_ShouldReturnNull()
        {

            context.Users.AddRange(UserMockData.User());
            context.SaveChanges();
            var sut = new UserRepository(context);

            var result = await sut.ReturnUserInformationAsync(1);

            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldReturnUser()
        {
            context.Users.AddRange(UserMockData.GetUsers());


            context.SaveChanges();
            var sut = new UserRepository(context);

            var result = await sut.DeleteUserAsync(1);

            result.GetType().Should().Be(typeof(User));
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldReturnUser()
        {

            context.Users.AddRange(UserMockData.User());
            context.SaveChanges();
            var sut = new UserRepository(context);
            var newUser = UserMockData.NewUser();

            var result = await sut.UpdateUserAsync(4, newUser);

            result.GetType().Should().Be(typeof(User));
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldReturnNull()
        {

            context.Users.AddRange(UserMockData.User());
            context.SaveChanges();
            var sut = new UserRepository(context);
            var newUser = UserMockData.NewUser();

            var result = await sut.UpdateUserAsync(1, newUser);

            result.Should().BeNull();
        }

        [Fact]
        public async Task CheckUserNameAsync_ShouldReturnUserName()
        {

            context.Users.AddRange(UserMockData.User());
            context.SaveChanges();
            var sut = new UserRepository(context);
            var UserName = UserMockData.UserName();

            var result = await sut.CheckUserNameAsync(UserName);

            result.GetType().Should().Be(typeof(String));
        }

        [Fact]
        public async Task CheckUserNameAsync_ShouldReturnNull()
        {

            context.Users.AddRange(UserMockData.User());
            context.SaveChanges();
            var sut = new UserRepository(context);
            var UserName = "Smr766";

            var result = await sut.CheckUserNameAsync(UserName);

            result.Should().BeNull();
        }

        [Fact]
        public async Task ChangePasswordAsync_ShouldReturnString()
        {

            context.Users.AddRange(UserMockData.User());
            context.SaveChanges();
            var sut = new UserRepository(context);
            var password = "king@345";

            var result = await sut.ChangePasswordAsync(4, password);

            result.GetType().Should().Be(typeof(String));
        }

        [Fact]
        public async Task ChangePasswordAsync_ShouldReturnNull()
        {

            context.Users.AddRange(UserMockData.User());
            context.SaveChanges();
            var sut = new UserRepository(context);
            var password = "king@345";

            var result = await sut.ChangePasswordAsync(1, password);

            result.Should().BeNull();
        }

        [Fact]
        public async Task ListAllUsers_ShouldReturnCount()
        {
            context.Users.AddRange(UserMockData.GetUsers());


            context.SaveChanges();
            var sut = new UserRepository(context);

            var result = sut.GetAllUsers();

            result.GetType().Should().Be(typeof(List<User>));
        }

        public void Dispose()
        {

            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
