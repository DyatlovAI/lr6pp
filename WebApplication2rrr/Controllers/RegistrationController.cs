using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApplication2rrr.Models;

namespace WebApplication2rrr.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly MobileContext _dbContext;

        public RegistrationController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View("~/Views/Home/Registration.cshtml");
        }

        [HttpPost]
        public ActionResult RegistrationUser(User user)
        {
            if (ModelState.IsValid)
            {
                // Хэширование пароля
                string hashedPassword = HashPassword(user.Password);

                // Создание нового пользователя
                var newUser = new User
                {
                    Name = user.Name,
                    Password = hashedPassword,
                    Role = string.IsNullOrEmpty(user.Role) ? "Пользователь" : user.Role,
                    Sex = user.Sex,
                    NumberTelephone = user.NumberTelephone
                };

                // Сохранение пользователя в базе данных
                try
                {
                    _dbContext.Users.Add(newUser);
                    _dbContext.SaveChanges();
                    return RedirectToAction("RegUser", "User");
                }
                catch (Exception ex)
                {
                    // Обработка ошибки
                    Console.WriteLine(ex.Message);
                }
            }

            return View("~/Views/Home/Registration.cshtml",user);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

