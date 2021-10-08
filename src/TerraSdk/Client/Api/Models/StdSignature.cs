using Newtonsoft.Json;
using TerraSdk.Client.Api.Serialization;

namespace TerraSdk.Client.Api.Models
{
    public class StdSignature
    {
        /// <summary>
        /// Initializes a new instance of the StdSignature class.
        /// </summary>
        public StdSignature()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StdSignature class.
        /// </summary>
        public StdSignature(byte[] signature, PublicKey? pubKey)
        {
            Signature = signature;
            PubKey = pubKey;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        [JsonConverter(typeof(Base64StringByteArrayConverter))]
        public byte[] Signature { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pub_key")]
        public PublicKey? PubKey { get; set; }
    }
}
