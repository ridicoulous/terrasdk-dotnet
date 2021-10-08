using System;
using Flurl.Http;
using TerraSdk.Common.Exceptions;

namespace TerraSdk.Common.Extensions
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