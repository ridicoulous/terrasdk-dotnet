using Newtonsoft.Json;
using TerraSdk.Client.Api.Gov;

namespace TerraSdk.ClientOld.ModelsOld
{
    public class WithdrawRewardsRequest
    {
        public WithdrawRewardsRequest()
        {
        }

        public WithdrawRewardsRequest(BaseReq baseReq)
        {
            BaseReq = baseReq;
        }

        [JsonProperty("base_req")] public BaseReq BaseReq { get; set; } = null!;
    }
}