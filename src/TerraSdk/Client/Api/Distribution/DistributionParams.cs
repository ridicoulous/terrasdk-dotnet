using Newtonsoft.Json;
using TerraSdk.Common.Types.BigDecimal;

namespace TerraSdk.Client.Api.Distribution
{
    public class DistributionParams
    {
        [JsonProperty("community_tax")]
        public BigDecimal CommunityTax { get; set; }
        [JsonProperty("base_proposer_reward")]
        public BigDecimal BaseProposerReward { get; set; }
        [JsonProperty("bonus_proposer_reward")]
        public BigDecimal BonusProposerReward { get; set; }
        [JsonProperty("withdraw_addr_enabled")]
        public bool WithdrawAddrEnabled { get; set; }

        public DistributionParams()
        {
        }

        public DistributionParams(BigDecimal communityTax, BigDecimal baseProposerReward, BigDecimal bonusProposerReward, bool withdrawAddrEnabled)
        {
            CommunityTax = communityTax;
            BaseProposerReward = baseProposerReward;
            BonusProposerReward = bonusProposerReward;
            WithdrawAddrEnabled = withdrawAddrEnabled;
        }
    }
}