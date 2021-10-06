using Newtonsoft.Json;

namespace TerraSdk.Common.Helpers
{
    public static class JsonHelpers
    {
        public static string FormatJson(this string json, Formatting formatting= Formatting.Indented)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, formatting);
        }


    }
}
