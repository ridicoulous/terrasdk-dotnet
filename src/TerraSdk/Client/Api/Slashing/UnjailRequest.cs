using Newtonsoft.Json;
using TerraSdk.Client.Api.Gov;

namespace TerraSdk.Client.Api.Slashing
{
    /// <summary>
    ///     Unjail TX body.
    /// </summary>
    public class UnjailRequest
    {
        public UnjailRequest()
        {
        }

        public UnjailRequest(BaseReq baseReq)
        {
            BaseReq = baseReq;
        }

        [JsonProperty("base_req")] public BaseReq BaseReq { get; set; } = null!;
    }
}