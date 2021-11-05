using Newtonsoft.Json;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Core.Gov;

namespace TerraSdk.Client.Api.Gov
{
    public class VoteReq
    {
        public VoteReq()
        {
        }

        public VoteReq(BaseReq baseReq, string voter, VoteOption option)
        {
            BaseReq = baseReq;
            Voter = voter;
            Option = option;
        }

        [JsonProperty("base_req")] public BaseReq BaseReq { get; set; } = null!;

        /// <summary>
        ///     Address of the voter.
        /// </summary>
        [JsonProperty("voter")]
        public string Voter { get; set; } = null!;

        [JsonProperty("option")] public VoteOption Option { get; set; }
    }
}