using TerraSdk.Crypto.Bech32;

namespace TerraSdk.Core.Account
{
    /**
     * `terrapub-` prefixed account public key
     */
    public class AccPubKey
    {
        public string Value { get; private set; }

        /**
         * Checks if a string is a Terra account's public key
         * @param data string to check
         */
        public bool Validate()
        {
            return Validate(Value);
        }

        public bool Validate(string value)
        {
            return Bech32Helper.CheckPrefixAndLength("terrapub", value, 47);
        }

        /**
        * Converts a Terra validator pubkey to an account pubkey.
        * @param address validator pubkey to convert
        */
        public static AccPubKey FromAccAddress(AccAddress address)
        {
            var vals = Bech32.Decode(address.Value);
            return new AccPubKey {Value = Bech32.Encode("terrapub", vals.words)};
        }

        public static AccPubKey New(string publicKey)
        {
            return new AccPubKey {Value = publicKey};
        }
    }
}