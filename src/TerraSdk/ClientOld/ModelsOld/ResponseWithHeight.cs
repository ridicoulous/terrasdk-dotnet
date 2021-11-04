using Newtonsoft.Json;

namespace TerraSdk.ClientOld.ModelsOld
{
    public class ResponseWithHeight<TResult>
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("result")] 
        public TResult Result { get; set; } = default!;

        public ResponseWithHeight()
        {
        }
        
        public ResponseWithHeight(long height, TResult result)
        {
            Height = height;
            Result = result;
        }
    }
}