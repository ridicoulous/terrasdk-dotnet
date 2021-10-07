using System;
using Newtonsoft.Json;
using TerraSdk.Common.Helpers;

namespace TerraSdk.Common
{
    public static class ExtensionsForTesting
    {
        public static void Dump(this object obj)
        {
            Console.WriteLine(obj.DumpString());
        }

        public static void DumpHex(this byte[] data)
        {
            Console.WriteLine(data.ToHexFromByteArray());
        }

        public static string DumpString(this object obj)
        {
            if (obj is string)
            {
                return obj.ToString();
            }

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore, 
                Formatting = Formatting.Indented
            });
        }

    }
}
