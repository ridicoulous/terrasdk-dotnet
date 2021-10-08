﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace TerraSdk.Client.Api.Serialization
{
    public class TypeValueConverter<TBaseType> : JsonConverter<TBaseType> where TBaseType: class
    {
        private readonly bool _dontWriteTypeValue = false;
        private string _registerTypeHint = "";
        internal readonly Dictionary<Type, string> TypeToJsonName = new Dictionary<Type, string>();
        internal readonly Dictionary<string, Type> JsonNameToType = new Dictionary<string, Type>();

        public TypeValueConverter(bool dontWriteTypeValue = default)
        {
            _dontWriteTypeValue = dontWriteTypeValue;
        }

        public TypeValueConverter(string? registerTypeHint = null)
        {
            _registerTypeHint = registerTypeHint ?? "";
        }

        public void AddType<T>(string jsonName)
        {
            JsonNameToType[jsonName] = typeof(T);
            TypeToJsonName[typeof(T)] = jsonName;
        }
        
        public override void WriteJson(JsonWriter writer, TBaseType value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var contract = (JsonObjectContract)serializer
                .ContractResolver
                .ResolveContract(value.GetType());
            if (_dontWriteTypeValue == true)
            {
                WriteObject(writer, value, serializer, contract);
                return;
            }

            if (!TypeToJsonName.TryGetValue(value.GetType(), out var jsonTypeName))
            {
                throw new TerraSerializationException($"Unknown type {value.GetType()} for base type {typeof(TBaseType).Name}. {_registerTypeHint}");
            }


            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteValue(jsonTypeName);
            writer.WritePropertyName("value");
            WriteObject(writer, value, serializer, contract);
            writer.WriteEndObject();
        }

        private static void WriteObject(JsonWriter writer, TBaseType value, JsonSerializer serializer,
            JsonObjectContract contract)
        {
            writer.WriteStartObject();
            foreach (var property in contract.Properties)
            {
                writer.WritePropertyName(property.PropertyName ??
                                         throw new TerraSerializationException(
                                             $"Property name is null for type {value.GetType()}."));
                if (property.Converter != null)
                {
                    property.Converter.WriteJson(writer, property.ValueProvider!.GetValue(value), serializer);
                }
                else
                {
                    serializer.Serialize(writer, property.ValueProvider!.GetValue(value));
                }
            }

            writer.WriteEndObject();
        }

        public override TBaseType ReadJson(JsonReader reader, Type objectType, TBaseType existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jobject = serializer.Deserialize<JObject>(reader);
            if (jobject == null)
            {
                return default!;
            }

            var typeToken = jobject["type"];
            if (typeToken == null)
            {
                throw new TerraSerializationException("Missing type discriminator in json.");
            }
            
            var typeString = typeToken.Value<string>();
            if (!JsonNameToType.TryGetValue(typeString, out var type))
            {
                throw new TerraSerializationException($"Unknown json type discriminator {typeString} for base type {typeof(TBaseType).Name}. {_registerTypeHint}");
            }

            var jToken = jobject["value"];
            if (jToken == null)
            {
                return default(TBaseType)!;
            }
            return Read(serializer, type, jToken);
        }

        private static TBaseType Read(JsonSerializer serializer, Type type, JToken jToken)
        {
            var constructorInfo = type.GetConstructor(Type.EmptyTypes);
            if (constructorInfo == null)
            {
                throw new TerraSerializationException($"Type {type.Name} doesn't have parameterless constructor.");
            }

            var value = constructorInfo.Invoke(Array.Empty<object>());
            serializer.Populate(jToken!.CreateReader(), value);
            return (TBaseType) value;
        }
    }
}