using System.Collections.Generic;
using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.ClientOld.ModelsOld
{
    /// <summary>
    ///     Input models transaction input.
    /// </summary>
    public class Input
    {
        public Input()
        {
        }

        public Input(string accAddress, IList<Coin> coins)
        {
            AccAddress = accAddress;
            Coins = coins;
        }

        [JsonProperty("address")] public string AccAddress { get; set; } = null!;

        [JsonProperty("coins")] public IList<Coin> Coins { get; set; } = null!;
    }
}