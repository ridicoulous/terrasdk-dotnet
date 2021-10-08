namespace TerraSdk.Client.Api.Models
{
    public interface IAccount
    {
        public PublicKey GetPublicKey();
        public ulong GetSequence();
        public ulong GetAccountNumber();
    }
}