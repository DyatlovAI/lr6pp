using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2rrr.Models;
using static WebApplication2rrr.Controllers.HomeController;

namespace WebApplication2rrr.Controllers
{
    public class LoginController : Controller
    {
        private readonly MobileContext _dbContext;
        public LoginController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Home/Vhod.cshtml");
        }

        [HttpPost]
        public IActionResult LoginUs(User user)
        {

            var lUser = _dbContext.Users.FirstOrDefault(u => u.NumberTelephone == user.NumberTelephone);

            if (lUser != null && BCrypt.Net.BCrypt.Verify(user.Password, lUser.Password))
            {
                return RedirectToAction("RegUser", "User");
            }
            else if (lUser == null || lUser.NumberTelephone == null)
            {
                ViewBag.ErrorMessage = "Неправильный логин";
                return View("~/Views/Home/Vhod.cshtml", user);
            }
            else
            {
                ViewBag.ErrorMessage = "Неправильный пароль";
                return View("~/Views/Home/Vhod.cshtml", user);

            }
        }
           
        }
    }
