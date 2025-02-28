using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_app.Data;
using quiz_app.DTO;
using quiz_app.Entities;
using quiz_app.Repositories.UserInterface;

namespace quiz_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository userRepository, IMapper mapper) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        public readonly IMapper _mapper = mapper;

        //GET: api/Users/{username}
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
           
            try
            {
                var user = await _userRepository.GetUserAsync(username);
                var result = _mapper.Map<UserResponseDTO>(user);

                return Ok(result);
            }
            catch(InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message});
            }
        }

        // POST: api/Users/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] UserWithRoleDTO user)
        {

            try
            {
                var result = await _userRepository.RegisterUserAsync(user);
                var response = _mapper.Map<UserResponseDTO>(result);

                return Ok(response);
            } 
            catch(InvalidOperationException ex)
            {
                return Conflict( new { message = ex.Message });
            }
            catch(Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occured" });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDTO data)
        {
            try
            {
                var (user, token) = await _userRepository.LoginAsync(data);

                var result = new AuthResponseDTO
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Token = token
                };

                return Ok(result);
            }
            catch(InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch(Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred" });
            }
            
        }
    }
}
