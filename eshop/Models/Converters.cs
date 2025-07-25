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
}
