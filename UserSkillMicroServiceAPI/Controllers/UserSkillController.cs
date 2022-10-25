using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserSkillMicroserviceAPI.Models.Domain;
using UserSkillMicroserviceAPI.Models.DTO;
using UserSkillMicroserviceAPI.Repositories.Interfaces;

namespace UserSkillMicroserviceAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillRepository userSkillRepository;
        private readonly IMapper mapper;
        public UserSkillController(IUserSkillRepository _userSkillRepository, IMapper _mapper)
        {
            userSkillRepository = _userSkillRepository;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserSkills()
        {
            var userskilllist = await userSkillRepository.ListAllUserSkills();

            if (userskilllist.Count() == 0)

                return NoContent();
            var userskilllistDto = mapper.Map<List<UserSkillDTO>>(userskilllist);

            return Ok(userskilllistDto);
        }

        [HttpGet("userid")]
        [Authorize(Roles = "JobSeeker, Employer")]
        // public async Task<IActionResult> GetUserSkillById(int userid)
        public async Task<IActionResult> GetUserSkillById(int userid)
        {
            var userskill = await userSkillRepository.GetUserSkillById(userid);
            if (userskill.Count()==0)
                return NoContent();
            else
            {
                var userskillDto = mapper.Map<List<UserSkillDTO>>(userskill);
                return Ok(userskillDto);
            }
        }

        [HttpPost]
        [Authorize(Roles = "JobSeeker")]
        public async Task<IActionResult> InsertUserSkill(UserSkill userskill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var newuserskill = await userSkillRepository.AddUserSkill(userskill);
                var newuserskillDto = mapper.Map<UserSkillDTO>(newuserskill);
                return Created("succesfull", newuserskillDto);
            }
        }
        [HttpDelete]
        [Authorize(Roles = "JobSeeker")]
        public async Task<IActionResult> RemoveUserSkill(int skillId, int userId)
        {
            var deleteduserskill = await userSkillRepository.DeleteUserSkill(skillId, userId);
            if (deleteduserskill == null)
                return NoContent();
            else
            {
                var deleteduserskillDto = mapper.Map<UserSkillDTO>(deleteduserskill);
                return Ok(deleteduserskillDto);
            }
        }


    }
}
