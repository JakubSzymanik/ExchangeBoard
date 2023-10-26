using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Context;
using webapi.Interfaces;
using webapi.Models;
using webapi.DTOs;
using AutoMapper;

namespace webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet] // api/users/getusers
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
        }

        [HttpGet("{id}")] // api/users/getuser/2
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        { 
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
