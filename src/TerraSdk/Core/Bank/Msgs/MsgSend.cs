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
        private const string Type = "bank/MsgSend";

        public MsgSend(AccAddress fromAccAddress, AccAddress toAccAddress, Coins coins)
        {
            FromAccAddress = fromAccAddress;
            ToAccAddress = toAccAddress;
            Coins = coins;
        }

        public AccAddress FromAccAddress { get; }
        public AccAddress ToAccAddress { get; }
        public Coins Coins { get; }

        public static MsgSend FromData(Data data)
        {
            if (data.Type != Type)
            {
                throw new Exception("Invalid data type!");
            }

            var serializer = new JsonSerializer();
            var p = (DataValue)serializer.Deserialize(new JTokenReader((JToken)data.Value), typeof(DataValue));

            if (p == null)
            {
                throw new Exception("Invalid data content!");
            }

            return new MsgSend(new AccAddress(p.FromAddress), new AccAddress(p.ToAddress), new Coins(p.Amount));
        }

        public Data ToData()
        {
            return new Data
            {
                Type = Type,
                Value = new DataValue
                {
                    FromAddress = FromAccAddress.Value,
                    ToAddress = ToAccAddress.Value,
                    Amount = Coins.data
                }
            };
        }

        public class DataValue
        {
            [JsonProperty("from_address")]
            public string FromAddress { get; set; } = null!;

            [JsonProperty("to_address")]
            public string ToAddress { get; set; } = null!;

            [JsonProperty("amount")]
            public IList<Coin> Amount { get; set; } = null!;
        }
    }
}