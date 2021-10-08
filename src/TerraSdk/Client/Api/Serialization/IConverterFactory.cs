using Newtonsoft.Json;

namespace TerraSdk.Client.Api.Serialization
{
    public interface IConverterFactory
    {
        JsonConverter CreateConverter();
    }
}