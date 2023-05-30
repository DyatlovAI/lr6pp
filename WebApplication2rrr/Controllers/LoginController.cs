using Microsoft.AspNetCore.Mvc;
using WebApplication2rrr.Models;
using static WebApplication2rrr.Controllers.HomeController;

namespace WebApplication2rrr.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Home/Vhod.cshtml");
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            // Проверка введенных данных и авторизация пользователя
            if (ModelState.IsValid)
            {
                if (model.Name == "admin" && model.Password == "password")
                {
                    // Авторизация успешна, перенаправляем на главную страницу
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Ошибка авторизации, выводим сообщение об ошибке
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            // Если модель не валидна, возвращаем форму входа с ошибками
            return View(model);
        }
    }
}