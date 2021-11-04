using Newtonsoft.Json;
using TerraSdk.ClientOld.Model;
using TerraSdk.Core;

namespace TerraSdk.ClientOld.Endpoints.Bank
{
    public class Balance
    {
        [JsonProperty(PropertyName = "balances")]
        public Coins? Balances { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public Pagination? Pagination { get; set; }
    }
}
