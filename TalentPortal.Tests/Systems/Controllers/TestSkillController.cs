using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SkillAPI.Models.Domain;
using SkillMicroserviceAPI.Controllers;
using SkillMicroserviceAPI.Repositories.Interfaces;
using TalentPortal.Tests.MockData;

namespace TalentPortal.Tests.Systems.Controllers
{
    public class TestSkillController
    {
        //get skills
        [Fact]
        public async Task GetSkills_ShouldBeStatusCode200()
        {
            //Arrange
            var SkillRepository = new Mock<ISkillRepository>();//your i repo name
            var mapper = new Mock<IMapper>();
            //if you have any parameter passing in controller u should addd it here....
            //if the paramete is integer initialize it as 1,if it is string initialize it as any name of skill.
            SkillRepository.Setup(x => x.ListAllSkills()).ReturnsAsync(SkillMockData.GetAllSkills());//here get ListAllSkills is your repositories function name.....GetAllJobSkills is your mock data method name.
            var sut = new SkillController(SkillRepository.Object, mapper.Object);//make it sure that the repo object is your repository name

            //Act
            var result = await sut.GetSkills();//here ur controller name,if the controller have any parameter u should pass it here also...just like u did it in repository name
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        //get skills
        [Fact]
        public async Task GetSkills_ShouldBeStatusCode204()
        {
           // Arrange
                var SkillRepository = new Mock<ISkillRepository>();
              var mapper = new Mock<IMapper>();
            //string searchText = "string";
            SkillRepository.Setup(x => x.ListAllSkills()).ReturnsAsync(SkillMockData.GetListedEmptySkills());
            var sut = new SkillController(SkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetSkills();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task GetSkillsBySearchSkill_ShouldBeStatusCode200()
        {
            // Arrange
            var SkillRepository = new Mock<ISkillRepository>();
            var mapper = new Mock<IMapper>();
            string searchText = "string";
            SkillRepository.Setup(x => x.GetSkillsBySearchAsync(searchText)).ReturnsAsync(SkillMockData.GetAllSkillsSearchText());
            var sut = new SkillController(SkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetSkillsBySearchSkill(searchText);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetSkillsBySearchSkill_ShouldBeStatusCode204()
        {
            // Arrange
            var SkillRepository = new Mock<ISkillRepository>();
            var mapper = new Mock<IMapper>();
            string searchText = "string ";
            SkillRepository.Setup(x => x.GetSkillsBySearchAsync( searchText)).ReturnsAsync(SkillMockData.GetListedEmptySkills());
            var sut = new SkillController(SkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetSkillsBySearchSkill(searchText);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }




        [Fact]
        public async Task PutSkill_ShouldBeStatusCode400()
        {
            // Arrange
            var SkillRepository = new Mock<ISkillRepository>();
            var mapper = new Mock<IMapper>();
            //string searchText = "string";
            var newSkill = new Mock<Skill>();
            //SkillRepository.Setup(x => x.AddSkill(null)).ReturnsAsync(SkillMockData.SingleSkills());
            var sut = new SkillController(SkillRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Error","Put input is invalid.");
            //Act
            var result = await sut.PutSkill(newSkill.Object);

            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task PutSkill_ShouldBeStatusCode200()
        {
            // Arrange
            var SkillRepository = new Mock<ISkillRepository>();
            var mapper = new Mock<IMapper>();
            Skill newSkill = new Skill() { SkillId = 1, SkillName = "c++" };
            SkillRepository.Setup(x => x.AddSkill(newSkill)).ReturnsAsync(SkillMockData.SingleSkills());
            var sut = new SkillController(SkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.PutSkill(newSkill);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task PutSkill_ShouldBeStatusCode204()
        {
            // Arrange
            var SkillRepository = new Mock<ISkillRepository>();
            var mapper = new Mock<IMapper>();
            Skill newSkill = new Skill() { SkillId = 1, SkillName = "c++" };
            SkillRepository.Setup(x => x.AddSkill(newSkill)).ReturnsAsync(SkillMockData.CompleteEmptySkill());
            var sut = new SkillController(SkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.PutSkill(newSkill);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }



        [Fact]
        public async Task DeleteSkill_ShouldBeStatusCode200()
        {
            // Arrange
            var SkillRepository = new Mock<ISkillRepository>();
            var mapper = new Mock<IMapper>();
            //Skill newSkill = new Skill() { SkillId = 1, SkillName = "c++" };
            int skillId = 1;
            SkillRepository.Setup(x => x.RemoveSkill(skillId)).ReturnsAsync(SkillMockData.SingleSkills());
            var sut = new SkillController(SkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.DeleteSkill(skillId);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DeleteSkill_ShouldBeStatusCode204()
        {
            // Arrange
            var SkillRepository = new Mock<ISkillRepository>();
            var mapper = new Mock<IMapper>();
            int skillId = 1;

            //Skill newSkill = new Skill() { SkillId = 1, SkillName = "c++" };
            SkillRepository.Setup(x => x.RemoveSkill(skillId)).ReturnsAsync(SkillMockData.CompleteEmptySkill());
            var sut = new SkillController(SkillRepository.Object, mapper.Object);
            //Act
            var result = await sut.DeleteSkill(skillId);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

    }
}
