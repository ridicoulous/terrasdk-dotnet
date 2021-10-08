using System.Threading.Tasks;
using ExpectedObjects;
using TerraSdk.Test.Client.TestData;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Client.Endpoints
{
    public class GaiaRestTest : BaseTest
    {
        public GaiaRestTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }
        
        [Fact]
        public async Task AsyncGetNodeInfoCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var nodeInfo = await client.GaiaRest.GetNodeInfoAsync();
            OutputHelper.WriteLine("Deserialized into");
            Dump(nodeInfo);
            
            NodeInfoData
                .NodeStatus
                .ToExpectedObject()
                .ShouldEqual(nodeInfo);
        }

        [Fact]
        public void SyncGetNodeInfoCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var nodeInfo = client.GaiaRest.GetNodeInfo();
            OutputHelper.WriteLine("Deserialized into");
            Dump(nodeInfo);

            NodeInfoData
                .NodeStatus
                .ToExpectedObject()
                .ShouldEqual(nodeInfo);
        }
    }
}