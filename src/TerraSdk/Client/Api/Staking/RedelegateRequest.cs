using Newtonsoft.Json;
using TerraSdk.Client.Api.Gov;
using TerraSdk.Core;

namespace TerraSdk.Client.Api.Staking
{
    /// <summary>
    ///     RedelegateRequest defines the properties of a redelegate request's body.
    /// </summary>
    public class RedelegateRequest
    {
        public RedelegateRequest()
        {
        }

        public RedelegateRequest(BaseReq baseReq, string delegatorAddress, string validatorSrcAddress, string validatorDstAddress, Coin amount)
        {
            BaseReq = baseReq;
            DelegatorAddress = delegatorAddress;
            ValidatorSrcAddress = validatorSrcAddress;
            ValidatorDstAddress = validatorDstAddress;
            Amount = amount;
        }

        [JsonProperty("base_req")] public BaseReq BaseReq { get; set; } = null!;

        [JsonProperty("delegator_address")] public string DelegatorAddress { get; set; } = null!;

        [JsonProperty("validator_src_address")]
        public string ValidatorSrcAddress { get; set; } = null!;

        [JsonProperty("validator_dst_address")]
        public string ValidatorDstAddress { get; set; } = null!;

        [JsonProperty("amount")] public Coin Amount { get; set; } = null!;
    }
}