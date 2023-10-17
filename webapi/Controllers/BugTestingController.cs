using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    public class BugTestingController : Controller
    {
        AppDbContext _context;

        public BugTestingController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("authorized")]
        public ActionResult<string> GetAuthorized()
        {
            return "Test authorized text";
        }

        [HttpGet("not-found")]
        public ActionResult<User> GetNotFound()
        {
            var user = _context.Users.Find(-1);
            if (user == null) 
                return NotFound();
            return user;
        }

        [HttpGet("server-error")]
        public ActionResult<User> GetServerException()
        {
            try
            {
                var user = _context.Users.Find(-1);
                return user;
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Test exception in server code");
            }
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Test bad request");
        }
    }
}
