using System;
using Newtonsoft.Json;

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
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }


    }
}
