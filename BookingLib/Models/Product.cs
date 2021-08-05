using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsExpress.Models
{
    public class Product
    {
        public int productId { get; set; } // id товара
        public string productName { get; set; } // наименование товара 
        public string productDesc { get; set; } // краткое описание товара
        public string productImg { get; set; } // изображение товара
        public int productQua { get; set; } // количество товара на складе

        //public List<Booking> bookings { get; set; }
    }
}
