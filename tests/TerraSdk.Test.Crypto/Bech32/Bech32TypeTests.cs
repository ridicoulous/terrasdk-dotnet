using TerraSdk.Crypto.Util.Common;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable FormatStringProblem

namespace TerraSdk.Test.Crypto.Bech32
{
    public class Bech32TypeTests
    {

        private readonly ITestOutputHelper output;

        public Bech32TypeTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        // This is a simple example file that shows the usage of this library in TypeScript.
        // When you open it in Visual Studio Code, the built-in TypeScript server should run all
        // the type checks. For manually runtime testing you can use ts-node to run this file.


        public string EncodeUint8Array(string prefix, byte[] data)
        {
            var address = TerraSdk.Crypto.Bech32.Bech32.Encode(prefix, TerraSdk.Crypto.Bech32.Bech32.ToWords(data));
            return address;
        }

        public (string prefix, byte[] data) DecodeUint8Array(string address)
        {
            var decodedAddress = TerraSdk.Crypto.Bech32.Bech32.Decode(address);
            return (
                decodedAddress.prefix,
                data: TerraSdk.Crypto.Bech32.Bech32.FromWords(decodedAddress.words)
            );
        }

        public string EncodeBuffer(string prefix, byte[] data)
        {
            var address = TerraSdk.Crypto.Bech32.Bech32.Encode(prefix, TerraSdk.Crypto.Bech32.Bech32.ToWords(data));
            return address;
        }

        public (string prefix, byte[] data) DecodeBuffer(string address)
        {
            var decodedAddress = TerraSdk.Crypto.Bech32.Bech32.Decode(address);
            return (
                decodedAddress.prefix,
                data: TerraSdk.Crypto.Bech32.Bech32.FromWords(decodedAddress.words)
            );
        }

        public string EncodeUnsafe(string prefix, byte[] data)
        {
            var address = TerraSdk.Crypto.Bech32.Bech32.Encode(prefix, TerraSdk.Crypto.Bech32.Bech32.ToWords(data));
            return address;
        }

        public (string prefix, byte[] data) DecodeUnsafe(string address)
        {
            var decodedAddress = TerraSdk.Crypto.Bech32.Bech32.Decode(address);
            return (
                decodedAddress.prefix,
                data: TerraSdk.Crypto.Bech32.Bech32.FromWords(decodedAddress.words)
            );
        }

        [Fact]
        public void Test1()
        {
            var prefix = "foo";
            var data = new byte[] { 0x00, 0x11, 0x22 };
            var address  = EncodeUint8Array(prefix, data);
            var decoded  = DecodeUint8Array(address);
            output.WriteLine("{0}, {1}, {2}, {3}, {4}", prefix, data.ToHex(), address, decoded.prefix, decoded.data.ToHex());

            Assert.Equal(prefix, decoded.prefix);
            Assert.Equal(data, decoded.data);
        }

        [Fact]
        public void Test2()
        {
            var prefix = "foo";
            var data = new byte[] { 0x00, 0x11, 0x22 };
            var address  = EncodeBuffer(prefix, data);
            var decoded  = DecodeBuffer(address);
            output.WriteLine("{0}, {1}, {2}, {3}, {4}", prefix, data.ToHex(), address, decoded.prefix, decoded.data.ToHex());

            Assert.Equal(prefix, decoded.prefix);
            Assert.Equal(data, decoded.data);
        }

        [Fact]
        public void Test3()
        {
            var prefix = "foo";
            var data = new byte[] { 0x00, 0x11, 0x22 };
            var address  = EncodeUnsafe(prefix, data);
            var decoded  = DecodeUnsafe(address!);
            output.WriteLine("{0}, {1}, {2}, {3}, {4}", prefix, data.ToHex(), address, decoded.prefix, decoded.data.ToHex());

            Assert.Equal(prefix, decoded.prefix);
            Assert.Equal(data, decoded.data);

        }
    }
}