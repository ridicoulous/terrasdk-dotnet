using Newtonsoft.Json;

namespace TerraSdk.Client.Api.Tendermint
{
    public class NodeSyncingStatus
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     NodeSyncingStatus
        ///     class.
        /// </summary>
        public NodeSyncingStatus()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     NodeSyncingStatus
        ///     class.
        /// </summary>
        public NodeSyncingStatus(bool? syncing)
        {
            Syncing = syncing;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "syncing")]
        public bool? Syncing { get; set; }
    }
}