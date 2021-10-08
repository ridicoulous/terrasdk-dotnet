using System;
using System.Net.Http;
using Flurl.Http;

namespace TerraSdk.Common.Exceptions
{
    public class TerraHttpException : Exception
    {
        /// <summary>The HttpRequestMessage associated with this call.</summary>
        public IFlurlRequest Request { get; }

        /// <summary>
        /// HttpResponseMessage associated with the call if the call completed, otherwise null.
        /// </summary>
        public IFlurlResponse Response { get; }

        /// <summary>DateTime the moment the request was sent.</summary>
        public DateTime StartedUtc { get; }

        /// <summary>DateTime the moment a response was received.</summary>
        public DateTime? EndedUtc { get; }
        
        /// <summary>Called url.</summary>
        public string Url { get; }

        internal TerraHttpException(FlurlHttpException innerException) : base(innerException.Message, innerException)
        {
            Request = innerException.Call.Request;
            Response = innerException.Call.Response;
            EndedUtc = innerException.Call.EndedUtc;
            StartedUtc = innerException.Call.StartedUtc;
            Url = innerException.Call.Request.Url;
        }
    }
}