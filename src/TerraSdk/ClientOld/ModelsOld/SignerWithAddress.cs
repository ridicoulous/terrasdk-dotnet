namespace TerraSdk.ClientOld.ModelsOld
{
    public class SignerWithAddress
    {
        public SignerWithAddress()
        {
        }

        public SignerWithAddress(string address, string encodedPrivateKey, string passphrase)
        {
            Address = address;
            EncodedPrivateKey = encodedPrivateKey;
            Passphrase = passphrase;
        }

        public string Address { get; set; } = null!;
        public string EncodedPrivateKey { get; set; } = null!;
        public string Passphrase { get; set; } = null!;
    }
}