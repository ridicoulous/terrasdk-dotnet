using Newtonsoft.Json;
using TerraSdk.Common.Serialization;

namespace TerraSdk.Client.Api.Gov
{
    public class GasEstimateResponse
    {
        public GasEstimateResponse()
        {
        }

        public GasEstimateResponse(ulong gasEstimate)
        {
            GasEstimate = gasEstimate;
        }

        [JsonProperty("gas_estimate")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong GasEstimate { get; set; }
    }
}