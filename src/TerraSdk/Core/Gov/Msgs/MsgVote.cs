using Newtonsoft.Json;
using TerraSdk.Common.Serialization;

namespace TerraSdk.Core.Gov.Msgs
{
    public class MsgVote : Msg
    {
        public MsgVote()
        {
        }

        public MsgVote(ulong proposalId, string voter, VoteOption option)
        {
            ProposalId = proposalId;
            Voter = voter;
            Option = option;
        }

        /// <summary>
        ///     ID of the proposal.
        /// </summary>
        [JsonProperty("proposal_id")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong ProposalId { get; set; }

        /// <summary>
        ///     Address of the voter.
        /// </summary>
        [JsonProperty("voter")]
        public string Voter { get; set; } = null!;

        /// <summary>
        ///     Option from OptionSet chosen by the voter.
        /// </summary>
        [JsonProperty("option")]
        public VoteOption Option { get; set; }

        public object SignBytesObject()
        {
            return this;
        }
    }
}