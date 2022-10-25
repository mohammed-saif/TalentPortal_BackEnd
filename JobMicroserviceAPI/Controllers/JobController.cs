using System.Data;
using AutoMapper;
using JobMicroserviceAPI.Models.Domain;
using JobMicroserviceAPI.Models.DTO;
using JobMicroserviceAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public JobController(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobsAsync()
        {
            var jobs = await jobRepository.GetAllJobsAsync();
            if(jobs.Count() == 0)
            {
                return NoContent();
            }

            var jobsDto = mapper.Map<List<JobDto>>(jobs);
            return Ok(jobsDto);

        }

        [HttpGet("jobId")]
        public async Task<IActionResult> GetJobByIdAsync(int jobId)
        {
            var job = await jobRepository.GetJobByIdAsync(jobId);
            if(job == null)
            {
                return NoContent();
            }

            var jobDto = mapper.Map<JobDto>(job);
            return Ok(jobDto);
        }


        [HttpGet("jobIdList")]
        [Authorize(Roles = "JobSeeker, Employer")]
        public async Task<IActionResult> GetJobsByIdListAsync([FromHeader] List<int> jobIdList)
        {
            var jobs = await jobRepository.GetJobsByIdListAsync(jobIdList);

            if(jobs.Count() == 0)
            {
                return NoContent();
            }
            var jobsDto = mapper.Map<List<JobDto>>(jobs);
            return Ok(jobsDto);
        }

        [HttpGet("searchText")]
        public async Task<IActionResult> GetJobsBySearchAsync(string searchText)
        {
            var jobs = await jobRepository.GetJobsBySearchAsync(searchText);
            if(jobs.Count()==0)
            {
                return NoContent();
            }
            var jobsDto = mapper.Map<List<JobDto>>(jobs);
            return Ok(jobsDto);
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> PostJobAsync( Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var newJob = await jobRepository.PostJobAsync(job);
                var newJobDTO = mapper.Map<JobDto>(job);

                return Ok(newJobDTO); 

            }
        }

        [HttpPut("jobId")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> UpdateJobAsync(int jobId, Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var daJob = await jobRepository.UpdateJobAsync(jobId, job);

            if (daJob == null)
            {
                return NoContent(); 
            }
            else
            {

                var daJobDTO = mapper.Map<JobDto>(daJob);

                return Ok(daJobDTO);
            }

        }

        [HttpDelete("jobId")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeleteJobAsync(int jobId)
        {
            var job = await jobRepository.DeleteJobAsync(jobId);
            if (job == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(job);
            }
        }

    }
}
