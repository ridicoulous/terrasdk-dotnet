using Newtonsoft.Json;

namespace TerraSdk.Common.Helpers
{
    public static class JsonHelpers
    {
        public  static string FormatJson(this string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}
