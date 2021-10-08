using Newtonsoft.Json;
using TerraSdk.Client.Models;
using TerraSdk.Core.Bank;

namespace TerraSdk.Core
{
    /**
     * The StdTx data structure contains the signatures from [[StdSignMsg]] with the same
     * information, and can be broadcasted to the node to be included in a block.
     */
    public class StdTx : Msg
    {
        private static readonly string InternalType = "core/StdTx";

        public StdTx()
        {

        }

        //    /**
        //     * @param msg list of messages to include (not a typo)
        //     * @param fee transaction fee
        //     * @param signatures list of signatures
        //     * @param memo optional note
        //     * @param timeout_height optional tx timeout
        //     */
        public StdTx(Msg[] msg, StdFee fee, StdSignature[] signatures, string memo, int? timeoutHeight)
        {
            Type = InternalType;
            Value = new MsgValue
            {
                Msg = msg,
                Fee = fee,
                Signatures = signatures,
                Memo = memo,
                TimeoutHeight = timeoutHeight
            };
        }
        
        public static StdTx FromData(MsgData msgData)
        {
            return InternalFromData<StdTx, MsgValue>(msgData, InternalType);
        }

        public class MsgValue
        {
            [JsonProperty("fee")]
            public StdFee Fee { get; internal set; }
            [JsonProperty("memo")]
            public string Memo { get; internal set; }
            [JsonProperty("msg")]
            public Msg[] Msg { get; internal set; }
            
            [JsonProperty("signatures")]
            public StdSignature[] Signatures { get; internal set; }
            
            [JsonProperty("timeout_height"), JsonConverter(typeof(StringJsonConverter))]
            public int? TimeoutHeight { get; internal set; }
        }
    }
}
