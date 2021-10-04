#nullable enable
using System;
using System.Threading.Tasks;
using dotnetstandard_bip32;
using TerraSdk.Core;
using TerraSdk.Crypto.Bech32;
using TerraSdk.Crypto.Ecdsa;
using TerraSdk.Crypto.Util;

namespace TerraSdk.Key
{
    /**
     * Abstract key interface that provides transaction signing features and Bech32 address
     * and public key derivation from a public key. This allows you to create custom key
     * solutions, such as for various hardware wallets, by implementing signing and calling
     * `super` with the raw public key from within your subclass. See [[MnemonicKey]] for
     * an implementation of a basic mnemonic-based key.
     */
    public abstract class Key
    {
        private const string BECH32_PUBKEY_DATA_PREFIX = "eb5ae98721";

        public byte[]? RawAddress { get; set; }
        public byte[]? RawPubKey { get; set; }

        /**
         * Gets a raw address from a compressed bytes public key.
         *
         * @param publicKey raw public key
         */
        public static byte[] AddressFromPublicKey(byte[] publicKey)
        {
            return Ripemd160Manager.GetHash(Sha256Manager.GetHash(publicKey));
        }

        /**
         * Gets a bech32-words pubkey from a compressed bytes public key.
         *
         * @param publicKey raw public key
         */
        public static byte[] PubKeyFromPublicKey(byte[] publicKey)
        {
            var buffer = BECH32_PUBKEY_DATA_PREFIX.HexToByteArray();
            var rv = new byte[buffer.Length + publicKey.Length];
            Buffer.BlockCopy(buffer, 0, rv, 0, buffer.Length);
            Buffer.BlockCopy(publicKey, 0, rv, buffer.Length, publicKey.Length);
            return rv;
        }
        
        /**
         * You will need to supply `sign`, which produces a signature for an arbitrary bytes payload
         * with the ECDSA curve secp256pk1.
         *
         * @param payload the data to be signed
         */
        public abstract byte[] Sign(byte[] payload);

        /**
         * Terra account address. `terra-` prefixed.
         */

        public AccAddress AccAddress {
            get
            {
                if (this.RawAddress == null)
                {
                    throw new Exception("Could not compute AccAddress: missing rawAddress");
                }
                return AccAddress.New(Bech32.Encode("terra",(byte[])this.RawAddress));
            }
        }

        //    /**
        //     * Terra validator address. `terravaloper-` prefixed.
        //     */
        public ValAddress ValAddress
        {
            get
            {
                if (this.RawAddress == null)
                {
                    throw new Exception("Could not compute ValAddress: missing rawAddress");
                }
                return ValAddress.New(Bech32.Encode("terravaloper", (byte[])this.RawAddress));
            }
        }

        //    /**
        //     * Terra account public key. `terrapub-` prefixed.
        //     */
        public AccPubKey AccPubKey
        {
            get
            {
                if (this.RawPubKey == null)
                {
                    throw new Exception("Could not compute AccPubKey: missing RawPubKey");
                }
                return AccPubKey.New(Bech32.Encode("terrapub", (byte[])this.RawPubKey));
            }
        }

        //    /**
        //     * Terra validator public key. `terravaloperpub-` prefixed.
        //     */
        public ValPubKey ValPubKey
        {
            get
            {
                if (this.RawPubKey == null)
                {
                    throw new Exception("Could not compute ValAddress: missing RawPubKey");
                }
                return ValPubKey.New(Bech32.Encode("terravaloperpub", (byte[])this.RawPubKey));
            }
        }
        
        //    /**
        //     * Called to derive the relevant account and validator addresses and public keys from
        //     * the raw compressed public key in bytes.
        //     *
        //     * @param publicKey raw compressed bytes public key
        //     */
        //    constructor(public publicKey?: Buffer) {
        //    if (publicKey) {
        //      this.RawAddress = addressFromPublicKey(publicKey);
        //      this.RawPubKey = pubKeyFromPublicKey(publicKey);
        //    }
        //}

        public Key(byte[] publicKey)
        {
            this.RawAddress = AddressFromPublicKey(publicKey);
            this.RawPubKey = PubKeyFromPublicKey(publicKey);
        }

        protected Key()
        {
        }

        ///**
        // * Signs a [[StdSignMsg]] with the method supplied by the child class.
        // *
        // * @param tx sign-message of the transaction to sign
        // */




        //public async createSignature(tx: StdSignMsg): Promise<StdSignature> {
        //    const sigBuffer = await this.sign(Buffer.from(tx.toJSON()));

        //    if (!this.publicKey)
        //    {
        //        throw new Error(
        //          'Signature could not be created: Key instance missing publicKey'
        //        );
        //    }

        //    return StdSignature.fromData({
        //    signature: sigBuffer.toString('base64'),
        //      pub_key:
        //        {
        //        type: 'tendermint/PubKeySecp256k1',
        //        value: this.publicKey.toString('base64'),
        //      },
        //    });
        //}

        ///**
        // * Signs a [[StdSignMsg]] and adds the signature to a generated StdTx that is ready to be broadcasted.
        // * @param tx
        // */
        //public async signTx(tx: StdSignMsg): Promise<StdTx> {
        //    const sig = await this.createSignature(tx);
        //    return new StdTx(tx.msgs, tx.fee, [sig], tx.memo, tx.timeout_height);
        //}
    }
}