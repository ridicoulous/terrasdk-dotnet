using System.Diagnostics;
using TerraSdk.Crypto.Bech32;

namespace TerraSdk.Core.Account
{
    /**
     * `terravaloperpub-` prefixed validator public key
     */
    public class ValPubKey
    {
        public string? Value { get; private set; }

        /**
         * Checks if a string is a Terra validator pubkey
         * @param data string to check
         */
        public bool Validate()
        {
            return Validate(Value);
        }

        public bool Validate(string? value)
        {
            Debug.Assert(value != null, nameof(value) + " != null");
            return Bech32Helper.CheckPrefixAndLength("terravaloperpub", value, 54);
        }

        /**
        * Converts a Terra validator operator address to a validator pubkey.
        * @param valAddress account pubkey
        */
        public static ValPubKey FromValAddress(ValAddress address)
        {
            var vals = Bech32.Decode(address.Value);
            return new ValPubKey { Value = Bech32.Encode("terravaloperpub", vals.words) };
        }

        public static ValPubKey New(string value)
        {
            return new ValPubKey { Value = value };
        }
    }
}