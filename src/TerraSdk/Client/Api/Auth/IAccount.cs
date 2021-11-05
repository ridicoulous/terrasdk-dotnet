using TerraSdk.Core;

namespace TerraSdk.Client.Api.Auth
{
    public interface IAccount
    {
        public PublicKey GetPublicKey();
        public ulong GetSequence();
        public ulong GetAccountNumber();
    }
}