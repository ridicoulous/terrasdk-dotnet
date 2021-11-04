using Newtonsoft.Json;

namespace TerraSdk.ClientOld.ModelsOld
{
    public class WithdrawRewardsRequest
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;

        public WithdrawRewardsRequest()
        {
        }

        public WithdrawRewardsRequest(BaseReq baseReq)
        {
            BaseReq = baseReq;
        }
    }
}