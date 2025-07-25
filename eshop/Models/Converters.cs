using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace eshop.Models
{
    public class Converters
    {
        public class JsonDateTimeConverter : JsonConverter<DateTime>
        {
            private const string Format = "dd.MM.yyyy"; // Формат даты

            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTime.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString(Format));
            }
        }
    }
    internal class MaterialListConverter : JsonConverter<List<Clothing.Material>>
    {
        public override List<Clothing.Material> Read(ref Utf8JsonReader reader,
                                                  Type typeToConvert,
                                                  JsonSerializerOptions options)
        {
            var materials = new List<Clothing.Material>();
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    var value = reader.GetString();
                    if (Enum.TryParse<Clothing.Material>(value, out var material))
                    {
                        materials.Add(material);
                    }
                }
            }
            return materials;
        }

        public override void Write(Utf8JsonWriter writer,
                                 List<Clothing.Material> value,
                                 JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var material in value)
            {
                writer.WriteStringValue(material.ToString());
            }
            writer.WriteEndArray();
        }
    }
}
