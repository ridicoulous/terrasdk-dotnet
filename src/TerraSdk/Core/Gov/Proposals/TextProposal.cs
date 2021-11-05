using Newtonsoft.Json;

namespace TerraSdk.Core.Gov.Proposals
{
    public class TextProposal : IProposalContent
    {
        public TextProposal()
        {
        }

        public TextProposal(string title, string description)
        {
            Title = title;
            Description = description;
        }

        [JsonProperty("title")] public string Title { get; set; } = null!;

        [JsonProperty("description")] public string Description { get; set; } = null!;

        public string GetProposalType()
        {
            return "Text";
        }
    }
}