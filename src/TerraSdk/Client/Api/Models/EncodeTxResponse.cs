using Newtonsoft.Json;
using TerraSdk.Client.Api.Serialization;

namespace TerraSdk.Client.Api.Models
{
    public class EncodeTxResponse
    {
        /// <summary>
        /// Initializes a new instance of the
        /// EncodeTxResponse
        /// class.
        /// </summary>
        public EncodeTxResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// EncodeTxResponse
        /// class.
        /// </summary>
        public EncodeTxResponse(byte[] tx)
        {
            Tx = tx;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx")]
        [JsonConverter(typeof(Base64StringByteArrayConverter))]
        public byte[] Tx { get; set; } = null!;

    }
}
