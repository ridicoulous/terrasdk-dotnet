#nullable enable
using System.Threading.Tasks;

namespace TerraSdk.Key
{
    /**
     * Abstract key interface that provides transaction signing features and Bech32 address
     * and public key derivation from a public key. This allows you to create custom key
     * solutions, such as for various hardware wallets, by implementing signing and calling
     * `super` with the raw public key from within your subclass. See [[MnemonicKey]] for
     * an implementation of a basic mnemonic-based key.
     */
    internal abstract class Key
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
            //if (typeof publicKey !== 'object' || !(publicKey instanceof Buffer)) {
            //    throw new TypeError('parameter must be Buffer that contains public key');
            //}

            //var message = Hex.Parse(publicKey.toString('hex'));
            //var hash = Hash.Ripemd160(Hash.Sha256(message).ToString());
            //const address = Buffer.from(hash, 'hex');
            //return Buffer.from(Bech32.toWords(address));
            return default;
        }

        /**
         * Gets a bech32-words pubkey from a compressed bytes public key.
         *
         * @param publicKey raw public key
         */
        public static byte[] PubKeyFromPublicKey(byte[] publicKey)
        {
            //const buffer = Buffer.from(BECH32_PUBKEY_DATA_PREFIX, 'hex');
            //const combined = Buffer.concat([buffer, publicKey]);
            //return Buffer.from(bech32.toWords(combined));
            return default;
        }


        /**
         * You will need to supply `sign`, which produces a signature for an arbitrary bytes payload
         * with the ECDSA curve secp256pk1.
         *
         * @param payload the data to be signed
         */
        public abstract Task<byte[]> Sign(byte[] payload);

        /**
         * Terra account address. `terra-` prefixed.
         */
        //  public get accAddress(): AccAddress {
        //    if (!this.RawAddress) {
        //      throw new Error('Could not compute accAddress: missing rawAddress');
        //    }
        //    return bech32.encode('terra', Array.from(this.RawAddress));
        //    }

        //    /**
        //     * Terra validator address. `terravaloper-` prefixed.
        //     */
        //    public get valAddress(): ValAddress {
        //    if (!this.RawAddress) {
        //        throw new Error('Could not compute valAddress: missing rawAddress');
        //    }
        //    return bech32.encode('terravaloper', Array.from(this.RawAddress));
        //    }

        //    /**
        //     * Terra account public key. `terrapub-` prefixed.
        //     */
        //    public get accPubKey(): AccPubKey {
        //    if (!this.RawPubKey) {
        //        throw new Error('Could not compute accPubKey: missing rawPubKey');
        //    }
        //    return bech32.encode('terrapub', Array.from(this.RawPubKey));
        //    }

        //    /**
        //     * Terra validator public key. `terravaloperpub-` prefixed.
        //     */
        //    public get valPubKey(): ValPubKey {
        //    if (!this.RawPubKey) {
        //        throw new Error('Could not compute valPubKey: missing rawPubKey');
        //    }
        //    return bech32.encode('terravaloperpub', Array.from(this.RawPubKey));
        //    }

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