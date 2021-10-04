﻿using System;
using System.Text;

namespace TerraSdk.Crypto.Util
{
    namespace Common
    {
        public static class Hex
        {
            /// Decode a hex string into bytes.
            public static byte[] ParseHex(this string hex)
            {
                var numberChars = hex.Length;
                var bytes = new byte[numberChars / 2];
                for (var i = 0; i < numberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return bytes;
            }

            public static string ToHex(this byte[] bytes)
            {
                var hex = new StringBuilder( bytes.Length * 2);

                foreach (var b in bytes)
                    hex.AppendFormat("{0:x2}", b);

                return hex.ToString();
            }
        }
    }
}