using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using static eshop.Models.Converters;

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
        public List<Manufacturer> manufacturers = new List<Manufacturer>();
        public Product? GetProdById(int id) => products.Find(p => p.id == id);
        
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
        public void AddPositionToProducts(Product product)
        {
            products.Add(product);
        }
        public void AddPositionToManufacturers(Manufacturer manufacturer)
        {
            manufacturers.Add(manufacturer);
        }
        static void AddTypeDiscriminator(JsonTypeInfo typeInfo)
        {
            if (typeInfo.Type == typeof(Product))
            {
                typeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                {
                    TypeDiscriminatorPropertyName = "$type",
                    DerivedTypes =
            {
                new JsonDerivedType(typeof(Book), "book"),
                new JsonDerivedType(typeof(Cosmetic), "cosmetic"),
                new JsonDerivedType(typeof(Electronics), "electronics"),
                new JsonDerivedType(typeof(Clothing), "clothing"),
                new JsonDerivedType(typeof(Food), "food")
            }
                };
            }
        }
        public void SaveProductsToFile(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = {
                        new JsonStringEnumConverter(),
                        new JsonDateTimeConverter()
                    },
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver
                    {
                        Modifiers = { AddTypeDiscriminator }
                    }
                };
                string json = JsonSerializer.Serialize(products, options);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Сохранено {products.Count} товаров в {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }
        public void SaveToFile<T>(string filePath, IEnumerable<T> collection)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = {
                        new JsonStringEnumConverter(),
                        new JsonDateTimeConverter()
                    },
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver
                    {
                        Modifiers = { AddTypeDiscriminator }
                    }
                };
                string json = JsonSerializer.Serialize(collection, options);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Сохранено {collection.Count()} товаров в {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }
        public void SaveProduct()
        {
            SaveToFile("products.json", products);
        }
        public void SaveManufacturers()
        {   
            SaveToFile("manufacturers.json", manufacturers);
        }
        public void LoadProductsFromFile(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = {
                        new JsonStringEnumConverter(),
                        new JsonDateTimeConverter()
                    },
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver
                    {
                        Modifiers = { AddTypeDiscriminator }
                    }
                };

                string json = File.ReadAllText(filePath);
                var loadedProducts = JsonSerializer.Deserialize<List<Product>>(json, options);

                if (loadedProducts != null)
                {
                    products = loadedProducts;
                    Console.WriteLine($"Загружено {products.Count} товаров из {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки: {ex.Message}");
            }
        }
        public void LoadManufacturersFromFile(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = {
                new JsonStringEnumConverter(),
                new JsonDateTimeConverter()
            },
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver
                    {
                        Modifiers = { AddTypeDiscriminator }
                    }
                };

                string json = File.ReadAllText(filePath);
                var loadedManufacturers = JsonSerializer.Deserialize<List<Manufacturer>>(json, options);

                if (loadedManufacturers != null)
                {
                    manufacturers = loadedManufacturers;
                    Console.WriteLine($"Загружено {manufacturers.Count} производителей из {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки: {ex.Message}");
            }
        }
    }
}
