using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApplication2rrr.Models;

namespace WebApplication2rrr.Controllers
{
    public class BuyController : Controller
    {
        MobileContext db;
        public BuyController(MobileContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Buy(int id)
        {
            Phone phone = db.Phones.Find(id);//поиск объекта по айди
            return View("~/Views/Home/Buy/Buy.cshtml", phone);
        }
        [HttpGet]
        public IActionResult Thanks()
        {
            return View("~/Views/Home/Thanks.cshtml");
        }
        [HttpPost]
        public IActionResult Buy(int id, string name, string address, string phone)
        {
            Phone ph = db.Phones.Find(id);
            var UserId = User.FindFirstValue("UserId");
            db.Orders.Add(
                new Order
                {
                    /*UserId = int.Parse(UserId),*/
                    UserId = 1,
                    Name = name,
                    Address = address,
                    ContactTelephone = phone,
                    PhoneId = id
                }
            );
            db.SaveChanges();
            ViewBag.SuccessMessage = "Спасибо за покупку!";
            return View("~/Views/Home/Buy/Thanks.cshtml");
        }
    }
}
