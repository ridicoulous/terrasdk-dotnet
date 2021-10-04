using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraSdk.Key
{
    public class  MnemonicKeyOptions
    {
        /**
         * Space-separated list of words for the mnemonic key.
         */
        public string Mnemonic { get; set; }

        /**
       * BIP44 account number.
       */
        public int? Account { get; set; } = 0;

        /**
       * BIP44 index number
       */
        public int? Index { get; set; } = 0;

        /**
       * Coin type. Default is LUNA, 330.
       */
        public int? CoinType { get; set; } = 330; // Luna
    }


    public class MnemonicKey : RawKey
    {
        public string Mnemonic { get; private set; }

        public static MnemonicKey New(MnemonicKeyOptions options)
        {

            var m = new MnemonicKey();
            m.Mnemonic = options.Mnemonic ?? Bip39.GenerateMnemonic(256);



            return m;


        }



    }
}
