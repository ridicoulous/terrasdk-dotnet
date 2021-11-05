using Newtonsoft.Json;

namespace TerraSdk.Core.Distribution.Msgs
{
    /// <summary>
    ///     Msg struct for delegation withdraw from a single validator.
    /// </summary>
    public class MsgWithdrawDelegatorReward : Msg
    {
        public MsgWithdrawDelegatorReward()
        {
        }

        public MsgWithdrawDelegatorReward(string delegatorAddress, string validatorAddress)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
        }

        [JsonProperty("delegator_address")] public string DelegatorAddress { get; set; } = null!;

        [JsonProperty("validator_address")] public string ValidatorAddress { get; set; } = null!;

        public object SignBytesObject()
        {
            return this;
        }
    }
}