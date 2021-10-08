using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TerraSdk.Common.Helpers;
using TerraSdk.Core;
using TerraSdk.Core.Account;
using TerraSdk.Core.Bank.Msgs;
using TerraSdk.Key;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Key
{
    public class RawKeyTests : BaseTest
    {
        public RawKeyTests(ITestOutputHelper output) : base(output)
        {
        }
        public class Data
        {
            public string Mnemonic { get; set; }
            public string AccAddress { get; set; }
            public string AccPubKey { get; set; }
            public string ValAddress { get; set; }
            public string ValPubKey { get; set; }
        }
        
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
            var mk = new MnemonicKey(new MnemonicKeyOptions { Mnemonic = "island relax shop such yellow opinion find know caught erode blue dolphin behind coach tattoo light focus snake common size analyst imitate employ walnut" });
            var rk = new RawKey(mk.PrivateKey);
            var accAddress = rk.AccAddress;

            var msgSend = new MsgSend(accAddress, new AccAddress("terra1wg2mlrxdmnnkkykgqg4znky86nyrtc45q336yv"), new Coins(new List<Coin> { new( "uluna", 100000000 )}));
            var fee = new StdFee(46467, new Coins(new List<Coin> { new("uluna", 698) }));
            var stdSignMsg = new StdSignMsg("columbus-3-testnet", 45, 0, fee, new [] {msgSend});

            var dataOutJson = stdSignMsg.ToJson();

            Output.WriteLine("Generated JSON:");
            Output.WriteLine(dataOutJson.FormatJson());

            var testJson =  File.ReadAllText("../../../Key/RawKey_StdSignMsg.json");
            
            Assert.True(JToken.DeepEquals(JToken.Parse(dataOutJson), JToken.Parse(dataOutJson)));
            Assert.Equal(testJson.FormatJson(Formatting.None), dataOutJson);
            
            var jsonBytes = dataOutJson.ToByteArrayFromString();
            Assert.Equal("7b226163636f756e745f6e756d626572223a223435222c22636861696e5f6964223a22636f6c756d6275732d332d746573746e6574222c22666565223a7b22616d6f756e74223a5b7b22616d6f756e74223a22363938222c2264656e6f6d223a22756c756e61227d5d2c22676173223a223436343637227d2c226d656d6f223a22222c226d736773223a5b7b2274797065223a2262616e6b2f4d736753656e64222c2276616c7565223a7b22616d6f756e74223a5b7b22616d6f756e74223a22313030303030303030222c2264656e6f6d223a22756c756e61227d5d2c2266726f6d5f61646472657373223a227465727261316e336733376473646c763772797166746c6b6566386d6867716a346e793770387637386c6737222c22746f5f61646472657373223a227465727261317767326d6c7278646d6e6e6b6b796b677167347a6e6b7938366e797274633435713333367976227d7d5d2c2273657175656e6365223a2230227d", jsonBytes.ToHexFromByteArray());

            var signature = rk.CreateSignature(stdSignMsg);
          
            Assert.Equal("FJKAXRxNB5ruqukhVqZf3S/muZEUmZD10fVmWycdVIxVWiCXXFsUy2VY2jINEOUGNwfrqEZsT2dUfAvWj8obLg==", signature.Signature);
        }

    }
}