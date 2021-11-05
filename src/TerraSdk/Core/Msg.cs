using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TerraSdk.Core
{
    public class Msg
    {
        [JsonProperty("type")] public string Type { get; init; }

        [JsonProperty("value")] public object Value { get; init; }

        protected static T1 InternalFromData<T1, T2>(MsgData msgData, string type) where T1 : Msg, new()
        {
            if (msgData.Type != type) throw new Exception("Invalid msgData type!");

            var serializer = new JsonSerializer();
            var p = new T1
            {
                Type = msgData.Type,
                Value = (T2) serializer.Deserialize(new JTokenReader((JToken) msgData.Value), typeof(T2))
            };


            if (p == null) throw new Exception("Invalid msgData content!");

            return p;
        }

        public MsgData ToData()
        {
            return new MsgData
            {
                Type = Type,
                Value = Value
            };
        }
    }
}