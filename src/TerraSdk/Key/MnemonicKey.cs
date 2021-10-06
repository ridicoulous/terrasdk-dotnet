using NBitcoin;
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

            var mnemonic = options.Mnemonic;

            if (mnemonic == null)
            {
                mnemonic = bip39.GenerateMnemonic(256, Bip39Wordlist.English);
            }

            var seed = bip39.MnemonicToSeed(mnemonic, null);
            var extKey = ExtKey.CreateFromSeed(seed);
            var hdPathLuna = KeyPath.Parse($"m/44'/{options.CoinType}'/{options.Account}'/0/{options.Index}");
            var terraHd = extKey.Derive(hdPathLuna);
            var privateKey = terraHd.PrivateKey.ToBytes();

            var m = new MnemonicKey(privateKey)
            {
                Mnemonic = mnemonic
            };
            return m;
        }
    }
}