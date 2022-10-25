using System.Data;
using AutoMapper;
using JobSkillMicroservicesAPI.Models.DTO;
using JobSkillMicroservicesAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSkillMicroservicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSkillController : ControllerBase
    {
        private readonly IJobSkillRepository jobSkillRepository;
        private readonly IMapper mapper;
        public JobSkillController(IJobSkillRepository _jobSkillRepository, IMapper _mapper)
        {
            jobSkillRepository = _jobSkillRepository;
            mapper = _mapper;
        }
        //api/jobskill
        [HttpGet]
        public async Task<IActionResult> GetAllJobSkills()
        {
            var jobSkills = await jobSkillRepository.GetAllJobSkills();
            if (jobSkills.Count()==0)
            {
                return NoContent();
            }
            var jobSkillsDTO = mapper.Map<List<JobSkillDto>>(jobSkills);
            return Ok(jobSkillsDTO);
        }

        //api/jobskill/id
        [HttpGet("GetByJobId")]
        public async Task<IActionResult> GetAllJobsById(int jobId)
        {

            var jobSkills = await jobSkillRepository.GetAllJobSkillsByJobId(jobId);
            if (jobSkills.Count()== 0)
            {
                return NoContent();
            }
            var jobSkillsDTO = mapper.Map<List<JobSkillDto>>(jobSkills);
            return Ok(jobSkillsDTO);
        }

        //api/jobskill
        [HttpPost]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> PostOrUpdateJobSkills(int jobId, int skillId)
        {
            var jobSkill = await jobSkillRepository.PostOrUpdateJobSkill(jobId, skillId);
            if (jobSkill == null)
            {
                return NotFound();
            }
            var jobSkillDTO = mapper.Map<JobSkillDto>(jobSkill);

            return Ok(jobSkillDTO);
        }

        //api/jobskill/id
        [HttpDelete]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeleteAllJobSkills(int JobId)
        {
            var jobSkills = await jobSkillRepository.DeleteAllJobSkills(JobId);

            if (jobSkills.Count()==0)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<List<JobSkillDto>>(jobSkills));
            }
        }

        //api/jobskill/jobid/skillId
        [HttpDelete("DeleteSingleSkillByJobId")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeleteJobSkill(int jobId, int skillId)
        {
            Console.WriteLine("in single delete");
            var jobskill = await jobSkillRepository.DeleteJobSkill(jobId, skillId);
            Console.WriteLine("hey");
            if (jobskill == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<JobSkillDto>(jobskill));
            }
        }

        //api/jobskill
        [HttpPut("UpdatingSkill")]
        public async Task<IActionResult> UpdateSkillByJobIdAndSkillId(int jobId,int skillId1,int skillId2)
        {
            var newSkill= await jobSkillRepository.UpdateJobSkill(jobId, skillId1,skillId2);
            Console.WriteLine("hey");

            if (newSkill == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(newSkill);
            }
        }


    }
}
