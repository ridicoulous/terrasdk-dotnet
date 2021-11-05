using System.Collections.Generic;
using Newtonsoft.Json;

namespace TerraSdk.Core.Gov.Msgs
{
    public class MsgSubmitProposal : Msg
    {
        public MsgSubmitProposal()
        {
        }

        public MsgSubmitProposal(IProposalContent content, IList<Coin> initialDeposit, string proposer)
        {
            Content = content;
            InitialDeposit = initialDeposit;
            Proposer = proposer;
        }

        [JsonProperty("content")] public IProposalContent Content { get; set; } = null!;

        /// <summary>
        ///     Initial deposit paid by sender. Must be strictly positive.
        /// </summary>
        [JsonProperty("initial_deposit")]
        public IList<Coin> InitialDeposit { get; set; } = null!;

        /// <summary>
        ///     Address of the proposer.
        /// </summary>
        [JsonProperty("proposer")]
        public string Proposer { get; set; } = null!;

        public object SignBytesObject()
        {
            return this;
        }
    }
}