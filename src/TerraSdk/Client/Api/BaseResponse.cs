using Newtonsoft.Json;

namespace TerraSdk.Client.Api
{
    public abstract  class BaseResponse
    {
        [JsonProperty(PropertyName = "pagination")]
        public Pagination? Pagination { get; set; }
    }
}