using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TerraSdk.Core.Bank;

namespace TerraSdk.Client.Model
{
    public class Pagination
    {
        [JsonProperty(PropertyName = "next_key")]
        public string? NextKey { get; set; }

        [JsonProperty(PropertyName = "total"), JsonConverter(typeof(StringJsonConverter))]
        public int Total { get; set; }
    }
}
