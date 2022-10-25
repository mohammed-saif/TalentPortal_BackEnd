
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserMicroserviceAPI.Models.Domain;
using UserMicroserviceAPI.Repository;

namespace UserMicroserviceAPI.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key;
        private readonly IUserRepository userRepository;
        public JwtAuthenticationManager(IUserRepository _userRepository, string _key)
        {
            userRepository = _userRepository;
            key = _key;
        }
        public string Authenticate(string username, string password)
        {
            var users = userRepository.GetAllUsers();
            var userList = new List<UserLoginDetails>();
            foreach (var x in users)
            {
                userList.Add(new UserLoginDetails { UserName = x.UserName, Password = x.Password });
            }

            if (!userList.Any(u => u.UserName == username && u.Password == password))
            {
                return null;
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
