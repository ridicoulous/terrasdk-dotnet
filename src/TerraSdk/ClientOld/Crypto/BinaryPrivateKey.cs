namespace TerraSdk.ClientOld.Crypto
{
    public class BinaryPrivateKey
    {
        public BinaryPrivateKey(string? type, byte[] value)
        {
            Type = type;
            Value = value;
        }

        public string? Type { get; }
        public byte[] Value { get; }
    }
}