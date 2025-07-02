using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models
{
    public interface IListPrintable
    {
        // Метод с реализацией по умолчанию
        public void PrintCollection<T>(IEnumerable<T> collection);
    }
    internal class Store : IListPrintable
    {
        public List<Product> products = new List<Product>();
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
            new Manufacturer("ZARA", Country.Испания),
            new Manufacturer("GUCCI", Country.Италия),
            new Manufacturer("Белый медведь", Country.Россия), // Для сыра
            new Manufacturer("Мистраль", Country.Россия),     // Для крупы
            new Manufacturer("Бабаевский", Country.Россия),    // Для шоколада
        };
        public override string ToString()
        {
            return products.Count().ToString();
        }
        public void PrintCollection<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                Console.WriteLine("Коллекция не содержит элементов");
                return;
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item?.ToString() ?? "Описание недоступно");
            }
        }
        public void PrintProdInfo()
        {
            PrintCollection(products);
        }
        public void PrintManufacturerInfo()
        {
            PrintCollection(manufacturers);
        }
        public void AddPosition(Product product)
        {
            products.Add(product);
        }
    }
}
