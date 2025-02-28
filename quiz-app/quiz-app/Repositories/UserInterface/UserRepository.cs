using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using quiz_app.Data;
using quiz_app.DTO;
using quiz_app.Entities;
using quiz_app.Services;

namespace quiz_app.Repositories.UserInterface
{
    public class UserRepository(QuizDbContext context, JwtService jwtService) : IUserRepository
    {

        private readonly QuizDbContext _context = context;
        private readonly JwtService _jwtService = jwtService;

        public async Task<User> RegisterUserAsync(UserWithRoleDTO data)
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
                Password = hashedPassword,
                Role = data.Role,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username) ?? throw new InvalidOperationException("User not found");
            return user;
        }

        public async Task<(User user, string token)> LoginAsync(UserDTO data)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == data.Username) ?? throw new InvalidOperationException("Invalid username or password. Please try again.");
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(data.Password, user.Password);

            if (!isPasswordValid)
            {
                throw new InvalidOperationException("Incorrect username or password");
            }

            var token = _jwtService.GenerateToken(user);

            return (user, token);
        }
    }
}
