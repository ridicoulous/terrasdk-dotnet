using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.Client.Models
{
    /// <summary>
    /// Msg struct for delegation withdraw from a single validator.
    /// </summary>
    public class MsgWithdrawDelegatorReward : Msg
    {
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        
        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        public MsgWithdrawDelegatorReward()
        {
        }

        public MsgWithdrawDelegatorReward(string delegatorAddress, string validatorAddress)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}