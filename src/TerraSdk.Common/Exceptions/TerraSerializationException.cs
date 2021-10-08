using System;
using Flurl.Http;

namespace TerraSdk.Common.Exceptions
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