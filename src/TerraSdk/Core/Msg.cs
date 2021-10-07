using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TerraSdk.Core
{
    public abstract class Msg : IMsg
    {
        protected static string InternalType;

        [JsonProperty("type")]
        public string Type => InternalType;

        [JsonProperty("value")]
        public object Value { get; init; }

        protected static T1 InternalFromData<T1, T2>(MsgData msgData) where T1 : IMsg, new()
        {
            if (msgData.Type != InternalType)
            {
                throw new Exception("Invalid msgData type!");
            }

            var serializer = new JsonSerializer();
            var p = new T1
            {
                Value = (T2)serializer.Deserialize(new JTokenReader((JToken)msgData.Value), typeof(T2))
            };


            if (p == null)
            {
                throw new Exception("Invalid msgData content!");
            }

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