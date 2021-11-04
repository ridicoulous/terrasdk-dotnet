using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.ClientOld.ModelsOld
{
    /// <summary>
    /// MsgUndelegate - struct for unbonding transactions.
    /// </summary>
    public class MsgUndelegate : Msg
    {
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;
        [JsonProperty("amount")]
        public Coin Amount { get; set; } = null!;

        public MsgUndelegate()
        {
        }

        public MsgUndelegate(string delegatorAddress, string validatorAddress, Coin amount)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Amount = amount;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}