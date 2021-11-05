using Newtonsoft.Json;

namespace TerraSdk.Client.Api.Staking
{
    public class StakingParams
    {
        public StakingParams()
        {
        }

        public StakingParams(long unbondingTime, ushort maxValidators, ushort maxEntries, string bondDenom)
        {
            UnbondingTime = unbondingTime;
            MaxValidators = maxValidators;
            MaxEntries = maxEntries;
            BondDenom = bondDenom;
        }

        /// <summary>
        ///     Nanoseconds count.
        /// </summary>
        [JsonProperty("unbonding_time")]
        public long UnbondingTime { get; set; }

        [JsonProperty("max_validators")] public ushort MaxValidators { get; set; }

        [JsonProperty("max_entries")] public ushort MaxEntries { get; set; }

        [JsonProperty("bond_denom")] public string BondDenom { get; set; } = null!;
    }
}