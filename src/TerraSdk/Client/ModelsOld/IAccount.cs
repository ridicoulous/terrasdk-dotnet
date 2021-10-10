using TerraSdk.Core;

namespace TerraSdk.Client.ModelsOld
{
    public interface IAccount
    {
        public PublicKey GetPublicKey();
        public ulong GetSequence();
        public ulong GetAccountNumber();
    }
}