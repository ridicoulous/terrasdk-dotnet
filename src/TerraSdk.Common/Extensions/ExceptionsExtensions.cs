using System;
using Flurl.Http;
using RestClient.Net;
using TerraSdk.Common.Exceptions;

namespace TerraSdk.Common.Extensions
{
    public static class ExceptionsExtensions
    {
        public static Exception WrapExceptionOld(this Exception exception)
        {
            if (exception is FlurlHttpException flurl)
            {
                return new TerraHttpExceptionOld(flurl);
            }

            return exception;
        }

        public static Exception WrapException(this Exception exception)
        {
            if (exception is HttpStatusException httpStatusException)
            {
                return new TerraHttpException(httpStatusException);
            }

            return exception;
        }


    }
}