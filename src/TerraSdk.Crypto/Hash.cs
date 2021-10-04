using System;
using System.Security.Cryptography;
using System.Text;
using TerraSdk.Crypto.Chaos.Nacl;
using TerraSdk.Util.Common;

namespace TerraSdk.Crypto
{
    public static class Hash
    {

        static readonly Lazy<Ripemd160.Ripemd160> Ripemd160Lazy = new(() => new Ripemd160.Ripemd160());

        public const int KeyLength = 32;
        public const int NonceLength = 24;
        public const int PublicKeyLength = 32;
        public const int SeedLength = 32;
        public const int SignatureLength = 64;

        //public static SignatureAlgorithm Algorithm { get; } = SignatureAlgorithm.Ed25519;

        public static byte[] EncryptSymmetric(byte[] message, byte[] nonce, byte[] sharedKey)
        {
            return XSalsa20Poly1305.Encrypt(message, sharedKey, nonce);
        }
        
        public static byte[] DecryptSymmetric(byte[] message, byte[] nonce, byte[] sharedKey)
        {
            return XSalsa20Poly1305.TryDecrypt(message, sharedKey, nonce);
        }

        public static byte[] Sha256(byte[] input)
        {
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(input);
            return hash;
        }

        public static byte[] Sha256(string input)
        {
            var inputBytes = Encoding.Default.GetBytes(input);

            return Hash.Sha256(inputBytes);
        }

        //public static string Sha256Hex(string inputHex)
        //{
        //    var inputBytes = inputHex.FromHexString();

        //    return Hash.Sha256(inputBytes).ToHexString();
        //}

        public static string DoubleSha256(byte[] input)
        {
            using (var sha256 = SHA256Managed.Create())
            {
                var hash = sha256.ComputeHash(input);

                var doubleHash = sha256.ComputeHash(hash);

                return doubleHash.ToHex();
            }
        }

        public static string DoubleSha256(string input)
        {
            var inputBytes = Encoding.Default.GetBytes(input);

            return Hash.DoubleSha256(inputBytes);
        }

        public static byte[] Ripemd160(string input)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            var result = Ripemd160Lazy.Value.ComputeHash(bytes);
            return result;
        }

        public static byte[] Ripemd160Hex(string inputHex)
        {
            var bytes = inputHex.ParseHex();
            var result = Ripemd160Lazy.Value.ComputeHash(bytes);
            return result;
        }
    }
}
