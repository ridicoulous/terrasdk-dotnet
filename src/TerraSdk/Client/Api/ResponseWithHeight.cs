using Newtonsoft.Json;

namespace TerraSdk.Client.Api
{
    public class ResponseWithHeight<TResult>
    {
        public ResponseWithHeight()
        {
        }

        public ResponseWithHeight(long height, TResult result)
        {
            Height = height;
            Result = result;
        }

        [JsonProperty("height")] public long Height { get; set; }

        [JsonProperty("result")] public TResult Result { get; set; } = default!;
    }
}