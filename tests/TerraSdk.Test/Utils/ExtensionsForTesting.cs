using Newtonsoft.Json;
using System;
using Xunit.Abstractions;

namespace TerraSdk.Test.Utils
{
    public static class ExtensionsForTesting
    {
        public static void DumpToConsole(this object obj)
        {
            Console.WriteLine(obj.DumpToString());
        }

        public static string DumpToString(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static void DumpToConsole(this ITestOutputHelper console, object obj)
        {
            Console.WriteLine(obj.DumpToString());
        }
    }
}