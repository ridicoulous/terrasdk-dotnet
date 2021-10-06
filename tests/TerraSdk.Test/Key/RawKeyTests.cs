using System.Linq;
using System.Resources;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using TerraSdk.Common;
using TerraSdk.Key;
using Xunit;
using ExtensionsForTesting = TerraSdk.Test.Utils.ExtensionsForTesting;

namespace TerraSdk.Test.Key
{
    public class RawKeyTests
    {
        [Fact]
        public void RawKey_derives_correct_key_information()
        {
            var examples =
                new[]
                {
                    new()
                    {
                        Mnemonic = "wonder caution square unveil april art add hover spend smile proud admit modify old copper throw crew happy nature luggage reopen exhibit ordinary napkin",
                        AccAddress = "terra1jnzv225hwl3uxc5wtnlgr8mwy6nlt0vztv3qqm",
                        AccPubKey = "terrapub1addwnpepqt8ha594svjn3nvfk4ggfn5n8xd3sm3cz6ztxyugwcuqzsuuhhfq5nwzrf9",
                        ValAddress = "terravaloper1jnzv225hwl3uxc5wtnlgr8mwy6nlt0vztraasg",
                        ValPubKey = "terravaloperpub1addwnpepqt8ha594svjn3nvfk4ggfn5n8xd3sm3cz6ztxyugwcuqzsuuhhfq5y7accr"
                    },
                    new Data
                    {
                        Mnemonic =
                            "speak scatter present rice cattle sight amateur novel dizzy wheel cannon mango model sunset smooth appear impose want lunar tattoo theme zero misery flower",
                        AccAddress = "terra1ghvjx8jyn3m4v94nwdzjjevlsqz3uevvvhvedp",
                        AccPubKey =
                            "terrapub1addwnpepqdavy7mkxxjl8dd5mck7tef8rrxmmhzs3ts0grn3laczdjstt6vtjfsumau",
                        ValAddress = "terravaloper1ghvjx8jyn3m4v94nwdzjjevlsqz3uevvvcqyaj",
                        ValPubKey =
                            "terravaloperpub1addwnpepqdavy7mkxxjl8dd5mck7tef8rrxmmhzs3ts0grn3laczdjstt6vtj7qrqv6"
                    },
                    new Data
                    {
                        Mnemonic = "pool december kitchen crouch robot relax oppose system virtual spread pistol obtain vicious bless salmon drive repeat when frost summer render shed bone limb",
                        AccAddress = "terra1a3l5xudduhrk43whxm65hpyh3lqspx94vhlx6h",
                        AccPubKey =
                            "terrapub1addwnpepqvaz9qpllrwu7l4nf3wzgnz6vn54x4snsw7r7kfmygf06dq2tjkc2plmywj",
                        ValAddress = "terravaloper1a3l5xudduhrk43whxm65hpyh3lqspx94vcnm2y",
                        ValPubKey =
                            "terravaloperpub1addwnpepqvaz9qpllrwu7l4nf3wzgnz6vn54x4snsw7r7kfmygf06dq2tjkc2k0yll5"
                    }
                };


            foreach (var exm in examples)
            {
                // ExtensionsForTesting.Dump(exm);

                var mk = new MnemonicKey(new MnemonicKeyOptions { Mnemonic = exm.Mnemonic });
                var rk = new RawKey(mk.PrivateKey);
                
                Assert.Equal(exm.AccAddress, rk.AccAddress.Value);
                Assert.Equal(exm.AccPubKey, rk.AccPubKey.Value);
                Assert.Equal(exm.ValAddress, rk.ValAddress.Value);
                Assert.Equal(exm.ValPubKey, rk.ValPubKey.Value);
            }
        }

        [Fact]
        public void RawKey_signature()
        {

            var mk = new MnemonicKey(new MnemonicKeyOptions() { Mnemonic = "island relax shop such yellow opinion find know caught erode blue dolphin behind coach tattoo light focus snake common size analyst imitate employ walnut" });
            var rk = new RawKey(mk.PrivateKey);
            var accAddress = rk.AccAddress;
            
//            var msgSend = new MsgSend(accAddress, "terra1wg2mlrxdmnnkkykgqg4znky86nyrtc45q336yv", new Coins() { { "uluna", "100000000" } });
        
//              var fee = new StdFee(46467, new Coins({ uluna: '698' }));
//              var stdSignMsg = new StdSignMsg("columbus-3-testnet", 45, 0, fee, [msgSend,]);

//  var signature = rk.CreateSignature(stdSignMsg);
//expect(signature).toEqual(
//    'FJKAXRxNB5ruqukhVqZf3S/muZEUmZD10fVmWycdVIxVWiCXXFsUy2VY2jINEOUGNwfrqEZsT2dUfAvWj8obLg=='
//);



            //var mk = new MnemonicKey({
            //      mnemonic:
            //      'island relax shop such yellow opinion find know caught erode blue dolphin behind coach tattoo light focus snake common size analyst imitate employ walnut',
            //  });
            //  const rk = new RawKey(mk.privateKey);
            //  const { accAddress
            //  } = rk;

            //  const msgSend = new MsgSend(
            //          accAddress,
            //          'terra1wg2mlrxdmnnkkykgqg4znky86nyrtc45q336yv',
            //          new Coins({ uluna: '100000000' })
            //      );

            //  const fee = new StdFee(46467, new Coins({ uluna: '698' }));
            //  const stdSignMsg = new StdSignMsg('columbus-3-testnet', 45, 0, fee, [
            //      msgSend,

            //  ]);

            //  const { signature } = await rk.createSignature(stdSignMsg);
            //  expect(signature).toEqual(
            //      'FJKAXRxNB5ruqukhVqZf3S/muZEUmZD10fVmWycdVIxVWiCXXFsUy2VY2jINEOUGNwfrqEZsT2dUfAvWj8obLg=='
            //  );
        }

    public class Data
        {
            public string Mnemonic { get; set; }
            public string AccAddress { get; set; }
            public string AccPubKey { get; set; }
            public string ValAddress { get; set; }
            public string ValPubKey { get; set; }
        }
    }
}