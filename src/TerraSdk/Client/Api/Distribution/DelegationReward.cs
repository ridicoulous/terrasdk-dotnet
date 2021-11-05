using System.Collections.Generic;
using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.Client.Api.Distribution
{
    public class DelegationReward
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reward")]
        public IList<Coin> Reward { get; set; } = null!;

        /// <summary>
        /// Initializes a new instance of the DelegationReward class.
        /// </summary>
        public DelegationReward()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DelegationReward class.
        /// </summary>
        public DelegationReward(string validatorAddress, IList<Coin> reward)
        {
            ValidatorAddress = validatorAddress;
            Reward = reward;
        }
    }
}
