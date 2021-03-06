using System;
using Newtonsoft.Json;
using TerraSdk.Common.Extensions;

namespace TerraSdk.Common.Serialization
{
    public class Base64StringByteArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var array = value as byte[];

            serializer.Serialize(writer, array.ToBase64String());
        }


        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var deserializedString = serializer.Deserialize<string>(reader);

            return ByteArrayExtensions.ParseBase64(deserializedString);
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(byte[]);
        }
    }
}