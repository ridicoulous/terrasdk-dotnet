using System.Collections.Generic;
using Newtonsoft.Json;
using TerraSdk.Common.Serialization;
using TerraSdk.Core;

namespace TerraSdk.Client.Api.Gov
{
    /// <summary>
    ///     Param around deposits for governance.
    /// </summary>
    public class DepositParams
    {
        public DepositParams()
        {
        }

        public DepositParams(IList<Coin>? minDeposit, long? maxDepositPeriod)
        {
            MinDeposit = minDeposit;
            MaxDepositPeriod = maxDepositPeriod;
        }

        /// <summary>
        ///     Minimum deposit for a proposal to enter voting period.
        /// </summary>
        [JsonProperty("min_deposit")]
        public IList<Coin>? MinDeposit { get; set; }

        /// <summary>
        ///     Maximum period in nanoseconds for Atom holders to deposit on a proposal.
        /// </summary>
        [JsonProperty("max_deposit_period")]
        [JsonConverter(typeof(StringNumberConverter))]
        public long? MaxDepositPeriod { get; set; }
    }
}