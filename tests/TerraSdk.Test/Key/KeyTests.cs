using TerraSdk.Common;
using TerraSdk.Crypto.Ecdsa;
using Xunit;

namespace TerraSdk.Test.Key
{
    public class KeyTests
    {
        [Fact]
        public void AddressFromPublicKey()
        {
            var publicKeyHex = "03564213318d739994e4d9785bf40eac4edbfa21f0546040ce7e6859778dfce5d4";

            var sha256 = Sha256Manager.GetHash(publicKeyHex.ToByteArrayFromHex());

            sha256.DumpHex();

            var ripemd160 = Ripemd160Manager.GetHash(sha256);

            ripemd160.DumpHex();
            // var address = TerraSdk.Key.Key.AddressFromPublicKey(publicKeyHex.HexToByteArray());
        }
    }
}