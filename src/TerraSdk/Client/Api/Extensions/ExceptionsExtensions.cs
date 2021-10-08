using System;
using Flurl.Http;

namespace TerraSdk.Client.Api.Extensions
{
    public static class ExceptionsExtensions
    {
        public static Exception WrapException(this Exception exception)
        {
            if (exception is FlurlHttpException flurl)
            {
                return new TerraHttpException(flurl);
            }

            return exception;
        }
    }
}