using System.Collections.Generic;
using Newtonsoft.Json;

namespace TerraSdk.ClientOld.ModelsOld
{
    public class BlockData
    {
        public BlockData()
        {
        }
        
        public BlockData(IList<string>? transactions)
        {
            Transactions = transactions;
        }

        [JsonProperty(PropertyName = "txs")]
        public IList<string>? Transactions { get; set; }
    }
}