namespace TerraSdk.ClientOld.Crypto
{
    public class BinaryPublicKey
    {
        public BinaryPublicKey()
        {
        }

        public BinaryPublicKey(string? type, byte[] value)
        {
            Type = type;
            Value = value;
        }

        public string? Type { get; set; }
        public byte[] Value { get; set; } = null!;
    }
}