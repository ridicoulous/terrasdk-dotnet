using System.Threading.Tasks;
using TerraSdk.Client.Api;
using TerraSdk.Client.Api.Bank;
using TerraSdk.Common.Exceptions;

using TerraSdk.Test.Utils;
using Urls;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Client.Api
{
    public class BankTests : BaseClientTest
    {
        private readonly RestClient.Net.Client client;
        private readonly BankApiService bankApiService;

        public BankTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {

            //client = new RestClient.Net.Client(new NewtonsoftSerializationAdapter(), new AbsoluteUrl( "https://bombay-lcd.terra.dev/"));
            //bankApiService = new BankApiService(client);

        }

        public override void Dispose()
        {
            client.Dispose();
            base.Dispose();
        }


  


        [Fact]
        public async Task Balance_account_exists()
        {
     
            var balance = await bankApiService.GetBalanceAsync("terra1wg2mlrxdmnnkkykgqg4znky86nyrtc45q336yv");
            balance.DumpToConsole();
            Assert.NotNull(balance);

        }


        [Fact]
        public async Task Balance_invalid_account()
        {
            
            var ex = await Assert.ThrowsAsync<TerraHttpException>(async () =>
            {
                var balance = await bankApiService.GetBalanceAsync("1234");

            });

            ex.Dump();


        }


        [Fact]
        public async Task Balance_total_supply()
        {
            var totalSupply = await bankApiService.GetTotalSupplyAsync();
     }

        
    }
}
