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
            ),
            new Electronics(
                name: "Смартфон Samsung Galaxy S23",
                price: 89990m,
                model: "SM-S911B",
                warrantyMonths: 24,
                specifications: """
                    Экран: 6.1\" Dynamic AMOLED 2X (2340x1080)
                    Процессор: Snapdragon 8 Gen 2
                    Память: 8/256 ГБ
                    Камеры: 50 МП + 12 МП + 10 МП
                    Батарея: 3900 мАч
                    """
            ),
            new Electronics(
                name: "Ноутбук ASUS VivoBook 15",
                price: 54990m,
                model: "X1502ZA-EJ317",
                warrantyMonths: 12,
                specifications: """
                    Экран: 15.6\" IPS (1920x1080)
                    Процессор: Intel Core i5-1235U
                    Оперативная память: 16 ГБ
                    SSD: 512 ГБ
                    ОС: Windows 11 Home
                    """
            ),
            new Electronics(
                name: "Наушники Sony WH-1000XM5",
                price: 32990m,
                model: "WH-1000XM5/B",
                warrantyMonths: 18,
                specifications: """
                    Тип: беспроводные, с шумоподавлением
                    Акустика: 30 мм динамики
                    Время работы: до 30 часов
                    Вес: 250 г
                    Интерфейсы: Bluetooth 5.2, NFC
                    """
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
            new Manufacturer("Samsung", Country.Корея),
            new Manufacturer("ASUS", Country.Тайвань),
            new Manufacturer("Sony", Country.Япония),
        };
    }
}
