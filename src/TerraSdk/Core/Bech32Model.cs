using System;
using TerraSdk.Crypto;

namespace TerraSdk.Core
{
    public static class Bech32Helper
    {
        public static bool CheckPrefixAndLength(
            string prefix,
            string data,
            int length
        )
        {
            try
            {
                var vals = Bech32.Decode(data);
                return vals.prefix == prefix && data.Length == length;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }


    /**
     * `terra-` prefixed account address
     */
    public class AccAddress
    {
        public string Value { get; private set; }

        public static AccAddress New(string value)
        {
            return new AccAddress { Value = value };
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
            return new AccAddress { Value = Bech32.Encode("terra", vals.words) };
        }
    }


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
            return new AccPubKey { Value = Bech32.Encode("terrapub", vals.words) };
        }

        public static AccPubKey New(string publicKey)
        {
            return new AccPubKey { Value = publicKey };
        }
    }

    /**
     * `terravaloperpub-` prefixed validator public key
     */
    public class ValPubKey
    {
        public string Value { get; private set; }

        /**
         * Checks if a string is a Terra validator pubkey
         * @param data string to check
         */
        public bool Validate()
        {
            return Validate(Value);
        }

        public bool Validate(string value)
        {
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