using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static eshop.Models.Book;
using static eshop.Models.Clothing;
using static eshop.Models.Converters;

namespace eshop.Models
{
    [JsonDerivedType(typeof(Book), typeDiscriminator: "book")]
    [JsonDerivedType(typeof(Electronics), typeDiscriminator: "electronics")]
    [JsonDerivedType(typeof(Cosmetic), typeDiscriminator: "cosmetic")]
    [JsonDerivedType(typeof(Clothing), typeDiscriminator: "clothing")]
    [JsonDerivedType(typeof(Food), typeDiscriminator: "food")]
    internal abstract class Product : IAutoIncrementable
    {
        internal int id = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        internal string Title => Name.Substring(0, 1).ToUpper() + Name.Substring(1);
        private decimal price = 0;
        public decimal Price
        {
            get => price;
            set
            {
                price = CheckPrice(value) ? value : 0;
            }
        }
        public Manufacturer? Manufacturer { get; set; }
        [JsonConstructor]
        protected Product() { }
        internal Product(string name) : this(name, 951.36m)
        {

        }
        internal Product(string name, decimal price, Manufacturer manufacturer = null)
        {
            this.Id = IDGenerator<Product>.GetNextId();
            this.Name = name;
            this.Price = price;
            this.Manufacturer = manufacturer;
        }
        /// <summary>
        /// Формат: ID. Название -- цена
        /// </summary>
        internal virtual void Print()
        {
            Console.WriteLine($"{Id}. {Title} -- {Price}");
        }
        public override string ToString() => $"{Id}. {Title} -- {Price} -- {Manufacturer}";
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
        public abstract string Display();
        static public bool CheckExpiryDate(DateTime dateTime) => dateTime > DateTime.Today;
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
            Антиутопия,
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Genre BookGenre { get; set; }
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
        public Book (string name, decimal price, Manufacturer manufacturer, string author) : base(name, price, manufacturer)
        {
            this.Author = author;
        }
        [JsonConstructor]
        public Book() { }
        internal sealed override void Print()
        {
            Console.WriteLine($"{id}. {Author} {Title} -- {Price}");
        }
        public override string ToString() => base.ToString() + $", {Author}";
        public override string Display()
        {
            return $"""
                    Характеристики товара:
                    Автор: {Author}
                    Название: {Title}
                    Жанр: {BookGenre}
                    Год издания: {publicationDate}
                    """;
        }
        public bool CheckBookYear(int year) => year >= 1900 && year <= DateTime.Today.Year;
    }
    internal class Cosmetic : Product
    {
        public override string Display()
        {
            return $"""
                    Характеристики товара:
                    Название: {Title}
                    Тип: {CosmeticType}
                    Объем: {Volume}
                    Срок годности: {expiryDate}
                    """;
        }
        private DateTime expiryDate;

        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime ExpiryDate
        {
            get => expiryDate;
            set
            {
                if (CheckExpiryDate(value))
                    expiryDate = value;
                else
                    throw new ArgumentException("Некорректная дата срока годности");
            }
        }
        public string Volume { get; set; }
        public string CosmeticType { get; set; }
        [JsonConstructor]
        public Cosmetic() { }
        public Cosmetic(string name, decimal price, DateTime expiryDate, string volume, string type) : base(name, price)
        {
            this.ExpiryDate = expiryDate;
            this.Volume = volume;
            this.CosmeticType = type;
        }
    }
    internal class Electronics : Product
    {
        public override string Display()
        {
            return $"""
                    Характеристики товара:
                    Название: {Title}
                    Модель: {Model}
                    Гарантия(в месяцах): {warrantyMonths}
                    Описание: {Specifications}
                    """;
        }
        public string Model { get; set; }
        private int warrantyMonths;
        public int WarrantyMonths
        {
            get => warrantyMonths;
            set
            {
                if (value >= 0)
                    warrantyMonths = value;
            }
        }
        [JsonPropertyName("specifications")]
        public string Specifications { get; set; }
        [JsonConstructor]
        public Electronics() { }
        public Electronics(string name, decimal price, string model, int warrantyMonths, string specifications) : base(name, price)
        {
            this.Model = model;
            this.WarrantyMonths = warrantyMonths;
            this.Specifications = specifications;
        }
    }
    internal class Clothing : Product
    {
        public override string Display()
        {
            return $"""
                    Характеристики товара:
                    Название: {Title}
                    Тип: {Type}
                    Размер: {ClothingSize}
                    Цвет: {ClothingColor}
                    Материал: {ClothingMaterials}
                    Пол: {ClothingGender}
                    """;
        }
        public enum ClothingType
        {
            Футболка = 1,
            Толстовка,
            Свитшот,
            Платье,
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ClothingType Type { get; set; }
        public enum Size { XS = 1, S, M, L, XL, XXL }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Size ClothingSize { get; set; }
        public enum Color
        {
            Белый,
            Черный,
            Красный,
            Зеленый,
            Синий,
            Бежевый,
            Желтый,
            Фиолетовый,
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Color ClothingColor { get; set; }
        public enum Material
        {
            [Description("Дышащий, гипоаллергенный")]
            Хлопок = 1,
            [Description("Натуральный, держит форму")]
            Лён,
            [Description("Тёплая, требует особого ухода")]
            Шерсть,
            [Description("Роскошный, деликатный")]
            Шёлк,
            [Description("Джинсовая ткань")]
            ДжинсоваяТкань,
            [Description("Износостойкий, быстро сохнет")]
            Полиэстер,
            [Description("Мягкая, имитирует натуральные ткани")]
            Вискоза,
            [Description("Растягивается, добавляется к другим тканям")]
            Эластан,
            [Description("Мягкий утеплитель")]
            Флис,
            [Description("Натуральная, премиальный вид")]
            Кожа,
            [Description("Мягкая текстурированная кожа")]
            Замша,
            [Description("Лёгкий, водоотталкивающий")]
            Нейлон,
        }
        [JsonConverter(typeof(MaterialListConverter))]
        public List<Material> ClothingMaterials { get; set; }
        public enum Gender
        {
            Мужской = 1,
            Женский,
            Унисекс,
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender ClothingGender { get; set; }
        [JsonConstructor]
        public Clothing() { }
        public Clothing(string name, decimal price, ClothingType type, Size size, Color color, List<Material> materials, Gender gender) : base(name, price)
        {
            this.Type = type;
            this.ClothingSize = size;
            this.ClothingColor = color;
            this.ClothingMaterials = materials;
            this.ClothingGender = gender;
        }
        public void AddMaterial(Material material)
        {
            if (!ClothingMaterials.Contains(material))
                ClothingMaterials.Add(material);
        }
    }
    internal class Food : Product
    {
        public override string Display()
        {
            return $"""
                    Характеристики товара:
                    Название: {Title}
                    Срок годности: {ExpiryDate}
                    Вес: {FormatWeight(weightGrams)}
                    Состав: {Composition}
                    """;
        }
        private DateTime expiryDate;
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime ExpiryDate
        {
            get => expiryDate;
            set
            {
                if (CheckExpiryDate(value))
                    expiryDate = value;
            }
        }
        public string Composition { get; set; }
        private int weightGrams;
        public int WeightGrams
        {
            get => weightGrams;
            set
            {
                if (value > 0)
                    weightGrams = value;
            }
        }
        public static string FormatWeight(int grams)
        {
            const int gramsPerKilogram = 1000;
            int kilograms = grams / gramsPerKilogram;
            int remainingGrams = grams % gramsPerKilogram;
            return (kilograms, remainingGrams) switch
            {
                (0, 0) => "0 г",
                (0, _) => $"{remainingGrams} г",
                (_, 0) => $"{kilograms} кг",
                _ => $"{kilograms} кг {remainingGrams} г"
            };
        }
        [JsonConstructor]
        public Food() { }
        public Food(string name, decimal price, DateTime expiryDate, int weightGrams, string composition) : base(name, price)
        {
            this.ExpiryDate = expiryDate;
            this.WeightGrams = weightGrams;
            this.Composition = composition;
        }
    }
}
