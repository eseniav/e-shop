using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models
{
    public enum Country
    {
        Россия = 1,
        Германия,
        Китай,
        США,
        Великобритания,
        Франция,
    }
    internal class Manufacturer
    {
        static int lastID = 0;
        internal int id;
        public string Name { get; set; }
        public Country Country { get; set; }
        public static int GetNextId() => ++lastID;
        public Manufacturer(string name, Country country)
        {
            this.Name = name;
            this.Country = country;
            this.id = GetNextId();
        }
    }
}
