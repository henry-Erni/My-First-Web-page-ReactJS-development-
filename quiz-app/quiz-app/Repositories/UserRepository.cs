using Microsoft.EntityFrameworkCore;
using quiz_app.Data;
using quiz_app.DTO;
using quiz_app.Entities;

namespace quiz_app.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly QuizDbContext _context;

        public UserRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUserAsync(UserDTO data)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == data.Username);

            if (user != null)
            {
                throw new InvalidOperationException("User already exist");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.Password);

            user = new User
            {
                UserId = Guid.NewGuid(),
                Username = data.Username,
                Password = hashedPassword
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);


            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            return user;
        }
    }
}
