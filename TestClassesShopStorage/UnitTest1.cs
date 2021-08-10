using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopsExpress.Controllers;
using ShopsExpress.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TestClassesShopStorage
{
    [TestClass]
    public class UnitTest1
    {
        public int QuantityRec = 0;

        [TestMethod]
        public void Test1()
        {
            int idProd = 1;
            int qua = 3;
            var ex = 100;

            List<Thread> ThrArr = new List<Thread>();
            for (int ind = 0; ind < 10; ind++)
            {
                Thread devthread = new Thread(() => ReserveCh(idProd, qua));
                devthread.Name = "thr" + ind.ToString();
                ThrArr.Add(devthread);
                devthread.Start();
                //Thread.Sleep(10);
            }
            Console.WriteLine("" + QuantityRec);
            //assert
            Assert.AreEqual(ex, QuantityRec);
            #region
            /*Console.WriteLine("=====INIT======");
            var controller1 = new HomeController(_dbContext);
            Console.WriteLine("======ACT======");
            var result = controller1.Index();
            Console.WriteLine("====ASSERT=====");
            Assert.AreEqual<ViewResult>(result);
            Assert.IsInstanceOf<Booking>(((ViewResult)result).Model);*/
            #endregion
        }

        void ReserveCh(int id, int qu)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer();
            var _dbContext = new ApplicationContext(optionsBuilder.Options);
            var controller = new shopStorage(_dbContext);
            for (int i = 0; i < 10; i++)
            {
                var q = controller.Reserve(id, qu);
                if (q.Result == 1)
                    QuantityRec++;
            }
        }
    }
}