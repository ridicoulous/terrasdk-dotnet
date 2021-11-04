using System.Collections.Generic;
using Newtonsoft.Json;

namespace TerraSdk.ClientOld.ModelsOld
{
    public class StringEvent
    {
        public StringEvent()
        {
            
        }
        
        public StringEvent(string type, IList<Attribute> attributes)
        {
            Type = type;
            Attributes = attributes;
        }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = null!;
        
        [JsonProperty(PropertyName = "attributes")]
        public IList<Attribute> Attributes { get; set; } = null!;
    }
}