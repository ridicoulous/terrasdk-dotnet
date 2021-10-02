﻿using System;
using TerraSdk.Crypto;
using TerraSdk.Util;

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
                Bech32.Bech32Decode(data, out var hrp);
                return hrp.ToString() == prefix && data.Length == length;
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
        public AccAddress(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }


        /**
         * Checks if a string is a valid Terra account address.
         *
         * @param data string to check
         */
        public bool Validate()
        {
            return Bech32Helper.CheckPrefixAndLength("terra", Value, 44);
        }

        /**
         * Converts a validator address into an account address
         *
         * @param address validator address
         */
        public void FromValAddress(ValAddress address)
        {
            var vals = Bech32.Bech32Decode(address.Value, out _);
            Value = Bech32.Bech32Encode("terra".ToByteArray(), vals);
        }
    }


    /**
     * `terravaloper-` prefixed validator operator address
     */
    public class ValAddress
    {
        public string Value { get; set; }


        /**
         * Checks if a string is a Terra validator address.
         *
         * @param data string to check
         */
        public bool Validate()
        {
            return Bech32Helper.CheckPrefixAndLength("terravaloper", Value, 51);
        }


        /**
        * Converts a Terra account address to a validator address.
        * @param address account address to convert
        */
        public void FromAccAddress(AccAddress address)
        {
            var vals = Bech32.Bech32Decode(address.Value, out _);
            Value = Bech32.Bech32Encode("terravaloper".ToByteArray(), vals);
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
    }

    /**
     * `terrapub-` prefixed account public key
     */
    public class AccPubKey
    {
        public string Value { get; set; }

        /**
         * Checks if a string is a Terra account's public key
         * @param data string to check
         */
        public bool Validate()
        {
            return Bech32Helper.CheckPrefixAndLength("terrapub", Value, 51);
        }

        /**
        * Converts a Terra validator pubkey to an account pubkey.
        * @param address validator pubkey to convert
        */
        public void FromAccAddress(AccAddress address)
        {
            var vals = Bech32.Bech32Decode(address.Value, out _);
            Value = Bech32.Bech32Encode("terrapub".ToByteArray(), vals);
        }
    }

    /**
     * `terravaloperpub-` prefixed validator public key
     */
    public class ValPubKey
    {
        public string Value { get; set; }
        
        /**
         * Checks if a string is a Terra validator pubkey
         * @param data string to check
         */

        public bool Validate()
        {
            return Bech32Helper.CheckPrefixAndLength("terravaloperpub", Value, 51);
        }
        
        /**
        * Converts a Terra validator operator address to a validator pubkey.
        * @param valAddress account pubkey
        */

        public void FromValAddress(ValAddress address)
        {
            var vals = Bech32.Bech32Decode(address.Value, out _);
            Value = Bech32.Bech32Encode("terravaloperpub".ToByteArray(), vals);
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
            return Type == "tendermint/PubKeyEd25519" && Value != null; // Todo: Investigate
        }
    }
}