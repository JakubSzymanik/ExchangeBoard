using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Context;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly AppDbContext _context;

        public UsersController(ILogger<UsersController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet] // api/users/getusers
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users; //Ok(users) ale z actionresult framework sobie dopowiada rodzaj respnonsu jak po prostu zwrócimy obiekt, czyli jak Ok to będzie 200 itp.
        }

        [HttpGet("{id}")] // api/users/getuser/2
        public async Task<ActionResult<User>> GetUser(int id)
        { 
            return await _context.Users.FindAsync(id);
        }
    }
}
