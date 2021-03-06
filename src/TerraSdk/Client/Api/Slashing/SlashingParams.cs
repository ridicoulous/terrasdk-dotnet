using Newtonsoft.Json;
using TerraSdk.Common.Types.BigDecimal;

namespace TerraSdk.Client.Api.Slashing
{
    /// <summary>
    ///     Params - used for initializing default parameter for slashing at genesis.
    /// </summary>
    public class SlashingParams
    {
        public SlashingParams()
        {
        }

        public SlashingParams(long maxEvidenceAge, long signedBlocksWindow, BigDecimal minSignedPerWindow, long downtimeJailDuration,
            BigDecimal slashFractionDoubleSign, BigDecimal slashFractionDowntime)
        {
            MaxEvidenceAge = maxEvidenceAge;
            SignedBlocksWindow = signedBlocksWindow;
            MinSignedPerWindow = minSignedPerWindow;
            DowntimeJailDuration = downtimeJailDuration;
            SlashFractionDoubleSign = slashFractionDoubleSign;
            SlashFractionDowntime = slashFractionDowntime;
        }

        /// <summary>
        ///     Duration in nanoseconds.
        /// </summary>
        [JsonProperty("max_evidence_age")]
        public long MaxEvidenceAge { get; set; }

        [JsonProperty("signed_blocks_window")] public long SignedBlocksWindow { get; set; }

        [JsonProperty("min_signed_per_window")]
        public BigDecimal MinSignedPerWindow { get; set; }

        /// <summary>
        ///     Duration in nanoseconds.
        /// </summary>
        [JsonProperty("downtime_jail_duration")]
        public long DowntimeJailDuration { get; set; }

        [JsonProperty("slash_fraction_double_sign")]
        public BigDecimal SlashFractionDoubleSign { get; set; }

        [JsonProperty("slash_fraction_downtime")]
        public BigDecimal SlashFractionDowntime { get; set; }
    }
}