using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.Client.Api.Bank
{
    public class BalanceResponse :BaseResponse
    {
        [JsonProperty(PropertyName = "balances")]
        public Coins? Balances { get; set; }



    }
}
