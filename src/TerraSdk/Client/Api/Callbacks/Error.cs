﻿using System;
using System.Net.Http;
using Flurl.Http;

namespace TerraSdk.Client.Api.Callbacks
{
    public class Error
    {
        /// <summary>The HttpRequestMessage associated with this call.</summary>
        public IFlurlRequest Request { get; set; }
        /// <summary>
        /// HttpResponseMessage associated with the call if the call completed, otherwise null.
        /// </summary>
        public IFlurlResponse Response { get; set; }
        /// <summary>DateTime the moment the request was sent.</summary>
        public DateTime StartedUtc { get; set; }
        /// <summary>DateTime the moment a response was received.</summary>
        public DateTime? EndedUtc { get; set; }
        /// <summary>
        /// Exception that occurred while sending the HttpRequestMessage.
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// User code should set this to true inside global event handlers (OnError, etc) to indicate
        /// that the exception was handled and should not be propagated further.
        /// </summary>
        public bool Handled { get; set; }

        internal Error(IFlurlRequest request, IFlurlResponse response, DateTime startedUtc, DateTime? endedUtc, Exception exception, bool handled)
        {
            Request = request;
            Response = response;
            StartedUtc = startedUtc;
            EndedUtc = endedUtc;
            Exception = exception;
            Handled = handled;
        }
    }
}