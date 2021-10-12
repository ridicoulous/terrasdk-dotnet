using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using TerraSdk.Common.Helpers;
using TerraSdk.Core;
using TerraSdk.Core.Account;
using TerraSdk.Core.Bank.Msgs;
using TerraSdk.Key;
using TerraSdk.Test.Utils;
using Xunit;
using Xunit.Abstractions;
using ExtensionsForTesting = TerraSdk.Common.ExtensionsForTesting;

namespace TerraSdk.Test.Key
{
    public class MnemonicKeyTests : BaseTest
    {
        public MnemonicKeyTests(ITestOutputHelper output) : base(output)
        {
        }

        public class Data
        {
            public string? Mnemonic { get; set; }
            public string? AccAddress { get; set; }
            public string? AccPubKey { get; set; }
            public string? ValAddress { get; set; }
            public string? ValPubKey { get; set; }
        }

        [Fact]
        public void MnemonicKey_derives_correct_key_information()
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
                // ExtensionsForTesting.DumpToConsole(exm);

                var mk = new MnemonicKey(new MnemonicKeyOptions { Mnemonic = exm.Mnemonic });

                Assert.Equal(exm.AccAddress, mk.AccAddress.Value);
                Assert.Equal(exm.AccPubKey, mk.AccPubKey.Value);
                Assert.Equal(exm.ValAddress, mk.ValAddress.Value);
                Assert.Equal(exm.ValPubKey, mk.ValPubKey.Value);
            }
        }

        [Fact]
        public void MnemonicKey_generates_random_mnemonic()
        {
            var mk = new MnemonicKey();
            var mk2 = new MnemonicKey();

            Assert.NotEqual(mk.Mnemonic, mk2.Mnemonic);
        }

        [Fact]
        public void MnemonicKey_signature()
        {
            var mk = new MnemonicKey(new MnemonicKeyOptions() { Mnemonic = "island relax shop such yellow opinion find know caught erode blue dolphin behind coach tattoo light focus snake common size analyst imitate employ walnut" });
            var accAddress = mk.AccAddress;
            var msgSend = new MsgSend(accAddress, new AccAddress("terra1wg2mlrxdmnnkkykgqg4znky86nyrtc45q336yv"), new Coins(new List<Coin> { new("uluna", 100000000) }));
            var fee = new StdFee(46467, new Coins(new List<Coin> { new("uluna", 698) }));
            var stdSignMsg = new StdSignMsg("columbus-3-testnet", 45, 0, fee, new Msg[] { msgSend });
            var signature = mk.CreateSignature(stdSignMsg);
           
            Assert.Equal("FJKAXRxNB5ruqukhVqZf3S/muZEUmZD10fVmWycdVIxVWiCXXFsUy2VY2jINEOUGNwfrqEZsT2dUfAvWj8obLg==", signature.Signature);
        }

        [Fact]
        public void MnemonicKey_multisig()
        {
            var receiverAddr = "terra1ptdx6akgk7wwemlk5j73artt5t6j8am08ql3qv";
            var multisigAddr = "terra16ddrexknvk2e443jsnle4n6s2ewjc6z3mjcu6d";
            var multisigAccountNumber = (ulong)46;
            var multisigSequenceNumber = (ulong)0;

            var a1Key = new MnemonicKey("swamp increase solar renew twelve easily possible pig ostrich harvest more indicate lion denial kind target small dumb mercy under proud arrive gentle field");
            Assert.Equal("terra12dazwl3yq6nwrce052ah3fudkarglsgvacyvl9", a1Key.AccAddress.Value);

            var a2Key = new MnemonicKey("service frozen keen unveil luggage initial surge name conduct mesh soup escape weather gas clown brand holiday result protect chat plug false pitch little");
            Assert.Equal("terra1jqw25580qljucyy2xkpp7j02kd4mwx69wvfgf9", a2Key.AccAddress.Value);

            var a3Key = new MnemonicKey("corn peasant blue sight spy three stove confirm night brother vote dish reduce sick observe outside vacant arena laugh devote exotic wasp supply rally");
            Assert.Equal("terra13hrg8ul0p7sh85jwalh3leysdrw9swh44dql2h", a3Key.AccAddress.Value);

            var msgSend = new MsgSend(new AccAddress(multisigAddr), new AccAddress(receiverAddr), new Coins(new List<Coin> { new("uluna", 100000000) }));
            var fee = new StdFee(50000, new Coins(new List<Coin> { new("uluna", 750) }));
            var stdSignMsg = new StdSignMsg("columbus-3-testnet", multisigAccountNumber, multisigSequenceNumber, fee, new Msg[] { msgSend });

            var a1Signature = a1Key.CreateSignature(stdSignMsg);
            Assert.Equal("/kIFqGnmgOqMzf7guoe1eDTA1W5TjJcelJSRBdN0CTRyyxTMIbsxd+wL4fatHAq4hYOTf/zxD4l5xyU7/POZyg==", a1Signature.Signature);

            var a2Signature = a2Key.CreateSignature(stdSignMsg);
            Assert.Equal("hEjv9CnXQa89robHVsHS3GDZJiunnNb8xqziWD8D4aAuBXwxDzUXY14IE7q9Z3Qh0VMb3FBHuogHi7QZn2pM9g==", a2Signature.Signature);

            var a3Signature = a3Key.CreateSignature(stdSignMsg);
            Assert.Equal("CwHdmwC9ADtr5cTUdRZEfAcA8d1bgkF8fB+DcbB6MBB6amJz51WQYfVE1VgVTEY8Lyzg8+s8gX6nkqkXPeX72A==", a3Signature.Signature);

        }

        [Fact]
        public void MnemonicKey_txid()
        {

            var msgSend = new MsgSend(
                new AccAddress("terra1wg2mlrxdmnnkkykgqg4znky86nyrtc45q336yv"),
                new AccAddress("terra18h5pmhrz45z2ne7lz4nfd7cdfwl3jfeu99e7a5"),
                new Coins(new List<Coin>() { new Coin() { Denom = "uluna", Amount = 100000000 } }));

            var fee = new StdFee(54260, new Coins(new List<Coin> { new("ukrw", 814) }));

            var signatureJson = @"{
            signature:
                '+SnQyRQZ536m0VLTwWFn6WTlmV0ZP+EI08lIGbZFhvYMLPA+Dld3qaTFKwgJEd7kZrAb5OPWBUhiOc9326daEw==',
                pub_key:
                {
                type: 'tendermint/PubKeySecp256k1',
                    value: 'Ar+guke5UuM2XEZ9/ouPhAQbYs+f7y6jQCtGlI2lj1ZH',
                },
            }".FormatJson();

            var signature = JsonConvert.DeserializeObject<StdSignature>(signatureJson);
            Debug.Assert(signature != null, nameof(signature) + " != null");
            var stdTx = new StdTx(new Msg[] { msgSend }, fee, new[] { signature }, null, null);
            ExtensionsForTesting.Dump(stdTx.ToData());
        }

        [Fact]
        public void MnemonicKey_multisend()
        {
            var key = new MnemonicKey("spatial fantasy weekend romance entire million celery final moon solid route theory way hockey north trigger advice balcony melody fabric alter bullet twice push");

            var i1 = new MsgMultiSend.Io(key.AccAddress, Coins.From(new Coin( "uluna", 1000000 ), new Coin( "usdr", 1000000 )));

            var o1 = new MsgMultiSend.Io("terra12dazwl3yq6nwrce052ah3fudkarglsgvacyvl9", Coins.From(new Coin("uluna", 500000)));
            var o2 = new MsgMultiSend.Io("terra1ptdx6akgk7wwemlk5j73artt5t6j8am08ql3qv", Coins.From(new Coin("uluna", 500000), new Coin("usdr",1000000)));

            var msgMultiSend = new MsgMultiSend(new []{i1}, new[]{o1,o2});

            //msgMultiSend.ToData().DumpToConsole();

            var fee = new StdFee(100000, Coins.From( new Coin ("uluna", 1500), new Coin( "usdr", 1000) ));
            var stdSignMsg = new StdSignMsg("columbus-3-testnet", 47, 0, fee, new Msg[] { msgMultiSend },"1234");

            var testJson = File.ReadAllText("../../../Key/Mnemonic_StdSignMsg.json");

            CompareExtensions.JsonCompareObj(testJson,stdSignMsg.ToJson());
            Assert.Equal(testJson.FormatJson(), stdSignMsg.ToJson().FormatJson());
            
            var tx = key.SignTx(stdSignMsg);

            // ExtensionsForTesting.DumpToConsole(tx.ToData());

            var newSig = ((StdTx.MsgValue)tx.Value).Signatures[0].Signature;


            Assert.Equal("YA/ToXLxuuAOQlpm5trbIUu2zv5NfBmeHz2jmXgNrt8jP+odukerfri3DUXAJuhETAMHVVV78t7Q4xC0j+CVkA==", newSig);

        }

    }

}
