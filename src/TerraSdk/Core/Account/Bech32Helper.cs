using System;
using TerraSdk.Crypto.Bech32;

namespace TerraSdk.Core.Account
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
}