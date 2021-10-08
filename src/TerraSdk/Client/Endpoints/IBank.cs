using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TerraSdk.Client.Models;
using TerraSdk.Core;

namespace TerraSdk.Client.Endpoints
{

    /// <summary>
    /// Create and broadcast transactions.
    /// </summary>
    public partial interface IBank
    {
        /// <summary>
        /// Get the account balances.
        /// </summary>
        /// <param name='address'>
        /// Account address in bech32 format.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<ResponseWithHeight<IList<Coin>>> GetBalanceAsync(string address, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the account balances.
        /// </summary>
        /// <param name='address'>
        /// Account address in bech32 format.
        /// </param>

    }
}
