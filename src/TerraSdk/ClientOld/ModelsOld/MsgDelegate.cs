using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.ClientOld.ModelsOld
{
    public class MsgDelegate : Msg
    {
        public MsgDelegate()
        {
        }

        public MsgDelegate(string delegatorAddress, string validatorAddress, Coin amount)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Amount = amount;
        }

        [JsonProperty("delegator_address")] public string DelegatorAddress { get; set; } = null!;

        [JsonProperty("validator_address")] public string ValidatorAddress { get; set; } = null!;

        [JsonProperty("amount")] public Coin Amount { get; set; } = null!;

        public object SignBytesObject()
        {
            return this;
        }
    }
}