using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models
{
    internal class OrderComposition
    {
        internal int id;
        private int productId;
        public int ProductId { get; set; }
        private decimal price;
        public decimal Price { get; set; }
        private int quantity = 1;
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value >= 1 ? value : 1;
            }
        }
    }
}
