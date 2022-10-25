using AutoMapper;
using FluentAssertions;
using JwtAuyhenticationManager;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UserMicroserviceAPI.Controllers;
using UserMicroserviceAPI.Repository;
using UserMicroserviceAPI.Services;
using UserMicroserviceAPI.Tests.MockData;

namespace UserMicroserviceAPI.Tests.Systems.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async Task DeleteUserAsync_ShouldReturn200StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            userRepository.Setup(x => x.DeleteUserAsync(1)).ReturnsAsync(UserMockData.User());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.DeleteUserAsync(1);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldReturn404StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            userRepository.Setup(x => x.DeleteUserAsync(1)).ReturnsAsync(UserMockData.EmptyUser());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.DeleteUserAsync(1);

            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task ReturnUserInformationAsync_ShouldReturn200StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            userRepository.Setup(x => x.ReturnUserInformationAsync(3)).ReturnsAsync(UserMockData.User());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.ReturnUserInformationAsync(3);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task ReturnUserInformationAsync_ShouldReturn204StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            userRepository.Setup(x => x.ReturnUserInformationAsync(1)).ReturnsAsync(UserMockData.EmptyUser());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.ReturnUserInformationAsync(1);

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task RegisterUserAsync_ShouldReturn200StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();
            var user = UserMockData.User();
            userRepository.Setup(x => x.RegisterUserAsync(user)).ReturnsAsync(UserMockData.User());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.RegisterUserAsync(user);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task RegisterUserAsync_ShouldReturn400StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();
            var user = UserMockData.User();

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);
            sut.ModelState.AddModelError("key", "bad request");

            var result = await sut.RegisterUserAsync(user);

            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldReturn200StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            var newUser = UserMockData.NewUser();
            userRepository.Setup(x => x.UpdateUserAsync(3, newUser)).ReturnsAsync(UserMockData.User());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.UpdateUserAsync(3, newUser);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task UpdateUserAsync_ShouldReturn204StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            var newUser = UserMockData.NewUser();
            userRepository.Setup(x => x.UpdateUserAsync(3, newUser)).ReturnsAsync(UserMockData.EmptyUser());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.UpdateUserAsync(3, newUser);

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task CheckUserNameAsync_ShouldReturn409StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            var UserName = UserMockData.UserName();
            userRepository.Setup(x => x.CheckUserNameAsync(UserName)).ReturnsAsync(UserMockData.EmptyUserName());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.CheckUserNameAsync("kiran6");

            result.GetType().Should().Be(typeof(ConflictResult));
            (result as ConflictResult).StatusCode.Should().Be(409);
        }

        [Fact]
        public async Task CheckUserNameAsync_ShouldReturn200StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            var UserName = UserMockData.UserName();
            userRepository.Setup(x => x.CheckUserNameAsync(UserName)).ReturnsAsync(UserMockData.UserName());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.CheckUserNameAsync("kiran6");

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task ChangePasswordAsync_ShouldReturn200StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            var password = "king@345";
            userRepository.Setup(x => x.ChangePasswordAsync(3, password)).ReturnsAsync(UserMockData.PasswordChanged());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.ChangePasswordAsync(3, password);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task ChangePasswordAsync_ShouldReturn204StatusCode()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            var password = "king@345";
            userRepository.Setup(x => x.ChangePasswordAsync(3, password)).ReturnsAsync(UserMockData.NullPassword());

            var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

            var result = await sut.ChangePasswordAsync(3, password);

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        //[Fact]
        //public async Task Authenticate_ShouldReturn200StatusCode()
        //{
        //    var userRepository = new Mock<IUserRepository>();
        //    var mapper = new Mock<IMapper>();
        //    var jwtAuthenticationManager = new Mock<JwtTokenHandler>();
        //    jwtAuthenticationManager.Setup(x => x.Authenticate("Smr66", "smrbb33@9")).Returns(UserMockData.Token());

        //    var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

        //    var userLoginDetails = UserMockData.UserLoginDetails();
        //    var result = sut.Authenticate(userLoginDetails);

        //    result.GetType().Should().Be(typeof(OkObjectResult));
        //    (result as OkObjectResult).StatusCode.Should().Be(200);
        //}
        //[Fact]
        //public async Task Authenticate_ShouldReturn401StatusCode()
        //{
        //    var userRepository = new Mock<IUserRepository>();
        //    var mapper = new Mock<IMapper>();
        //    var jwtAuthenticationManager = new Mock<JwtTokenHandler>();
        //    jwtAuthenticationManager.Setup(x => x.Authenticate("Smr66", "smrbb33@9")).Returns(UserMockData.Token());

        //    var sut = new UserController(userRepository.Object, mapper.Object, jwtAuthenticationManager.Object);

        //    var userLoginDetails = UserMockData.EmptyUserLoginDetails();
        //    var result = sut.Authenticate(userLoginDetails);

        //    result.GetType().Should().Be(typeof(UnauthorizedResult));
        //    (result as UnauthorizedResult).StatusCode.Should().Be(401);
        //}
    }
}

