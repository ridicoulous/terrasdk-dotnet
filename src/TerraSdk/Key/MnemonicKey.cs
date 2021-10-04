using System;
using TerraSdk.Crypto.Bip32;
using TerraSdk.Crypto.Bip39;
using TerraSdk.Crypto.Util.Common;
using TerraSdk.Util;

namespace TerraSdk.Key
{
    public class MnemonicKey : RawKey
    {

        private MnemonicKey(byte[] privateKey) : base(privateKey)
        {
        }
        public string Mnemonic { get; private init; }

        public static MnemonicKey New(MnemonicKeyOptions options)
        {
            var bip39 = new Bip39();
            var bip32 = new Bip32();

            var mnemonic = options.Mnemonic;

            if (mnemonic == null)
            {
                mnemonic= bip39.GenerateMnemonic(256, Bip39Wordlist.English);
            }

            Console.WriteLine(mnemonic);

            var seed = bip39.MnemonicToSeed(mnemonic, "");

            //seed.Dump();

            // var masterKey = bip32.GetMasterKeyFromSeed(seed);

           // Console.WriteLine(masterKey.Key.ToHex());

            var hdPathLuna = $"m/44'/{options.CoinType}'/{options.Account}'/0'/{options.Index}'";
            Console.WriteLine(hdPathLuna);
            
            var terraHd = bip32.DerivePath(hdPathLuna, seed);
            var privateKey = terraHd.Key;

            var m = new MnemonicKey(privateKey)
            {
                Mnemonic = mnemonic
            };
            return m;
        }

   
    }
}