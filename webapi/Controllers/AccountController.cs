using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using webapi.Context;
using webapi.Models;
using System.Text;
using webapi.DTOs;
using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(ILogger<AccountController> logger, AppDbContext context, ITokenService tokenService)
        {
            _logger = logger;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<UserTokenDTO>> Register(UserRegisterDTO userRegisterDTO)
        {
            if (await UserExists(userRegisterDTO.Email)) return BadRequest("User with this email already exists.");

            using var hmac = new HMACSHA512();

            var user = new User()
            {
                Name = userRegisterDTO.Name,
                Email = userRegisterDTO.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserTokenDTO
            {
                Id = user.Id,
                Email = userRegisterDTO.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost]
        public async Task<ActionResult<UserTokenDTO>> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == userLoginDTO.Email);

            if (user == null) return Unauthorized("User with this email doesn't exist.");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDTO.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password.");
            }

            return new UserTokenDTO
            {
                Id = user.Id,
                Email = userLoginDTO.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        //[HttpGet]
        //public async Task<ActionResult<string>> CheckEmailFree(string email)
        //{
        //    if (await UserExists(email)) return BadRequest("User with this email already exists.");
        //    return email;
        //}

        private async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(v => v.Email == email);
        }
    }
}
