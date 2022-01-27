using AutoMapper;
using EquipmentInventoryAPI.DataAccess.Models;
using EquipmentInventoryAPI.DataAccess.Repositories;
using EquipmentInventoryAPI.Library.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository,
                              IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<ICollection<ShowUserDto>>> GetUsers()
        {
            var users = _userRepository.GetUsers().ToList();
            var usersDto = _mapper.Map<List<ShowUserDto>>(users);

            return Ok(usersDto);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowUserDto>> GetUser(string id)
        {
            var user = _userRepository.GetUserById(Guid.Parse(id));

            if (user == null)
                return NotFound();

            var userDto = _mapper.Map<ShowUserDto>(user);

            return Ok(userDto);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<ShowUserDto>> PostUser(AddUserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = _mapper.Map<User>(user);
            newUser.Id = Guid.NewGuid();

            _userRepository.AddUser(newUser);
            var userDto = _mapper.Map<ShowUserDto>(newUser);

            return CreatedAtAction("GetUser", new { id = userDto.Id }, userDto);
        }

        // PUT: api/User
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserDto user)
        {
            if (Guid.Parse(id) != user.Id || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.CheckIfUserExist(user.Id))
            {
                return NotFound();
            }
            else
            {
                var updatedUser = _mapper.Map<User>(user);
                _userRepository.UpdateUser(updatedUser);
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = _userRepository.GetUserById(Guid.Parse(id));

            if (user == null)
                return NotFound();

            _userRepository.RemoveUser(user);

            return NoContent();
        }
    }
}
