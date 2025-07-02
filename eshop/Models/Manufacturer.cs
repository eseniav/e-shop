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
        Корея,
        Тайвань,
        Япония,
        Испания,
        Италия,
    }
    internal class Manufacturer : IAutoIncrementable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public Manufacturer(string name, Country country)
        {
            this.Name = name;
            this.Country = country;
            this.Id = IDGenerator<Manufacturer>.GetNextId();
        }
        public override string ToString() => $"{Id}. {Name}, {Country}";
    }
}
