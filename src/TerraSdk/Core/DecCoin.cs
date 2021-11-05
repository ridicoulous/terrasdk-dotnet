using Newtonsoft.Json;
using TerraSdk.Common.Types.BigDecimal;

namespace TerraSdk.Core
{
    /// <summary>
    ///     DecCoin defines a coin which can have additional decimal points.
    /// </summary>
    public class DecCoin
    {
        public DecCoin()
        {
        }

        public DecCoin(string denom, BigDecimal amount)
        {
            Denom = denom;
            Amount = amount;
        }

        [JsonProperty("denom")] public string Denom { get; set; } = null!;

        [JsonProperty("amount")] public BigDecimal Amount { get; set; }
    }
}