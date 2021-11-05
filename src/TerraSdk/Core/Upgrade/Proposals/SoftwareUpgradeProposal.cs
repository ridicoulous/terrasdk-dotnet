using Newtonsoft.Json;

namespace TerraSdk.Core.Upgrade.Proposals
{
    public class SoftwareUpgradeProposal : IProposalContent
    {
        public SoftwareUpgradeProposal()
        {
        }

        public SoftwareUpgradeProposal(string title, string description)
        {
            Title = title;
            Description = description;
        }

        [JsonProperty("title")] public string Title { get; set; } = null!;

        [JsonProperty("description")] public string Description { get; set; } = null!;

        public string GetProposalType()
        {
            return "SoftwareUpgrade";
        }
    }
}