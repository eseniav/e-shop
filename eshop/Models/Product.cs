using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models
{
    internal abstract class Product
    {
        internal int id = 0;
        internal string name = "default name";
        internal string Title => name.Substring(0, 1).ToUpper() + name.Substring(1);
        private decimal price = 0;
        internal decimal Price
        {
            get => price;
            set
            {
                price = CheckPrice(value) ? price : 0;
            }
        }
        private int productTypeId;
        public int ProductTypeId { get; set; }
        internal Product() : this(1)
        {

        }
        internal Product(int id) : this("default name", id)
        {

        }
        internal Product(string name, int id = 0) : this(name, 951.36m, id)
        {

        }
        internal Product(string name, decimal price, int id = 0)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
        /// <summary>
        /// Формат: ID. Название -- цена
        /// </summary>
        internal virtual void Print()
        {
            Console.WriteLine($"{id}. {Title} -- {Price}");
        }
        public override string ToString() => $"{id}. {Title} -- {Price}";
        /// <summary>
        /// Проверка цены
        /// </summary>
        /// <param name="price">значение цены(десятичное)</param>
        /// <returns>истина, если >=0</returns>
        static public bool CheckPrice(int price) => price >= 0;
        static public bool CheckPrice(double price) => price >= 0;
        static public bool CheckPrice(decimal price) => price >= 0;
        static public bool CheckPrice(float price) => price >= 0;
        private bool CheckPrice() => price >= 0;
        public abstract void Display();
    }
    internal class Book : Product
    {
        public string Author { get; set; }
        public enum Genre {
            Фэнтези = 1,
            [Display(Name = "Научная фантастика")]
            НаучнаяФантастика,
            Детектив,
            Роман,
            Триллер,
            Ужасы,
            Исторический,
            Биография,
            Поэзия,
            Приключения,
        }
        public Genre genre { get; set; }
        private int publicationDate;
        public int PublicationDate
        {
            get => publicationDate;
            set
            {
                if (CheckBookYear(value))
                    publicationDate = value;
            }
        }
        public Book (string name, decimal price, string author) : base(name, price)
        {
            this.Author = author;
        }
        internal sealed override void Print()
        {
            Console.WriteLine($"{id}. {Author} {Title} -- {Price}");
        }
        public override string ToString() => base.ToString() + $", {Author}";
        public override void Display()
        {
            Console.WriteLine();
        }
        public bool CheckBookYear(int year) => year >= 1900 && year <= DateTime.Today.Year;
    }
}
