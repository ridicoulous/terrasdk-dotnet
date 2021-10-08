using Flurl.Http;

namespace TerraSdk.Client.Callbacks
{
    public class BeforeCall
    {
        /// <summary>The HttpRequestMessage associated with this call.</summary>
        public IFlurlRequest Request { get; set; }

        internal BeforeCall(IFlurlRequest request)
        {
            Request = request;
        }
    }
}