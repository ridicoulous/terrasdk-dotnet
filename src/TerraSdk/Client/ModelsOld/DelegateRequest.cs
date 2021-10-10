using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.Client.ModelsOld
{
    public class DelegateRequest
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;

        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;

        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        [JsonProperty("amount")]
        public Coin Amount { get; set; } = null!;


        public DelegateRequest()
        {
        }

        public DelegateRequest(BaseReq baseReq, string delegatorAddress, string validatorAddress, Coin amount)
        {
            BaseReq = baseReq;
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Amount = amount;
        }
    }
}