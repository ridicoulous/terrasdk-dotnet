using Newtonsoft.Json;

namespace TerraSdk.Common.Serialization
{
    public interface IConverterFactory
    {
        JsonConverter CreateConverter();
    }
}