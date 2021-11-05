using Flurl.Http;

namespace TerraSdk.ClientOld.Callbacks
{
    public class BeforeCall
    {
        internal BeforeCall(IFlurlRequest request)
        {
            Request = request;
        }

        /// <summary>The HttpRequestMessage associated with this call.</summary>
        public IFlurlRequest Request { get; set; }
    }
}