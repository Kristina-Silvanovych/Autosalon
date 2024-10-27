using autosalon.Models;

namespace autosalon.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateUser(User user);
        Task<bool> DeleteUser(int id);
        bool ExistUser(string email);
        Task<User> FindUserByEmail(string email);
        Task<User> UpdateUser(User user);
        Task<User> FindUserById(int id);

    }
}
