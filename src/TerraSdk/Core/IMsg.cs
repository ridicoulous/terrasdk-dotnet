namespace TerraSdk.Core
{
    public interface IMsg
    {
        public string Type { get; }
        public object Value { get; init; }
    }
}