using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSkillMicroservice.Tests.MockData;
using UserSkillMicroserviceAPI.Controllers;
using UserSkillMicroserviceAPI.Models.Domain;
using UserSkillMicroserviceAPI.Repositories.Interfaces;

namespace UserSkillMicroservice.Tests.Systems.Controller
{
    public class TestUserSkillController
    {

        [Fact]
        public async Task GetUserSkill_ShouldReturn200StatusCode()
        {
            //Arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();
            var mapper = new Mock<IMapper>();
            userSkillRepository.Setup(x => x.ListAllUserSkills()).ReturnsAsync
                (UserSkillMockData.GetUserSkills());
            var sut = new UserSkillController(userSkillRepository.Object, mapper.Object);

            //Act
             var  result  = await sut.GetAllUserSkills();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetUserSkill_ShouldReturn204StatusCode()
        {
            //Arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();
            var mapper = new Mock<IMapper>();
            userSkillRepository.Setup(x => x.ListAllUserSkills()).ReturnsAsync
                (UserSkillMockData.GetEmpty());
            var sut = new UserSkillController(userSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetAllUserSkills();
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }

        [Fact]

        public async Task InsertUserSkill_ShouldReturn201StatusCode()
        {
            //Arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();
            var mapper = new Mock<IMapper>();
            var userSkill = new Mock<UserSkill>();



            userSkillRepository.Setup(x => x.AddUserSkill(userSkill.Object)).ReturnsAsync(UserSkillMockData.UserSkill());
            var sut = new UserSkillController(userSkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.InsertUserSkill(userSkill.Object);

            //Assert

            result.GetType().Should().Be(typeof(CreatedResult));
            (result as CreatedResult).StatusCode.Should().Be(201);
        }


        [Fact]
        public async Task InsertUserSkill_ShouldReturn400StatusCode()
        {//Arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();
            var mapper = new Mock<IMapper>();
            var userSkill = new Mock<UserSkill>();
            var sut = new UserSkillController(userSkillRepository.Object, mapper.Object);

            sut.ModelState.AddModelError("somestring", "error message");

            //Act
            var result = await sut.InsertUserSkill(userSkill.Object);

            //Assert

            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);

        }






        [Fact]

        public async Task DeleteUserSkill_ShouldReturn200StatusCode()
        {//Arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();
            var mapper = new Mock<IMapper>();
            int skillId = 1;
            int userId = 2;
            userSkillRepository.Setup(x => x.DeleteUserSkill(skillId, userId)).ReturnsAsync(UserSkillMockData.UserSkill());
            var sut = new UserSkillController(userSkillRepository.Object, mapper.Object);

            //Act
            var result = await sut.RemoveUserSkill(skillId, userId);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }




        [Fact]
        public async Task DeleteUserSkill_ShouldReturn204StatusCode()
        {
            //arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();
            var mapper = new Mock<IMapper>();
            int skillId = 1;
            int userId = 2;
            userSkillRepository.Setup(x => x.DeleteUserSkill(skillId, userId)).ReturnsAsync(UserSkillMockData.EmptyUserSkill());
            var sut = new UserSkillController(userSkillRepository.Object, mapper.Object);
            //Act

            var result = await sut.RemoveUserSkill(skillId, userId);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);


        }

        [Fact]

        public async Task GetUserSkillbyId_ShouldReturn200StatusCode()
        {
            //Arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();
            var mapper = new Mock<IMapper>();
            int userId = 1;
            userSkillRepository.Setup(x => x.GetUserSkillById(userId)).ReturnsAsync(UserSkillMockData.GetUserSkills()); //x.GetUserSkillById(userId))
            var sut = new UserSkillController(userSkillRepository.Object, mapper.Object);

            //Act

            var result = await sut.GetUserSkillById(userId);

            //Assert

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetUserSkillbyId_ShouldReturn204StatusCode()
        {
            //Arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();
            var mapper = new Mock<IMapper>();
            int userId = 1;
            userSkillRepository.Setup(x => x.GetUserSkillById(userId)).ReturnsAsync(UserSkillMockData.GetEmpty());
            var sut = new UserSkillController(userSkillRepository.Object, mapper.Object);

            //Act

            var result = await sut.GetUserSkillById(userId);

            //Assert

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);





        }

    }
}
