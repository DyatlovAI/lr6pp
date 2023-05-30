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
            return View("~/Views/Buy.cshtml", phone);
        }

        [HttpPost]
        public IActionResult Buy1(int idd, string name, string address, string phone)
        {
            Phone ph = db.Phones.Find(idd);
            var UserId = User.FindFirstValue("UserId");
            db.Orders.Add(
                new Order
                {
                    UserId = int.Parse(UserId),
                    Name = name,
                    Address = address,
                    ContactTelephone = phone,
                    PhoneId = idd
                }
            );
            db.SaveChanges();
            ViewBag.SuccessMessage = "Спасибо за покупку!";
            return View("~/Views/Thanks.cshtml", ph);
        }
    }
}
