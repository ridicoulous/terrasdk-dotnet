﻿using System.Threading.Tasks;
using Flurl.Http;

namespace TerraSdk.Client.Api.Extensions
{
    internal static class TaskExtensions
    {
        public static T Sync<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }

        public static async Task<T> WrapExceptions<T>(this Task<T> task)
        {
            try
            {
                return await task.ConfigureAwait(false);
            }
            catch (FlurlParsingException ex)
            {
                throw new TerraSerializationException(ex);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.WrapException();
            }
        }
    }
}