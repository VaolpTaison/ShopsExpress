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

        public shopStorage ss;
        // ф-ия обработчик HttpHost (заполнение таблицы Bookings)
        [HttpPost]
        public ActionResult Booking(int kolpr, int idProd, string nameUs, string emailUs)
        {
            shopStorage ss;
            Booking booking = new Booking {bookingDesc = kolpr, productId = idProd, nameUser = nameUs, emailUser = emailUs };
            ss.Reserve(idProd, kolpr);
            //EditProduct(kolpr, idProd);
            db.Bookings.Add(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // процедура изменения данных об остатке товара в таблице Products
        /*private void EditProduct (int bQu, int idProd)
        {
            int qua = 0;
            var desc = db.Products.Where(p => p.productId == idProd).Select(p => new { p.productQua}).ToList(); // запрос в таблицу с товарами
            foreach (var q in desc)
                qua = Convert.ToInt32(q.productQua);
            int ostProd = Convert.ToInt32(qua) - bQu;
            var data = db.Products.SingleOrDefault(row => row.productId == idProd);
            data.productQua = ostProd;
            db.SaveChanges();
        }*/
    }
}
