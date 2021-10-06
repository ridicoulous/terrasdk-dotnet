using TerraSdk.Crypto.Bech32;

namespace TerraSdk.Core.Account
{
    /**
     * `terra-` prefixed account address
     */
    public class AccAddress
    {
        public string Value { get; private init; }

        public  AccAddress (string value)
        {
            Value = value;
        }
        
        /**
         * Checks if a string is a valid Terra account address.
         *
         * @param data string to check
         */
        public bool Validate()
        {
            return Validate(Value);
        }

        public bool Validate(string value)
        {
            return Bech32Helper.CheckPrefixAndLength("terra", value, 44);
        }

        /**
         * Converts a validator address into an account address
         *
         * @param address validator address
         */
        public static AccAddress FromValAddress(ValAddress address)
        {
            var vals = Bech32.Decode(address.Value);
            return new AccAddress (Bech32.Encode("terra", vals.words));
        }
    }
}