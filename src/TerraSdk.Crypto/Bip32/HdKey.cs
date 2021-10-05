namespace TerraSdk.Crypto.Bip32x
{
    public class HdKey
    {
        public byte[] Key { get; internal set; }
        public byte[] ChainCode { get; internal set; }
    }
}