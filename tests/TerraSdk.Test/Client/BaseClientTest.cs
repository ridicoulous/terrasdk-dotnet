using Xunit.Abstractions;

namespace TerraSdk.Test.Client
{
    public class BaseClientTest : BaseTest
    {
        public BaseClientTest(ITestOutputHelper output) : base(output)
        {



        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
