using System.Text;
using Newtonsoft.Json;
using RestClient.Net;
using TerraSdk.Common.Serialization;

namespace TerraSdk.Common.RestClient
{
    public class NewtonsoftSerializationAdapter : ISerializationAdapter
    {
        public NewtonsoftSerializationAdapter()
        {

            JsonConvert.DefaultSettings = JsonSerializerSettings;
            
        }

        private JsonSerializerSettings JsonSerializerSettings()
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
            };

            jsonSerializerSettings.Converters.Add(new BigDecimalConverter());

            return jsonSerializerSettings;
        }


        #region Implementation
            public TResponseBody? Deserialize<TResponseBody>(byte[] responseData, IHeadersCollection? responseHeaders)
        {
            //Note: on some services the headers should be checked for encoding 
            var markup = Encoding.UTF8.GetString(responseData);

            object markupAsObject = markup;

            return typeof(TResponseBody) == typeof(string) ? (TResponseBody)markupAsObject : JsonConvert.DeserializeObject<TResponseBody>(markup);
        }

        public byte[] Serialize<TRequestBody>(TRequestBody value, IHeadersCollection requestHeaders)
        {
            var json = JsonConvert.SerializeObject(value);

            var binary = Encoding.UTF8.GetBytes(json);

            return binary;
        }
        #endregion
    }
}