using AutoMapper;
using JwtAuyhenticationManager;
using JwtAuyhenticationManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserMicroserviceAPI.Models.Domain;
using UserMicroserviceAPI.Models.DTO;
using UserMicroserviceAPI.Repository;
using UserMicroserviceAPI.Services;

namespace UserMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly JwtTokenHandler jwtAuthenticationManager;
        public UserController(IUserRepository _userRepository, IMapper _mapper, JwtTokenHandler _jwtAuthenticationManager)
        {
            userRepository = _userRepository;
            mapper = _mapper;
            this.jwtAuthenticationManager = _jwtAuthenticationManager;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllUsers()
        {
            var users = await userRepository.ListAllUsers();
            if(users.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<List<UserDTO>>(users));
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUserAsync(User u)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (u.UserMiddleName != null)
                {
                    var uModel = new User()
                    {
                        UserFirstName = u.UserFirstName,
                        UserMiddleName = u.UserMiddleName,
                        UserLastName = u.UserLastName,
                        UserDOB = u.UserDOB,
                        Gender = u.Gender,
                        UserPhoneNumber = u.UserPhoneNumber,
                        //UserResume = u.UserResume,
                        //UserImg = u.UserImg,
                        UserAddress = u.UserAddress,
                        UserName = u.UserName,
                        EmailId = u.EmailId,
                        Password = u.Password,
                        Role = u.Role,
                    };
                    u = await userRepository.RegisterUserAsync(uModel);
                }
                else
                {
                    var uModel = new User()
                    {
                        UserFirstName = u.UserFirstName,
                        UserLastName = u.UserLastName,
                        UserDOB = u.UserDOB,
                        Gender = u.Gender,
                        UserPhoneNumber = u.UserPhoneNumber,
                        //UserResume = u.UserResume,
                        //UserImg = u.UserImg,
                        UserAddress = u.UserAddress,
                        UserName = u.UserName,
                        EmailId = u.EmailId,
                        Password = u.Password,
                        Role = u.Role
                    };
                    u = await userRepository.RegisterUserAsync(uModel);
                }
                var uDto = mapper.Map<UserDTO>(u);
                return Ok(uDto);
            }
        }

        [HttpPost("Authenticate")]
        public ActionResult<AuthenticationResponse> Authenticate([FromBody] AuthenticationRequest user) //model binding
        {
            var token = jwtAuthenticationManager.GenerateToken(user);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpGet("UserId")]
        [Authorize(Roles = "JobSeeker, Employer")]
        public async Task<IActionResult> ReturnUserInformationAsync(int uid)
        {
            var u = await userRepository.ReturnUserInformationAsync(uid);
            if (u == null)
            {
                return NoContent();
            }
            else
            {
                var uDto = mapper.Map<UserDTO>(u);

                return Ok(uDto);
            }
        }

        [HttpPut("UserId")]
        [Authorize(Roles = "JobSeeker, Employer")]
        public async Task<IActionResult> UpdateUserAsync(int uid, User user)
        {
            var u = await userRepository.UpdateUserAsync(uid, user);
            if (u == null)
            {
                return NoContent();
            }
            else
            {
                var uDto = mapper.Map<UserDTO>(u);

                return Ok(uDto);
            }
        }

        [HttpPut("ChangePassword")]
        [Authorize(Roles = "JobSeeker, Employer")]
        public async Task<IActionResult> ChangePasswordAsync(int uid, string password)
        {
            var u = await userRepository.ChangePasswordAsync(uid, password);
            if (u == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(u);
            }
        }

        [HttpDelete("UserId")]
        [Authorize(Roles = "JobSeeker, Employer")]
        public async Task<IActionResult> DeleteUserAsync(int uid)
        {
            var u = await userRepository.DeleteUserAsync(uid);
            if (u == null)
            {
                return NotFound();
            }
            var uDto = mapper.Map<UserDTO>(u);
            return Ok(uDto);
        }

        [HttpGet("UserNameCheck")]
        public async Task<IActionResult> CheckUserNameAsync(string UserName)
        {
            var check = await userRepository.CheckUserNameAsync(UserName);
            if (check != null)
            {
                return Ok(UserName);
            }
            else
            {
                return Conflict();
            }
        }
    }
}
