using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TerraSdk.Common.Helpers;
using TerraSdk.Core;
using TerraSdk.Core.Bank.Msgs;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Core.Bank.Msgs
{
    public class MsgSendTests : BaseTest
    {
        public MsgSendTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void MsgSend_deserializes_correctly()
        {
            var json = @"{
            type: 'bank/MsgSend',
            value:
                {
                from_address: 'terra1y4umfuqfg76t8mfcff6zzx7elvy93jtp4xcdvw',
                to_address: 'terra1v9ku44wycfnsucez6fp085f5fsksp47u9x8jr4',
                amount:
                    [
                        {
                            denom: 'uluna',
                            amount: '8102024952',
                        },
                    ],
                },
            }".FormatJson();

            Output.WriteLine("Input JSON:");
            Output.WriteLine(json);

            var data = JsonConvert.DeserializeObject<MsgData>(json);

            Debug.Assert(data != null, nameof(data) + " != null");
            var send = MsgSend.FromData(data);

            var toData = send.ToData();

            var dataOutJson = toData.ToJson();

            Output.WriteLine("Output JSON:");
            Output.WriteLine(dataOutJson.FormatJson());

            Assert.True(JToken.DeepEquals(JToken.Parse(json), JToken.Parse(dataOutJson)));
        }
    }
}