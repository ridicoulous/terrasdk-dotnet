using System;
using System.Linq;
using Newtonsoft.Json;

namespace TerraSdk.Core.Bank
{
    public class StringJsonConverter : JsonConverter
    {
        public StringJsonConverter() { }

        private readonly Type[]? types;

        public StringJsonConverter(params Type[] types)
        {
            this.types = types;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return types.Any(t => t == objectType);
        }
    }
}