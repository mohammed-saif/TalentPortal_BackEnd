using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillAPI.Models.Domain;
using SkillMicroserviceAPI.Models.DTO;
using SkillMicroserviceAPI.Repositories.Interfaces;

namespace SkillMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    { 
        private readonly ISkillRepository skillRepository;
        private readonly IMapper mapper;
        public SkillController(ISkillRepository _skillRepository, IMapper _mapper)
        {
            skillRepository = _skillRepository;
            mapper = _mapper;
        }
        //api/skill
        [HttpGet]
        public async Task<IActionResult> GetSkills()//1st name
        {

            var skills = await skillRepository.ListAllSkills();
            if (skills.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<List<SkillDto>>(skills));
            }
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetSkillByIdAsync(int SkillId)
        {
            var skill = await skillRepository.GetSkillByIdAsync(SkillId); 
            if(skill == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<SkillDto>(skill));
            }
        }

        //api/skill/{SkillName}
        [HttpGet("GetSkillSBySkillName")]
        [Authorize(Roles = "JobSeeker, Employer")]
        //[HttpGet("{id:int}")]
        public async Task<IActionResult> GetSkillsBySearchSkill(string searchText)//2nd
        {
            var skills = await skillRepository.GetSkillsBySearchAsync(searchText);//irepoaiyil njmmlde function nte name wit parameter.....parameternte daya typedkkandaaa
            if (skills.Count()==0)
            {
                return NoContent();
            }
            else
            {
                var skillsBySearch = mapper.Map<List<SkillDto>>(skills);
                return Ok(skillsBySearch);
            }
        }

        //api/Skill
        [HttpPost]
        public async Task<IActionResult> PutSkill(Skill skill)//3rd name
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sk = await skillRepository.AddSkill(skill);

            if (sk == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<SkillDto>(sk));

            }
        }
        //api/skill/{SkillId}
        [HttpDelete]
        public async Task<IActionResult> DeleteSkill(int SkillId)//4th name
        {
            var sk = await skillRepository.RemoveSkill(SkillId);

            if (sk == null)
            {
                return NoContent();
            }
            else
            {

                return Ok(mapper?.Map<SkillDto>(sk));
            }

        }
    }
}
