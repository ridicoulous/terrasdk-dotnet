using System;
using Flurl.Http;

namespace TerraSdk.Client.Api
{
    public class TerraSerializationException : Exception
    {
        public TerraSerializationException(string? message) : base(message)
        {
        }

        public TerraSerializationException(FlurlParsingException ex) : base(ex.Message, ex)
        {
        }
    }
}