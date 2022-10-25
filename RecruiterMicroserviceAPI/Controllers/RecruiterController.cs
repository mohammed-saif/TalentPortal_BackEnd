using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruiterMicroserviceAPI.Models.Domain;
using RecruiterMicroserviceAPI.Models.DTO;
using RecruiterMicroserviceAPI.Repositories.Interfaces;

namespace RecruiterMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterRepository recruiterRepository;
        private readonly IMapper mapper;
        public RecruiterController(IRecruiterRepository _recruiterRepository, IMapper _mapper)
        {
            recruiterRepository = _recruiterRepository;
            mapper = _mapper;
        }

        // /api/Recruiter
        [HttpGet]
        public async Task<IActionResult> GetRecruiters()
        {
            var rec = await recruiterRepository.GetAllRecruiters();
            if (rec.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<List<RecruiterDTO>>(rec));

            }
        }

        [HttpGet("Id")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetRecruiterByIdAsync(int UserId)
        {
            var rec = await recruiterRepository.GetRecruiterByIdAsync(UserId);
            if(rec.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<List<RecruiterDTO>>(rec));
            }
        }

        // /api/Recruiter
        [HttpPost]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> AddRecruiter(Recruiter recruiter)
        {
            var rec = await recruiterRepository.AddRecruiter(recruiter);
            if(!ModelState.IsValid)
            {
                return BadRequest(rec);
            }
            if (rec == null)
            {
                return Conflict();
            }
            else
            {

                var recDTO = mapper.Map<RecruiterDTO>(recruiter);

                return Ok(recDTO);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeleteRecruiter(Recruiter recruiter)
        {
            var rec = await recruiterRepository.DeleteRecruiter(recruiter);
            if (rec == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<RecruiterDTO>(rec));
            }

        }
    }
}
