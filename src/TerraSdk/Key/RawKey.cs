using TerraSdk.Crypto.Ecdsa;

namespace TerraSdk.Key
{
    public class RawKey : Key
    {
        public RawKey(byte[] privateKey)
        {
            PrivateKey = privateKey;

            var publicKey = Secp256K1Manager.GetPublicKey(PrivateKey, true);
            RawAddress = AddressFromPublicKey(publicKey);
            RawPubKey = PubKeyFromPublicKey(publicKey);
        }

        public byte[] PrivateKey { get; }

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