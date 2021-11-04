using TerraSdk.Core;

namespace TerraSdk.ClientOld.ModelsOld
{
    public interface IAccount
    {
        public PublicKey GetPublicKey();
        public ulong GetSequence();
        public ulong GetAccountNumber();
    }
}