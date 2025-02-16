using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using quiz_app.Data;
using quiz_app.DTO;
using quiz_app.Entities;
using quiz_app.Services;

namespace quiz_app.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly QuizDbContext _context;
        private readonly JwtService _jwtService;

        public UserRepository(QuizDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;

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

        public async Task<(User user, string token)> LoginAsync(UserDTO data)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == data.Username);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password. Please try again.");
            }

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
