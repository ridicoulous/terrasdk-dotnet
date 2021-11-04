using Newtonsoft.Json;
using TerraSdk.Core.Bank;

namespace TerraSdk.Client.Api
{
    public class Pagination
    {
        [JsonProperty(PropertyName = "next_key")]
        public string? NextKey { get; set; }

        [JsonProperty(PropertyName = "total"), JsonConverter(typeof(StringJsonConverter))]
        public int Total { get; set; }
    }
}
