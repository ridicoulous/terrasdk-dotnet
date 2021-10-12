using System;
using System.Text.Json;
using System.Threading.Tasks;
using TerraSdk.Client;
using TerraSdk.Common;
using TerraSdk.Common.Exceptions;
using TerraSdk.Common.Helpers;
using TerraSdk.Test.Utils;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Client.Endpoints
{
    public class BankTests : BaseTestClient
    {
        private readonly ITerraApiClient client;

        public BankTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            client = CreateClient("https://bombay-lcd.terra.dev/");
        }

        ~BankTests()
        {
            client.Dispose();
        }


        [Fact]
        public async Task Balance_account_exists()
        {
     
            var balance = await client.BankApiService.GetBalanceAsync("terra1wg2mlrxdmnnkkykgqg4znky86nyrtc45q336yv");
            balance.DumpToConsole();
            Assert.NotNull(balance);

        }


        [Fact]
        public async Task Balance_invalid_account()
        {
            
            var ex = await Assert.ThrowsAsync<TerraHttpException>(async () =>
            {
                var balance = await client.BankApiService.GetBalanceAsync("1234");

            });

            ex.Dump();


        }


        [Fact]
        public async Task Balance_total_supply()
        {
            var totalSupply = await client.BankApiService.GetTotalSupplyAsync();
     }

        
    }
}
