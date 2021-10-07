using Newtonsoft.Json;
using TerraSdk.Core.Bank.Msgs;

namespace TerraSdk.Core
{
    public class MsgData: IMsg
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public object Value { get; init; }
    }
}