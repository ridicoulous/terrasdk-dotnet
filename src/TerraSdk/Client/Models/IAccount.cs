namespace TerraSdk.Client.Models
{
    public interface IAccount
    {
        public PublicKey GetPublicKey();
        public ulong GetSequence();
        public ulong GetAccountNumber();
    }
}