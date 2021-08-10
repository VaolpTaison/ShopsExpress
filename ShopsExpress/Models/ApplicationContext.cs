using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsExpress.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // Таблица с товарами

        public DbSet<Booking> Bookings { get; set; } // Таблица с бронированием товаров

        /*protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Host=localhost;Port=5432;Database=ShopExpressDB;Username=postgres;Password=00000000");
        }*/

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();  // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
