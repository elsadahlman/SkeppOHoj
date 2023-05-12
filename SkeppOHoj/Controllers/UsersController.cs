using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;
using SkeppOHoj.Models.DTOs;
using SkeppOHoj.Repositories;

namespace SkeppOHoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SkeppOHojContext _context; //TODO jobba bort
        private readonly IUserRepository _userRepository;
        private readonly IMapper mapper;


        public UsersController(SkeppOHojContext context, IMapper mapper, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
            this.mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userRepository.GetUsersAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreationDto user)
        {

            var output = await _userRepository.AddUserAsync(user);

            return Ok(output);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserCreationDto userDto)
        {
            var user = await _userRepository.PutUserAsync(id, userDto);
            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
