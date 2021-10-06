using NBitcoin;
using TerraSdk.Crypto.Bip39;

namespace TerraSdk.Key
{
    public class MnemonicKey : RawKey
    {
        public MnemonicKey(MnemonicKeyOptions options)
        {
            var bip39 = new Bip39();
            Mnemonic = options.Mnemonic ?? bip39.GenerateMnemonic(256, Bip39Wordlist.English);

            var seed = bip39.MnemonicToSeed(Mnemonic, null);
            var extKey = ExtKey.CreateFromSeed(seed);
            var hdPathLuna = KeyPath.Parse($"m/44'/{options.CoinType}'/{options.Account}'/0/{options.Index}");
            var terraHd = extKey.Derive(hdPathLuna);
            var privateKey = terraHd.PrivateKey.ToBytes();

            SetPrivate(privateKey);
        }

        public string Mnemonic { get; }
    }
}