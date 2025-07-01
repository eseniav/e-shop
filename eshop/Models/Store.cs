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
                },
            new Cosmetic(
                name: "Увлажняющий крем для лица",
                price: 899m,
                expiryDate: new DateTime(2026, 12, 31),
                volume: "50 мл",
                type: "Уход за лицом"
            ),
            new Cosmetic(
                name: "Head & Shoulders Против перхоти",
                price: 450m,
                expiryDate: new DateTime(2027, 06, 30),
                volume: "400 мл",
                type: "Шампунь"
            ),
            new Cosmetic(
                name: "Color Sensational",
                price: 680m,
                expiryDate: new DateTime(2026, 03, 15),
                volume: "4.2 г",
                type: "Декоративная косметика"
            ),
            new Cosmetic(
                name: "Антиперспирант",
                price: 320m,
                expiryDate: new DateTime(2026, 08, 20),
                volume: "50 мл",
                type: "Гигиена"
            ),
            new Cosmetic(
                name: "Volume Million Lashes",
                price: 1200m,
                expiryDate: new DateTime(2026, 11, 01),
                volume: "10 мл",
                type: "Тушь для ресниц"
            )
        };
        public Product? GetProdById(int id) => products.Find(p => p.id == id);
        public List<Manufacturer> manufacturers = new() {
            new Manufacturer("АСТ", Country.Россия),
            new Manufacturer("ЭКСМО", Country.Россия),
            new Manufacturer("МИФ", Country.Россия),
            new Manufacturer("Nivea", Country.Германия),
            new Manufacturer("Head & Shoulders", Country.США),
            new Manufacturer("Maybelline", Country.США),
            new Manufacturer("Rexona", Country.Великобритания),
            new Manufacturer("L'Oréal Paris", Country.Франция),
        };
    }
}
