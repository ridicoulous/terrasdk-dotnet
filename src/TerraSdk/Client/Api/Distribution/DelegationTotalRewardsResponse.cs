using System.Collections.Generic;
using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.Client.Api.Distribution
{
    public class DelegationTotalRewardsResponse : BaseResponse
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rewards")]
        public IList<DelegationReward> Rewards { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public IList<Coin> Total { get; set; } = null!;
        
        /// <summary>
        /// Initializes a new instance of the DelegationRewards class.
        /// </summary>
        public DelegationTotalRewardsResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DelegationRewards class.
        /// </summary>
        public DelegationTotalRewardsResponse(IList<DelegationReward> rewards, IList<Coin> total)
        {
            Rewards = rewards;
            Total = total;
        }
    }
}
