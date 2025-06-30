using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models
{
    internal class Order
    {
        internal int id;
        private int userId;
        public int UserId { get; set; }
        private DateTime date;
        public DateTime CurrentDate {
            get => date;
            set
            {
                date = DateTime.Today;
            }
        }
        public List<OrderComposition> Composition { get; set; } = new ();
    }
}
