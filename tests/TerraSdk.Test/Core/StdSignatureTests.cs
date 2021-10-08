using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TerraSdk.Common.Helpers;
using TerraSdk.Core;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Core
{
    public class StdSignatureTests : BaseTest
    {
        public StdSignatureTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void StdSignature_deserializes_correctly()
        {
            var signatureJson = @"{
            signature:
                '+SnQyRQZ536m0VLTwWFn6WTlmV0ZP+EI08lIGbZFhvYMLPA+Dld3qaTFKwgJEd7kZrAb5OPWBUhiOc9326daEw==',
                pub_key:
                {
                type: 'tendermint/PubKeySecp256k1',
                    value: 'Ar+guke5UuM2XEZ9/ouPhAQbYs+f7y6jQCtGlI2lj1ZH',
                },
            }".FormatJson();

            Output.WriteLine("Input JSON:");
            Output.WriteLine(signatureJson);

            var data = JsonConvert.DeserializeObject<StdSignature>(signatureJson);
            var dataOutJson = data.ToJson();

            Output.WriteLine("Output JSON:");
            Output.WriteLine(dataOutJson.FormatJson());

            Assert.True(JToken.DeepEquals(JToken.Parse(signatureJson), JToken.Parse(dataOutJson)));
        }
    }
}