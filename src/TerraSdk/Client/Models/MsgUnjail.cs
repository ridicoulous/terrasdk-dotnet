using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.Client.Models
{
    /// <summary>
    /// MsgUnjail - for unjailing jailed validator.
    /// </summary>
    public class MsgUnjail : Msg
    {
        /// <summary>
        /// Address of the validator operator.
        /// </summary>
        [JsonProperty("address")]
        public string ValidatorAddr { get; set; } = null!;

        public MsgUnjail()
        {
        }

        public MsgUnjail(string validatorAddr)
        {
            ValidatorAddr = validatorAddr;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}