using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TerraSdk.Client.Model;
using TerraSdk.Core;

namespace TerraSdk.Client.Endpoints.Bank
{
    public class Balance
    {
        [JsonProperty(PropertyName = "balances")]
        public Coins? Balances { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public Pagination? Pagination { get; set; }
    }
}
