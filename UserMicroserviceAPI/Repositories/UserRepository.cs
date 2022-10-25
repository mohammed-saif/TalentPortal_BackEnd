using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using UserMicroserviceAPI.Data;
using UserMicroserviceAPI.Models.Domain;
using UserMicroserviceAPI.Repository;

namespace UserMicroserviceAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext userDbContext;
        public UserRepository(UserDbContext _userDbContext)
        {
            userDbContext = _userDbContext;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            await userDbContext.Users.AddAsync(user);
            await userDbContext.SaveChangesAsync();
            return user;

        }

        public async Task<User> ReturnUserInformationAsync(int userid)
        {
            var userInfo = await userDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userid);
            if (userInfo == null)
                return null;
            return userInfo;
        }

        public async Task<User> DeleteUserAsync(int userid)
        {
            var user = await userDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userid);
            userDbContext.Users.Remove(user);
            await userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> ListAllUsers()
        {
            return await userDbContext.Users.ToListAsync();
        }

        public List<User> GetAllUsers()
        {
            return userDbContext.Users.ToList();
        }

        public async Task<User> UpdateUserAsync(int userid, User user)
        {
            var oldUser = await userDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userid);
            if (oldUser != null)
            {
                oldUser.UserFirstName = user.UserFirstName;
                oldUser.UserMiddleName = user.UserMiddleName;
                oldUser.UserLastName = user.UserLastName;
                oldUser.UserPhoneNumber = user.UserPhoneNumber;
                oldUser.Gender = user.Gender;
                oldUser.UserAddress = user.UserAddress;
                oldUser.UserDOB = user.UserDOB;
                oldUser.UserName = user.UserName;
                oldUser.EmailId = user.EmailId;
                await userDbContext.SaveChangesAsync();
                return oldUser;
            }
            else
            {
                return null;
            }

        }

        public async Task<string> ChangePasswordAsync(int userid, string password)
        {
            var oldUser = await userDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userid);
            if (oldUser != null)
            {
                oldUser.Password = password;
                await userDbContext.SaveChangesAsync();
                return ("Password changed successfully");
            }
            else
            {
                return null;
            }

        }

        public async Task<string> CheckUserNameAsync(string UserName)
        {
            var check = await userDbContext.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
            if (check == null)
            {
                return UserName;
            }
            else
            {
                return null;
            }
        }
    }
}
