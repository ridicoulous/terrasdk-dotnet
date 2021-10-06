using TerraSdk.Crypto.Bech32;

namespace TerraSdk.Core.Account
{
    /**
     * `terravaloper-` prefixed validator operator address
     */
    public class ValAddress
    {
        private ValAddress(string value)
        {
            Value = value;
        }


        public string Value { get; set; }

        public static ValAddress New(string value)
        {
            return new ValAddress(value);
        }


        /**
         * Checks if a string is a Terra validator address.
         *
         * @param data string to check
         */
        public bool Validate()
        {
            return Validate(Value);
        }

        public bool Validate(string value)
        {
            return Bech32Helper.CheckPrefixAndLength("terravaloper", value, 51);
        }


        /**
        * Converts a Terra account address to a validator address.
        * @param address account address to convert
        */
        public static ValAddress FromAccAddress(AccAddress address)
        {
            var vals = Bech32.Decode(address.Value);
            return new ValAddress(Bech32.Encode("terravaloper", vals.words));
        }
    }
}