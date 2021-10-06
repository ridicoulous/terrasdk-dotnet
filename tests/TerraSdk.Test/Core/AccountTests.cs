using TerraSdk.Common.Helpers;
using TerraSdk.Core.Account;
using TerraSdk.Crypto.Bech32;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Core
{
    public class AccountTests
    {
        private readonly ITestOutputHelper output;

        public AccountTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void AccAddress_validates_account_address()
        {
            Assert.False(new AccAddress("terravaloper1pdx498r0hrc2fj36sjhs8vuhrz9hd2cw0yhqtk").Validate());
            Assert.False(new AccAddress("terra1pdx498r0h7c2fj36sjhs8vu8rz9hd2cw0tmam9").Validate());
            Assert.False(new AccAddress("cosmos176m2p8l3fps3dal7h8gf9jvrv98tu3rqfdht86").Validate());

            var words = Bech32.ToWords("foobar".ToByteArrayFromString());
            var badAddress = Bech32.Encode("terra", words);

            Assert.False(new AccAddress(badAddress).Validate());
            Assert.True(new AccAddress("terra1pdx498r0hrc2fj36sjhs8vuhrz9hd2cw0tmam9").Validate());
        }

        [Fact]
        public void AccAddress_converts_from_validator_address()
        {
            Assert.Equal("terra1pdx498r0hrc2fj36sjhs8vuhrz9hd2cw0tmam9", AccAddress.FromValAddress(ValAddress.New("terravaloper1pdx498r0hrc2fj36sjhs8vuhrz9hd2cw0yhqtk")).Value);
        }


        [Fact]
        public void ValAddress_validates_validator_address()
        {
            var words = Bech32.ToWords("foobar".ToByteArrayFromString());
            var badAddress = Bech32.Encode("terravaloper", words);

            Assert.False(ValAddress.New(badAddress).Validate());
            Assert.True(ValAddress.New("terravaloper1pdx498r0hrc2fj36sjhs8vuhrz9hd2cw0yhqtk").Validate());
        }

        [Fact]
        public void ValAddress_converts_from_account_address()
        {
            Assert.Equal("terravaloper1pdx498r0hrc2fj36sjhs8vuhrz9hd2cw0yhqtk", ValAddress.FromAccAddress(new AccAddress("terra1pdx498r0hrc2fj36sjhs8vuhrz9hd2cw0tmam9")).Value);
        }


        [Fact]
        public void AccPubKey_validates_account_pubkey()
        {
            Assert.False(AccPubKey.New("terravaloperpub1addwnpepqt8ha594svjn3nvfk4ggfn5n8xd3sm3cz6ztxyugwcuqzsuuhhfq5y7accr").Validate());

            var words = Bech32.ToWords("foobar".ToByteArrayFromString());
            var badPubKey = Bech32.Encode("terrapub", words);

            Assert.False(AccPubKey.New(badPubKey).Validate());
            Assert.True(AccPubKey.New("terrapub1x46rqay4d3cssq8gxxvqz8xt6nwlz4tdh39t77").Validate());
        }


        [Fact]
        public void AccPubKey_converts_from_validator_pubkey()
        {
            Assert.Equal("terrapub1x46rqay4d3cssq8gxxvqz8xt6nwlz4tdh39t77", AccPubKey.FromAccAddress(new AccAddress("terra1x46rqay4d3cssq8gxxvqz8xt6nwlz4td20k38v")).Value);
        }

        [Fact]
        public void ValPubKey_validates_validator_pubkey()
        {
            Assert.True(ValPubKey.New("terravaloperpub12g4nkvsjjnl0t7fvq3hdcw7y8dc9fq69gvd5ag").Validate());

            var words = Bech32.ToWords("foobar".ToByteArrayFromString());
            var badPubKey = Bech32.Encode("terrapub", words);

            Assert.False(ValPubKey.New(badPubKey).Validate());
            Assert.False(ValPubKey.New("terravaloper12g4nkvsjjnl0t7fvq3hdcw7y8dc9fq69nyeu9q").Validate());
        }

        [Fact]
        public void ValPubKey_converts_from_validator_address()
        {
            Assert.Equal("terravaloperpub12g4nkvsjjnl0t7fvq3hdcw7y8dc9fq69gvd5ag", ValPubKey.FromValAddress(ValAddress.New("terravaloper12g4nkvsjjnl0t7fvq3hdcw7y8dc9fq69nyeu9q")).Value);
        }

        [Fact]
        public void ValConsAddress_validate_validator_consensus_address()
        {
            Assert.True(ValConsAddress.New("terravalcons1relcztayk87c3r529rqf3fwdmn8hr6rhcgyrxd").Validate());
        }

        [Fact]
        public void ValConsPubKey_validate_validator_consensus_public_key()
        {
            Assert.True(ValConsPubKey.New("tendermint/PubKeyEd25519", "abcdef").Validate());
        }
    }
}