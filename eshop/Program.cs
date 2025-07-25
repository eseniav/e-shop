using eshop.Models;
namespace eshop
{
    internal class Program {
        static void Main()
        {
            Store store = new Store();
            List<Manufacturer> manufacturers = new List<Manufacturer>() {
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
            new Manufacturer("ZARA", Country.Испания),
            new Manufacturer("GUCCI", Country.Италия),
            new Manufacturer("Белый медведь", Country.Россия), // Для сыра
            new Manufacturer("Мистраль", Country.Россия),     // Для крупы
            new Manufacturer("Бабаевский", Country.Россия),    // Для шоколада
        };
            foreach (var manufact in manufacturers)
            {
                store.AddPositionToManufacturers(manufact);
            }
            store.SaveToFile("manufacturers.json", store.manufacturers);
            List<Product> products = new List<Product>()
                {
            new Book("Властелин Колец: Братство Кольца", 899m, manufacturers[1], "Дж. Р. Р. Толкин")
                {
                    BookGenre = Book.Genre.Фэнтези,
                    PublicationDate = 1954
                },
            new Book("1984", 450m, manufacturers[2], "Джордж Оруэлл")
                {
                    BookGenre = Book.Genre.Антиутопия,
                    PublicationDate = 1949
                },
            new Book("Убийство в \"Восточном экспрессе\"", 680m, manufacturers[2], "Агата Кристи")
                {
                    BookGenre = Book.Genre.Детектив,
                    PublicationDate = 1934
                },
            new Book("Марсианин", 750m, manufacturers[3], "Энди Вейер")
                {
                    BookGenre = Book.Genre.НаучнаяФантастика,
                    PublicationDate = 2011
                },
            new Book("Гарри Поттер и философский камень", 1200m, manufacturers[1], "Дж. К. Роулинг")
                {
                    BookGenre = Book.Genre.Фэнтези,
                    PublicationDate = 1997
                },
            new Cosmetic(
                name: "Увлажняющий крем для лица",
                price: 899m,
                expiryDate: new DateTime(2026, 12, 31),
                volume: "50 мл",
                type: "Уход за лицом",
                manufacturer: manufacturers[4]
            ),
            new Cosmetic(
                name: "Head & Shoulders Против перхоти",
                price: 450m,
                expiryDate: new DateTime(2027, 06, 30),
                volume: "400 мл",
                type: "Шампунь",
                manufacturer: manufacturers[5]
            ),
            new Cosmetic(
                name: "Color Sensational",
                price: 680m,
                expiryDate: new DateTime(2026, 03, 15),
                volume: "4.2 г",
                type: "Декоративная косметика",
                manufacturer: manufacturers[6]
            ),
            new Cosmetic(
                name: "Антиперспирант",
                price: 320m,
                expiryDate: new DateTime(2026, 08, 20),
                volume: "50 мл",
                type: "Гигиена",
                manufacturer: manufacturers[7]
            ),
            new Cosmetic(
                name: "Volume Million Lashes",
                price: 1200m,
                expiryDate: new DateTime(2026, 11, 01),
                volume: "10 мл",
                type: "Тушь для ресниц",
                manufacturer: manufacturers[8]
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
            ),
            new Clothing(
                name: "Футболка классическая",
                price: 1499m,
                type: Clothing.ClothingType.Футболка,
                size: Clothing.Size.L,
                color: Clothing.Color.Черный,
                materials: new List<Clothing.Material>
                {
                    Clothing.Material.Хлопок,
                    Clothing.Material.Эластан
                },
                gender: Clothing.Gender.Мужской
            ),
            new Clothing(
                name: "Толстовка Oversize",
                price: 3990m,
                type: Clothing.ClothingType.Толстовка,
                size: Clothing.Size.XL,
                color: Clothing.Color.Белый,
                materials: new List<Clothing.Material>
                {
                    Clothing.Material.Хлопок,
                    Clothing.Material.Флис
                },
                gender: Clothing.Gender.Унисекс
            ),
            new Clothing(
                name: "Платье вечернее",
                price: 8990m,
                type: Clothing.ClothingType.Платье,
                size: Clothing.Size.M,
                color: Clothing.Color.Красный,
                materials: new List<Clothing.Material>
                {
                    Clothing.Material.Шёлк
                },
                gender: Clothing.Gender.Женский
            ),
            new Food(
                name: "Сыр Российский",
                price: 450m,
                expiryDate: new DateTime(2026, 06, 15),
                weightGrams: 500,
                composition: """
                    Состав: молоко коровье пастеризованное,
                    закваска молочнокислых культур,
                    ферментный препарат,
                    соль, кальций хлористый
                    """
            ),
            new Food(
                name: "Гречневая крупа",
                price: 120m,
                expiryDate: new DateTime(2027, 03, 01),
                weightGrams: 900,
                composition: "Состав: гречневая крупа ядрица 100%"
            ),
            new Food(
                name: "Шоколад молочный",
                price: 95m,
                expiryDate: new DateTime(2027, 12, 31),
                weightGrams: 100,
                composition: """
                    Состав: сахар, какао-масло,
                    сухое цельное молоко,
                    какао тертое, эмульгатор (лецитин),
                    ароматизатор ванилин
                    """
            )
        };
            foreach (var prod in products)
            {
                store.AddPositionToProducts(prod);
            }
            store.SaveToFile("products.json", store.products);
            Console.WriteLine(store.ToString());
            
            //store.PrintProdInfo();
            //store.PrintManufacturerInfo();
            // Сохранение в файл
            //store.SaveProductsToFile("products.json");

            // Очистка списка (для демонстрации)
            //store.products.Clear();

            // Загрузка из файла
            store.LoadProductsFromFile("products.json");
            store.LoadManufacturersFromFile("manufacturers.json");
            //store.AddPosition(new Book("Война и мир", 1500m, store.manufacturers[0], "Лев Толстой"));
            
            // Вывод загруженных товаров
            //store.PrintProdInfo();
        }
    };
}
