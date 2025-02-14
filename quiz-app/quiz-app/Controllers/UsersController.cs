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
using quiz_app.Repositories;

namespace quiz_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //GET: api/Users/5
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
           
            try
            {
                var user = await _userRepository.GetUserAsync(username);

                return user;
            }
            catch(InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message});
            }
        }

        // POST: api/Users
        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] UserDTO user)
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
    }
}
