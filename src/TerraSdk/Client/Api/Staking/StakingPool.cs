using System.Numerics;
using Newtonsoft.Json;

namespace TerraSdk.Client.Api.Staking
{
    public class StakingPool
    {
        public StakingPool()
        {
        }

        public StakingPool(BigInteger notBondedTokens, BigInteger bondedTokens)
        {
            NotBondedTokens = notBondedTokens;
            BondedTokens = bondedTokens;
        }

        [JsonProperty("not_bonded_tokens")] public BigInteger NotBondedTokens { get; set; }

        [JsonProperty("bonded_tokens")] public BigInteger BondedTokens { get; set; }
    }
}