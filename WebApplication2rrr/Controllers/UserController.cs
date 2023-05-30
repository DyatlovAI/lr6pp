using Microsoft.AspNetCore.Mvc;
using WebApplication2rrr.Models;
using System.Linq;
using System.Security.Claims;

namespace WebApplication2rrr.Controllers
{
    public class UserController : Controller
    {
        private readonly MobileContext _dbContext;

        public UserController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult RegUser()
        {
            var userId = User.FindFirstValue("UserId");

            if (int.TryParse(userId, out int id))
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.UserId == id);
                return View("~/Views/Home/RegUser.cshtml", user);
            }

            return View("~/Views/Home/RegUser.cshtml");
        }
    }
}
