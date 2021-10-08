using Newtonsoft.Json;
using TerraSdk.Client.Api.Serialization;

namespace TerraSdk.Client.Api.Models
{
    public class BlockIDParts
    {
        /// <summary>
        /// Initializes a new instance of the BlockIDParts class.
        /// </summary>
        public BlockIDParts()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BlockIDParts class.
        /// </summary>
        public BlockIDParts(int? total, byte[] hash)
        {
            Total = total;
            Hash = hash;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] Hash { get; set; } = null!;
    }
}
