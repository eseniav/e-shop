using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models
{
    internal class Store
    {
        public List<Product> products = new List<Product>
        {
            new Book("Властелин Колец: Братство Кольца", 899m, "Дж. Р. Р. Толкин")
                {
                    BookGenre = Book.Genre.Фэнтези,
                    PublicationDate = 1954
                },
            new Book("1984", 450m, "Джордж Оруэлл")
                {
                    BookGenre = Book.Genre.Антиутопия,
                    PublicationDate = 1949
                },
            new Book("Убийство в \"Восточном экспрессе\"", 680m, "Агата Кристи")
                {
                    BookGenre = Book.Genre.Детектив,
                    PublicationDate = 1934
                },
            new Book("Марсианин", 750m, "Энди Вейер")
                {
                    BookGenre = Book.Genre.НаучнаяФантастика,
                    PublicationDate = 2011
                },
            new Book("Гарри Поттер и философский камень", 1200m, "Дж. К. Роулинг")
                {
                    BookGenre = Book.Genre.Фэнтези,
                    PublicationDate = 1997
                }
        };
        public Product? GetProdById(int id) => products.Find(p => p.id == id);
        public List<Manufacturer> manufacturers = new() {
            new Manufacturer("АСТ", Country.Россия),
            new Manufacturer("ЭКСМО", Country.Россия),
            new Manufacturer("МИФ", Country.Россия),
        };
    }
}
