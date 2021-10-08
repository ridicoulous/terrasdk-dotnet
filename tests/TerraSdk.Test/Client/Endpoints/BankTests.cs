using System.Threading.Tasks;
using TerraSdk.Test.Utils;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Client.Endpoints
{
    public class BankTests : BaseTestClient
    {
        public BankTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task Balance_account_exists()
        {
            using var client = CreateClient("https://bombay-lcd.terra.dev/");
            var balance = await client.Bank.GetBalanceAsync("terra1wg2mlrxdmnnkkykgqg4znky86nyrtc45q336yv");

            balance.Dump();
            
            Assert.True(balance.Height>0);
   
        }

        [Fact]
        public void Balance_total_supply()
        {

        }
    }
}

//import
//{ APIRequester }
//from '../APIRequester';
//import
//{ BankAPI }
//from './BankAPI';
//import
//{ Coins }
//from '../../../core';

//const c = new APIRequester('https://bombay-lcd.terra.dev/');
//const bank = new BankAPI(c);

//describe('BankAPI', () => {
//    describe('balance', () => {
//        it('account exists', async () => {
//            await bank.balance('terra1ax7xtll5v6u6vdnymxa4k4648w80zhkggl0u24');
//        });

//        it('invalid account', async () => {
//            await expect(bank.balance('1234')).rejects.toThrow();
//        });
//    });

//    it('total supply', async () => {
//        const totalSupply = await bank.total();
//        expect(totalSupply).toEqual(expect.any(Coins));
//    });
//});
