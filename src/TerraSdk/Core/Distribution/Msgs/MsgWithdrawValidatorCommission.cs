using Newtonsoft.Json;

namespace TerraSdk.Core.Distribution.Msgs
{
    /// <summary>
    ///     Msg for validator withdraw.
    /// </summary>
    public class MsgWithdrawValidatorCommission : Msg
    {
        public MsgWithdrawValidatorCommission()
        {
        }

        public MsgWithdrawValidatorCommission(string validatorAddress)
        {
            ValidatorAddress = validatorAddress;
        }

        [JsonProperty("validator_address")] public string ValidatorAddress { get; set; } = null!;

        public object SignBytesObject()
        {
            return this;
        }
    }
}