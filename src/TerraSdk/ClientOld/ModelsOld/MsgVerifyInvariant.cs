using Newtonsoft.Json;
using TerraSdk.Core;

namespace TerraSdk.ClientOld.ModelsOld
{
    /// <summary>
    ///     MsgVerifyInvariant - message struct to verify a particular invariance.
    /// </summary>
    public class MsgVerifyInvariant : Msg
    {
        public MsgVerifyInvariant()
        {
        }

        public MsgVerifyInvariant(string sender, string invariantModuleName, string invariantRoute)
        {
            Sender = sender;
            InvariantModuleName = invariantModuleName;
            InvariantRoute = invariantRoute;
        }

        [JsonProperty("sender")] public string Sender { get; set; } = null!;

        [JsonProperty("invariant_module_name")]
        public string InvariantModuleName { get; set; } = null!;

        [JsonProperty("invariant_route")] public string InvariantRoute { get; set; } = null!;

        public object SignBytesObject()
        {
            return this;
        }
    }
}