using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.Client.ModelsOld
{
    /// <summary>
    /// Msg for validator withdraw.
    /// </summary>
    public class MsgWithdrawValidatorCommission : Msg
    {
        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        public MsgWithdrawValidatorCommission()
        {
        }

        public MsgWithdrawValidatorCommission(string validatorAddress)
        {
            ValidatorAddress = validatorAddress;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}