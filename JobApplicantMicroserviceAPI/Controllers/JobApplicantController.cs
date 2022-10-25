using AutoMapper;
using JobApplicantMicroserviceAPI.Models.Domain;
using JobApplicantMicroserviceAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicantMicroserviceAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class JobApplicantController : ControllerBase
        {
            private readonly IJobApplicantRepository jobApplicantRepository;
            private readonly IMapper mapper;
            public JobApplicantController(IJobApplicantRepository _jobApplicantRepository, IMapper _mapper)
            {
                jobApplicantRepository = _jobApplicantRepository;
                mapper = _mapper;
            }

            /// <summary>
            /// api/talentportal
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public async Task<IActionResult> ListAllJobApplicantsAsync()
            {
                var jobapplicants = await jobApplicantRepository.ListAllJobApplicants();
                if (jobapplicants.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    var jobapplicantsDTO = mapper.Map<List<JobApplicantDTO>>(jobapplicants);
                    return Ok(jobapplicantsDTO);
                }
            }

            [HttpGet("ApplicationStatus")]
            [Authorize(Roles = "JobSeeker, Employer")]
            public async Task<IActionResult> FindAppStatusAsync(int userid, int jobid)
            {
                var allstatus = await jobApplicantRepository.FindApplicationStatus(userid, jobid);

                if (allstatus == null)
                {
                    return NoContent();
                }
                else
                {
                    var jobappDto = mapper.Map<JobApplicantDTO>(allstatus);

                    return Ok(jobappDto);
                }
            }

            [HttpGet("ListUserApplications")]
            [Authorize(Roles = "JobSeeker")]
            public async Task<IActionResult> ListappjobsAsync(int userid)
            {
                var allappjobs = await jobApplicantRepository.ListApplicantJobs(userid);
                if (allappjobs == null)
                {
                    return NoContent();
                }
                else
                {
                    var jobnameDto = mapper.Map<List<JobApplicantDTO>>(allappjobs);

                    return Ok(jobnameDto);
                }
            }

            [HttpPost]
            [Authorize(Roles = "JobSeeker")]
            public async Task<IActionResult> PostJobApp(JobApplicant jobapplicant)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var jobapp = await jobApplicantRepository.PostJobApplication(jobapplicant);
                    var jobappDTO = mapper.Map<JobApplicantDTO>(jobapp);

                    return Ok(jobappDTO);
                }
            }

            [HttpDelete]
            [Authorize(Roles = "JobSeeker")]
            public async Task<IActionResult> DeleteJobApp(int UserId, int JobId)
            {
                var ja = await jobApplicantRepository.DeleteJobApplicant(UserId, JobId);
                if (ja != null)
                {
                    return Ok(ja);
                }
                else
                {
                    return NoContent();
                }
            }

            [HttpPut("UpdateJobAppStatus")]
            [Authorize(Roles = "Employer")]
            public async Task<IActionResult> UpdateJobAppStatus(int UserId, int JobId, string newApplicationStatus)
            {
                var ja = await jobApplicantRepository.UpdateJobApplicationStatus(UserId, JobId, newApplicationStatus);
                if (ja != null)
                {
                    return Ok(ja);
                }
                else
                {
                // return NoContent();
                return BadRequest(ModelState);
                }
            }

            [HttpGet("ListApplicantsbyJobId")]
            public async Task<IActionResult> ListApplicantsbyJobId(int jobid)
            {
                var allapplicants = await jobApplicantRepository.ListApplicantsbyJobId(jobid);
                if (allapplicants == null)
                {
                    return NoContent();
                }
                else
                {
                    var appnameDto = mapper.Map<List<JobApplicantDTO>>(allapplicants);



                    return Ok(appnameDto);
                }
            }

            [HttpGet("ValidatingApplicant")]
            [Authorize(Roles = "JobSeeker")]
            public async Task<IActionResult> ValidatingApplicant(int UserId, int JobId)
            {
                var applicant = await jobApplicantRepository.ValidatingApplicant(UserId, JobId);
                if(applicant == null)
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }

            }
    }
}
