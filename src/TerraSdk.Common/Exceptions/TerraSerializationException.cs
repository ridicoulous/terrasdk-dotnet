using System;
using Flurl.Http;
using RestClient.Net;

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


        public TerraSerializationException(DeserializationException ex) : base(ex.Message, ex)
        {
        }


        


    }
}