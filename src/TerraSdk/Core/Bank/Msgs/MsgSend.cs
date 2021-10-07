using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TerraSdk.Core.Account;

namespace TerraSdk.Core.Bank.Msgs
{
    /**
     * A basic message for sending [[Coins]] between Terra accounts.
     */
    public class MsgSend : Msg
    {
       
        private static string type ="bank/MsgSend";

        private MsgSend()
        {
            
        }

        public MsgSend(AccAddress fromAccAddress, AccAddress toAccAddress, Coins coins)
        {
            Value = new MsgValue
            {
                FromAccAddress = fromAccAddress,
                ToAccAddress = toAccAddress,
                Coins = coins
            };
        }
        
        public static MsgSend FromData(Core.MsgData msgData)
        {
            if (msgData.Type != type)
            {
                throw new Exception("Invalid msgData type!");
            }

            var serializer = new JsonSerializer();
            var p = new MsgSend()
            {
                Value = (MsgValue)serializer.Deserialize(new JTokenReader((JToken)msgData.Value), typeof(MsgValue))
            };
                

            if (p == null)
            {
                throw new Exception("Invalid msgData content!");
            }

            return p;
        }

        public override MsgData ToData()
        {
            return new MsgData
            {
                Type = Type,
                Value = Value
            };
        }

        [JsonProperty("type")]
        public string Type => type;

        [JsonProperty("value")]
        public MsgValue Value { get; private set;  }

        public class MsgValue
        {
            // JSON
            [JsonProperty("amount")]
            public Coins Coins { get; internal set; }

            [JsonIgnore]
            public AccAddress FromAccAddress { get; internal set; }

            [JsonProperty("from_address")]
            public string FromAddress
            {
                get => FromAccAddress.Value;
                set => FromAccAddress = new AccAddress(value);
            }

            [JsonIgnore]
            public AccAddress ToAccAddress { get; internal set; }

            [JsonProperty("to_address")]
            public string ToAddress
            {
                get => ToAccAddress.Value;
                set => ToAccAddress = new AccAddress(value);
            }

        }
    }
}