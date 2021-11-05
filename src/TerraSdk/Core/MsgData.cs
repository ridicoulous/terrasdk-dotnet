using Newtonsoft.Json;

namespace TerraSdk.Core
{
    public class MsgData
    {
        [JsonProperty("type")] public string Type { get; init; }

        [JsonProperty("value")] public object Value { get; init; }
    }
}