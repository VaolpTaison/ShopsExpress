using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsExpress.Models
{
    public class Booking
    {
        public int bookingId { get; set; }
        public int bookingDesc { get; set; }
        public int productId { get; set; }
        public string nameUser { get; set; }
        public string emailUser { get; set; }

        //public virtual Product Product { get; set; }
    }
}
