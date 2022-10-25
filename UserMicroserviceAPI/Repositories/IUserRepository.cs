using UserMicroserviceAPI.Models.Domain;

namespace UserMicroserviceAPI.Repository
{
    public interface IUserRepository
    {
        Task<User> RegisterUserAsync(User user);
        Task<User> ReturnUserInformationAsync(int userid);
        Task<User> UpdateUserAsync(int userid,User user);
        Task<string> ChangePasswordAsync(int userid, string password);
        Task<User> DeleteUserAsync(int userid);
        Task<IEnumerable<User>> ListAllUsers();
        List<User> GetAllUsers();
        Task<string> CheckUserNameAsync(string UserName);

    }
}
