using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using TerraSdk.Crypto.Chaos.Nacl;

namespace TerraSdk.Crypto.Bip32x
{
    public static class Ed25519HdKey
    {
        private const string PathRegex = "^*(\\/[0-9]*\\'?)+$";
        private const string Ed25519Curve = "ed25519 seed";
        private const long HardenedOffset = 0x80000000;

        public static HdKey GetMasterKeyFromSeed(ReadOnlySpan<byte> seed)
        {
            var key = Encoding.UTF8.GetBytes(Ed25519Curve).ToList();

            using var hash = new HMACSHA512(key.ToArray());
            hash.Initialize();
            hash.ComputeHash(seed.ToArray());
            var i = hash.Hash.AsSpan();

            return new HdKey
            {
                Key = i.Slice(0, 32).ToArray(),
                ChainCode = i.Slice(32).ToArray()
            };
        }

        public static byte[] GetPublicKey(byte[] privateKey, bool withZeroByte = true)
        {
            Ed25519.KeyPairFromSeed(out var publicKey, out _, privateKey);

            if (withZeroByte)
            {
                var pub = publicKey.ToList();
                pub.Insert(0, 0x00);
                return pub.ToArray();
            }

            return publicKey;
        }

        public static bool IsValidPath(string path)
        {
            return Regex.IsMatch(path, PathRegex);
        }

        private static HdKey Derive(HdKey parent, UInt32 index)
        {
            var data = parent.Key.ToList();
            var indexBuffer = BitConverter.GetBytes(index);
            indexBuffer = indexBuffer.Reverse().ToArray();

            data.AddRange(indexBuffer);
            data.Insert(0, 0);

            using var hash = new HMACSHA512(parent.ChainCode);
            var i = hash.ComputeHash(data.ToArray()).AsSpan();

            return new HdKey
            {
                Key = i.Slice(0, 32).ToArray(),
                ChainCode = i.Slice(32).ToArray()
            };
        }

        public static HdKey DerivePath(string path, ReadOnlySpan<byte> seed)
        {
            if (!IsValidPath(path))
            {
                throw new ArgumentException("Path is not valid");
            }

            var key = GetMasterKeyFromSeed(seed);

            var segments = path.Split("/").AsSpan().Slice(1).ToArray();
            var intSegments = new List<int>();

            foreach (var segment in segments)
            {
                var nSegment = segment.Replace("'", "");
                intSegments.Add(Convert.ToInt32(nSegment));
            }

            var parentKey = key;
            foreach (var s in intSegments)
            {
                parentKey = Derive(parentKey, (UInt32)(s + HardenedOffset));
            }

            return parentKey;
        }


    }
}