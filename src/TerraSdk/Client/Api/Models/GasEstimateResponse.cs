using Newtonsoft.Json;
using TerraSdk.Client.Api.Serialization;

namespace TerraSdk.Client.Api.Models
{
    public class GasEstimateResponse
    {
        [JsonProperty("gas_estimate")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong GasEstimate { get; set; }

        public GasEstimateResponse()
        {
        }

        public GasEstimateResponse(ulong gasEstimate)
        {
            GasEstimate = gasEstimate;
        }
    }
}