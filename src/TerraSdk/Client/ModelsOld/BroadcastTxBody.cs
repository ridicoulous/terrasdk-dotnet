using Newtonsoft.Json;
using TerraSdk.Common.Serialization;
using TerraSdk.Core;

namespace TerraSdk.Client.ModelsOld
{
    public class BroadcastTxBody
    {
        /// <summary>
        /// Initializes a new instance of the
        /// BroadcastTxBody class.
        /// </summary>
        public BroadcastTxBody()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// BroadcastTxBody class.
        /// </summary>
        public BroadcastTxBody(StdTx tx, BroadcastTxMode mode)
        {
            Tx = tx;
            Mode = mode;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx")]
        [JsonConverter(typeof(TypeValueConverter<ITx>), true)]
        public StdTx Tx { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public BroadcastTxMode Mode { get; set; }

    }
}
