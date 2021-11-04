using System.Threading;
using System.Threading.Tasks;

namespace TerraSdk.Client.Api.Bank
{

    /// <summary>
    /// Create and broadcast transactions.
    /// </summary>
    public partial interface IBankApiService
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
        Task<BalanceResponse> GetBalanceAsync(string address, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the total supply.
        /// </summary>
        Task<BalanceResponse> GetTotalSupplyAsync(CancellationToken cancellationToken = default);
    }
}
