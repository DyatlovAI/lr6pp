using Microsoft.AspNetCore.Mvc;
using WebApplication2rrr.Models;

namespace WebApplication2rrr.Controllers
{
    public class BuyController : Controller
    {
        MobileContext db;
        public static int globalId;
        public BuyController(MobileContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Buy(int id)
        {
            globalId = id;
            Phone phone = db.Phones.Find(id);//поиск объекта по айди
            return View("~/Views/Buy.cshtml", phone);
        }

        [HttpPost]
        public IActionResult Buy1(string address)
        {
            User user = db.Users.Find(1);
            db.Orders.Add(
                new Order
                {
                    UserId = 1,
                    Address = address,
                    ContactTelephone = user.NumberTelephone,
                    PhoneId = globalId
                }
            );
            db.SaveChanges();
            return View("~/Views/Thanks.cshtml", user);
        }
    }
}
