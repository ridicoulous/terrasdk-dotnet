using System;
using Flurl.Http;

namespace TerraSdk.ClientOld.Callbacks
{
    public class AfterCall
    {
        public AfterCall(IFlurlRequest request, IFlurlResponse response, DateTime startedUtc, DateTime? endedUtc)
        {
            Request = request;
            Response = response;
            StartedUtc = startedUtc;
            EndedUtc = endedUtc;
        }

        /// <summary>The HttpRequestMessage associated with this call.</summary>
        public IFlurlRequest Request { get; set; }

        /// <summary>
        ///     HttpResponseMessage associated with the call if the call completed, otherwise null.
        /// </summary>
        public IFlurlResponse Response { get; set; }

        /// <summary>DateTime the moment the request was sent.</summary>
        public DateTime StartedUtc { get; set; }

        /// <summary>DateTime the moment a response was received.</summary>
        public DateTime? EndedUtc { get; set; }
    }
}