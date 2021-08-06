using ShopsExpress.Models;
using ShopsExpress.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ShopsExpress.Controllers
{
    public class shopStorage
    {
        ApplicationContext db;

        public shopStorage(ApplicationContext context)
        {
            db = context;
        }

        public int Reserve(int idProd, int vQu)
        {
            Thread t = Thread.CurrentThread;
            int qua = 0;
            var desc = db.Products.Where(p => p.productId == idProd).Select(p => new { p.productQua }).ToList();
            foreach (var q in desc)
                qua = Convert.ToInt32(q.productQua);
            if (qua > 0 && qua >= vQu)
            {
                int ostProd = Convert.ToInt32(qua) - vQu;
                var data = db.Products.SingleOrDefault(row => row.productId == idProd);
                data.productQua = ostProd;
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
            
        }
    }
}
