using System.Collections.Generic;
using Newtonsoft.Json;

namespace TerraSdk.Core.Params.Proposals
{
    /// <summary>
    ///     ParameterChangeProposal defines a proposal which contains multiple parameter
    ///     changes.
    /// </summary>
    public class ParameterChangeProposal : IProposalContent
    {
        public ParameterChangeProposal()
        {
        }

        public ParameterChangeProposal(string title, string description, IList<ParamChange> changes)
        {
            Title = title;
            Description = description;
            Changes = changes;
        }

        [JsonProperty("title")] public string Title { get; set; } = null!;

        [JsonProperty("description")] public string Description { get; set; } = null!;

        [JsonProperty("changes")] public IList<ParamChange> Changes { get; set; } = null!;

        public string GetProposalType()
        {
            return "ParameterChange";
        }
    }
}