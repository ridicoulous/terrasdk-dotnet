namespace TerraSdk.Core.Account
{
    /**
     * `terravalconspub-` prefixed validator consensus public key
     */
    public class ValConsPubKey
    {
        public string Type { get; set; }
        public string Value { get; set; }


        /**
         * Checks if string is a valid Terra consensus (node) pubkey.
         * @param data string to check
         */
        public bool Validate()
        {
            return Validate(Type, Value);
        }

        public bool Validate(string type, string value)
        {
            return type == "tendermint/PubKeyEd25519" && value != null; // Todo: Investigate
        }

        public static ValConsPubKey New(string type, string value)
        {
            return new ValConsPubKey { Type = type, Value = value };
        }
    }
}