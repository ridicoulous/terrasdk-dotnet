using System.Threading;
using System.Threading.Tasks;
using TerraSdk.ClientOld.ModelsOld;

namespace TerraSdk.ClientOld.Endpoints
{
    /// <summary>
    /// </summary>
    public interface IGaiaREST
    {
        /// <summary>
        ///     The properties of the connected node
        /// </summary>
        /// <remarks>
        ///     Information about the connected node
        /// </remarks>
        /// <param name='cancellationToken'>
        ///     The cancellation token.
        /// </param>
        Task<NodeStatus> GetNodeInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     The properties of the connected node
        /// </summary>
        /// <remarks>
        ///     Information about the connected node
        /// </remarks>
        /// <param name='cancellationToken'>
        ///     The cancellation token.
        /// </param>
        NodeStatus GetNodeInfo();
    }
}