using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json.Linq;
using TerraSdk.Common.Helpers;
using Xunit;

namespace TerraSdk.Test.Utils
{
    public static class CompareExtensions
    {
        public static void ShouldCompareTo<T1, T2>(this T1 actual, T2 expected, CompareLogic compareLogic = null)
        {
            compareLogic = compareLogic ?? new CompareLogic { Config = new ComparisonConfig { MaxDifferences = 100 } };

            var result = compareLogic.Compare(actual, expected);

            Assert.True(result.AreEqual, result.DifferencesString);
        }

        public static void JsonCompareObj(string json1, string json2)
        {
            Assert.True(JToken.DeepEquals(JToken.Parse(json1), JToken.Parse(json2)));
        }

        public static void CompareObj(object obj1, object obj2)
        {
            Assert.True(JToken.DeepEquals(JToken.Parse(obj1.ToJson()), JToken.Parse(obj2.ToJson())));
        }


        public static void JsonCompareText(string json1, string json2)
        {
            Assert.Equal(json1.FormatJson(), json2.FormatJson());
        }
    }
}