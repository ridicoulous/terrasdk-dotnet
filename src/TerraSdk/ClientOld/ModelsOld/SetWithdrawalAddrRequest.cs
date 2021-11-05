using Newtonsoft.Json;
using TerraSdk.Client.Api.Gov;

namespace TerraSdk.ClientOld.ModelsOld
{
    public class SetWithdrawalAddrRequest
    {
        public SetWithdrawalAddrRequest()
        {
        }

        public SetWithdrawalAddrRequest(BaseReq baseReq, string withdrawAddress)
        {
            BaseReq = baseReq;
            WithdrawAddress = withdrawAddress;
        }

        [JsonProperty("base_req")] public BaseReq BaseReq { get; set; } = null!;

        [JsonProperty("withdraw_address")] public string WithdrawAddress { get; set; } = null!;
    }
}