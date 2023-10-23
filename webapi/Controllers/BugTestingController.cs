using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BugTestingController : Controller
    {
        AppDbContext _context;

        public BugTestingController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<string> GetUnauthorized()
        {
            return "Test authorized text";
        }

        [HttpGet]
        public ActionResult<User> GetNotFound()
        {
            var user = _context.Users.Find(-1);
            if (user == null) 
                return NotFound();
            return user;
        }

        [HttpGet]
        public ActionResult<User> GetServerException()
        {
            try
            {
                var user = _context.Users.Find(-1);
                int y = 0;
                int x = 100 / y;
                return user;
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Test exception in server code");
            }
        }

        [HttpGet]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Test bad request");
        }
    }
}
