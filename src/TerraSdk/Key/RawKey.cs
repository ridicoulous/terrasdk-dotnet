using System;
using NBitcoin.Secp256k1;
using TerraSdk.Common.Helpers;
using TerraSdk.Crypto.Ecdsa;

namespace TerraSdk.Key
{
    public class RawKey : Key
    {
        private ECPrivKey ecPrivateKey;

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

            ecPrivateKey = Context.Instance.CreateECPrivKey(privateKey);

            //PublicKey = Secp256K1Manager.GetPublicKey(PrivateKey, true);
            PublicKey = ecPrivateKey.CreatePubKey().ToBytes();

            RawAddress = AddressFromPublicKey(PublicKey);
            RawPubKey = PubKeyFromPublicKey(PublicKey);
        }

        public override byte[] Sign(byte[] payload)
        {
            var hash = Sha256Manager.GetHash(payload);

            Console.WriteLine(hash.ToHexFromByteArray());

            ecPrivateKey.TrySignECDSA(hash, out var signature);
            var n = new byte[64];
            signature.WriteCompactToSpan(n);

            return n;
        }

        // ReSharper disable once UnusedTupleComponentInReturnValue
        private ( byte[] signature, int recId) EcdsaSign(byte[] payload)
        {
            var hash = Sha256Manager.GetHash(payload);
            ecPrivateKey.TrySignECDSA(hash, null, out var recId, out var signature);
            return (signature?.ToDER(), recId);
        }
    }
}