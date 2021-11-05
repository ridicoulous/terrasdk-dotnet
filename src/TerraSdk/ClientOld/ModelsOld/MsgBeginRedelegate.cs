using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.ClientOld.ModelsOld
{
    public class MsgBeginRedelegate : Msg
    {
        public MsgBeginRedelegate()
        {
        }

        public MsgBeginRedelegate(string delegatorAddress, string validatorSrcAddress, string validatorDstAddress, Coin amount)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorSrcAddress = validatorSrcAddress;
            ValidatorDstAddress = validatorDstAddress;
            Amount = amount;
        }

        [JsonProperty("delegator_address")] public string DelegatorAddress { get; set; } = null!;

        [JsonProperty("validator_src_address")]
        public string ValidatorSrcAddress { get; set; } = null!;

        [JsonProperty("validator_dst_address")]
        public string ValidatorDstAddress { get; set; } = null!;

        [JsonProperty("amount")] public Coin Amount { get; set; } = null!;

        public object SignBytesObject()
        {
            return this;
        }
    }
}