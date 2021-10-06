namespace TerraSdk.Core.Account
{
    /**
     * `terravalcons-` prefixed validator consensus address
     */
    public class ValConsAddress
    {
        public string Value { get; set; }

        /**
         * Checks if a string is a Terra validator consensus address
         * @param data string to check
         */
        public bool Validate()
        {
            return Bech32Helper.CheckPrefixAndLength("terravalcons", Value, 51);
        }

        public static ValConsAddress New(string value)
        {
            return new ValConsAddress { Value = value };
        }
    }
}