using Newtonsoft.Json;

namespace TerraSdk.Core.Slashing.Msgs
{
    /// <summary>
    ///     MsgUnjail - for unjailing jailed validator.
    /// </summary>
    public class MsgUnjail : Msg
    {
        public MsgUnjail()
        {
        }

        public MsgUnjail(string validatorAddr)
        {
            ValidatorAddr = validatorAddr;
        }

        /// <summary>
        ///     Address of the validator operator.
        /// </summary>
        [JsonProperty("address")]
        public string ValidatorAddr { get; set; } = null!;

        public object SignBytesObject()
        {
            return this;
        }
    }
}