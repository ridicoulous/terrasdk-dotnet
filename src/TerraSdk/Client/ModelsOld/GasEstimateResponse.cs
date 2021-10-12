﻿using Newtonsoft.Json;
using TerraSdk.Common.Serialization;

namespace TerraSdk.Client.ModelsOld
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