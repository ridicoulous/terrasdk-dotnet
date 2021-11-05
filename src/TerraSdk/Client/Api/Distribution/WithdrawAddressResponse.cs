using Newtonsoft.Json;

namespace TerraSdk.Client.Api.Distribution
{
    public class WithdrawAddressResponse
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "withdraw_address")]
        public string  WithdrawAddress { get; set; }
    }
}