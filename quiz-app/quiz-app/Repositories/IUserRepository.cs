using quiz_app.DTO;
using quiz_app.Entities;

namespace quiz_app.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterUserAsync(UserDTO data);

        Task<User> GetUserAsync(string username);
    }
}
