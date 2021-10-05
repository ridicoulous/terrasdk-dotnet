using System;
using TerraSdk.Common;
using TerraSdk.Crypto.Bip32x;
using TerraSdk.Crypto.Bip39;

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
// var bip32 = new Bip32();

            var mnemonic = options.Mnemonic;

            if (mnemonic == null)
            {
                mnemonic = bip39.GenerateMnemonic(256, Bip39Wordlist.English);
            }

            var seed = bip39.MnemonicToSeed(mnemonic, null);

            seed.DumpHex();

            var masterKey = Ed25519HdKey.GetMasterKeyFromSeed(seed);

            masterKey.Key.DumpHex();

            var hdPathLuna = $"m/44'/{options.CoinType}'/{options.Account}'/0/{options.Index}";
            Console.WriteLine(hdPathLuna);

            var terraHd = Ed25519HdKey.DerivePath(hdPathLuna, seed);
            var privateKey = terraHd.Key;

            privateKey.DumpHex();

            var m = new MnemonicKey(privateKey)
            {
                Mnemonic = mnemonic
            };
            return m;
        }
    }
}