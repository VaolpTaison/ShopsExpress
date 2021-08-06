using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopsExpress.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsExpress.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public int Idproduct;
        public int userID = 0;
        public string userNAME;

        // index
        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        // ф-ия отображения товара на странице
        public async Task<IActionResult> Booking(int? id)
        {
            if (id != null)
            {
                Product user = await db.Products.FirstOrDefaultAsync(p => p.productId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        // ф-ия обработчик HttpHost (заполнение таблицы Bookings)
        [HttpPost]
        public ActionResult Booking(int kolpr, int idProd, string nameUs, string emailUs)
        {
            var ss = new shopStorage(db);
            //Booking booking = new Booking { bookingDesc = kolpr, productId = idProd, nameUser = nameUs, emailUser = emailUs };
            int i = ss.Reserve(idProd, kolpr); // idProd = id товара, kolpr - количество бронируемого товара
            if (i == 1)
            {
                Booking booking = db.Bookings.First(p => p.emailUser == null); // проверка строки, у которой отсутствует запись email (Как правило она одна в бд)
                booking.nameUser = nameUs;
                booking.emailUser = emailUs;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                ViewBag.result = 0;
            return RedirectToAction("Booking");
        }
    }
}
