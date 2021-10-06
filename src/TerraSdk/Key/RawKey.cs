using TerraSdk.Crypto.Ecdsa;

namespace TerraSdk.Key
{
    public class RawKey : Key
    {
        public RawKey()
        {
            
        }
        
        public RawKey(byte[] privateKey)
        {
            SetPrivate(privateKey);
        }
        
        //public byte[] PrivateKey { get; set; }
        //public byte[] PublicKey { get; set; }

        protected void SetPrivate(byte[] privateKey)
        {
            PrivateKey = privateKey;
            PublicKey = Secp256K1Manager.GetPublicKey(PrivateKey, true);

            RawAddress = AddressFromPublicKey(PublicKey);
            RawPubKey = PubKeyFromPublicKey(PublicKey);
        }

        public override byte[] Sign(byte[] payload)
        {
            var (signature, _) = EcdsaSign(payload);
            return signature;
        }

        // ReSharper disable once UnusedTupleComponentInReturnValue
        private ( byte[] signature, int recId) EcdsaSign(byte[] payload)
        {
            var hash = Sha256Manager.GetHash(payload);
            var signature = Secp256K1Manager.SignCompact(hash, PrivateKey, out var recId);
            return (signature, recId);
        }
    }
}