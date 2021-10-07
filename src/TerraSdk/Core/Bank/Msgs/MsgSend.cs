using Newtonsoft.Json;
using TerraSdk.Core.Account;

namespace TerraSdk.Core.Bank.Msgs
{
    /**
     * A basic message for sending [[Coins]] between Terra accounts.
     */
    public class MsgSend : Msg, IMsg
    {
        static MsgSend()
        {
            InternalType = "bank/MsgSend";
        }

        public MsgSend()
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

        public static MsgSend FromData(MsgData msgData)
        {
            return InternalFromData<MsgSend, MsgValue>(msgData);
        }

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