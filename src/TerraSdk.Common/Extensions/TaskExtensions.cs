using System.Threading.Tasks;
using Flurl.Http;
using TerraSdk.Common.Exceptions;

namespace TerraSdk.Common.Extensions
{
    public static class TaskExtensions
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