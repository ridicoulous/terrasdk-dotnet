using Newtonsoft.Json;
using TerraSdk.Common.Types.BigDecimal;

namespace TerraSdk.ClientOld.ModelsOld
{
    /// <summary>
    ///     CommissionRates defines the initial commission rates to be used for creating a
    ///     validator.
    /// </summary>
    public class CommissionRates
    {
        public CommissionRates()
        {
        }

        public CommissionRates(BigDecimal rate, BigDecimal maxRate, BigDecimal maxChangeRate)
        {
            Rate = rate;
            MaxRate = maxRate;
            MaxChangeRate = maxChangeRate;
        }

        /// <summary>
        ///     The commission rate charged to delegators, as a fraction.
        /// </summary>
        [JsonProperty("rate")]
        public BigDecimal Rate { get; set; }

        /// <summary>
        ///     Maximum commission rate which validator can ever charge, as a fraction.
        /// </summary>
        [JsonProperty("max_rate")]
        public BigDecimal MaxRate { get; set; }

        /// <summary>
        ///     Maximum daily increase of the validator commission, as a fraction.
        /// </summary>
        [JsonProperty("max_change_rate")]
        public BigDecimal MaxChangeRate { get; set; }
    }
}