namespace TerraSdk.Client.ModelsOld
{
    public class Signer
    {
        public IAccount Account { get; set; } = null!;
        public string EncodedPrivateKey { get; set; } = null!;
        public string Passphrase { get; set; } = null!;

        public Signer()
        {
        }
        
        public Signer(IAccount account, string encodedPrivateKey, string passphrase)
        {
            Account = account;
            EncodedPrivateKey = encodedPrivateKey;
            Passphrase = passphrase;
        }
    }
}