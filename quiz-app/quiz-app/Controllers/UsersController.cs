using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_app.Data;
using quiz_app.Entities;
using BCrypt.Net;
using quiz_app.DTO;

namespace quiz_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public UsersController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(Guid id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(Guid id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(UserDTO users)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(users.Password);

            Users user = new()
            {
                Username = users.Username,
                HashedPassword = hashedPassword,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = user.Id }, user);
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDTO users)
        {
         
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == users.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

           
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(users.Password, user.HashedPassword);
            if (isPasswordValid)
            {
                return Ok(new { Login = "Login Sucessful"});
            }
            else
            {
                return Unauthorized(new { Unauthorized = "Invalid username or password." });
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(Guid id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
