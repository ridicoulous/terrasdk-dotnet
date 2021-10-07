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

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

    }
}
