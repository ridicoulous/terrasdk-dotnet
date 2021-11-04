using Newtonsoft.Json;

namespace TerraSdk.Client.Api
{
   public class PaginationOptions
    {

        [JsonProperty(PropertyName = "pagination.limit")]
        public string? Limit { get; set; }

        [JsonProperty(PropertyName = "pagination.offset")]
        public string? Offset { get; set; }

        [JsonProperty(PropertyName = "pagination.key")]
        public string? Key { get; set; }

        [JsonProperty(PropertyName = "pagination.limit")]
        public bool? CountTotal { get; set; }

        [JsonProperty(PropertyName = "pagination.reverse")]
        public bool? Reverse { get; set; }
        
    }
}
