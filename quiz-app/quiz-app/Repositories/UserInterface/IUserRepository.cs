using quiz_app.DTO;
using quiz_app.Entities;

namespace quiz_app.Repositories.UserInterface
{
    public interface IUserRepository
    {
        Task<User> RegisterUserAsync(UserWithRoleDTO data);

        Task<User> GetUserAsync(string username);

        Task<(User user, string token)> LoginAsync(UserDTO data);
    }
}
