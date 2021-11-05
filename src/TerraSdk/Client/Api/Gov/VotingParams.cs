using Newtonsoft.Json;

namespace TerraSdk.Client.Api.Gov
{
    /// <summary>
    ///     Param around Voting in governance.
    /// </summary>
    public class VotingParams
    {
        public VotingParams()
        {
        }

        public VotingParams(long? votingPeriod)
        {
            VotingPeriod = votingPeriod;
        }

        /// <summary>
        ///     Length of the voting period in nanoseconds.
        /// </summary>
        [JsonProperty("voting_period")]
        public long? VotingPeriod { get; set; }
    }
}