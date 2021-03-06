using System;
using System.Numerics;
using Newtonsoft.Json;
using TerraSdk.Common.Serialization;

namespace TerraSdk.Core.Staking.Msgs
{
    public class UnbondingDelegationEntry
    {
        public UnbondingDelegationEntry()
        {
        }

        public UnbondingDelegationEntry(long creationHeight, DateTimeOffset completionTime, BigInteger initialBalance, BigInteger balance)
        {
            CreationHeight = creationHeight;
            CompletionTime = completionTime;
            InitialBalance = initialBalance;
            Balance = balance;
        }

        /// <summary>
        ///     Height which the unbonding took place.
        /// </summary>
        [JsonProperty("creation_height")]
        [JsonConverter(typeof(StringNumberConverter))]
        public long CreationHeight { get; set; }

        /// <summary>
        ///     Time at which the unbonding delegation will complete.
        /// </summary>
        [JsonProperty("completion_time")]
        public DateTimeOffset CompletionTime { get; set; }

        /// <summary>
        ///     Atoms initially scheduled to receive at completion.
        /// </summary>
        [JsonProperty("initial_balance")]
        [JsonConverter(typeof(StringNumberConverter))]
        public BigInteger InitialBalance { get; set; }

        /// <summary>
        ///     Atoms to receive at completion.
        /// </summary>
        [JsonProperty("balance")]
        [JsonConverter(typeof(StringNumberConverter))]
        public BigInteger Balance { get; set; }
    }
}