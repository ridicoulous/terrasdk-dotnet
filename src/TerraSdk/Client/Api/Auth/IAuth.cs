using System.Threading;
using System.Threading.Tasks;
using TerraSdk.ClientOld.ModelsOld;

namespace TerraSdk.Client.Api.Auth
{
    /// <summary>
    ///     Authenticate accounts.
    /// </summary>
    public interface IAuth
    {
        /// <summary>
        ///     Get the account information on blockchain.
        /// </summary>
        /// <param name='address'>
        ///     Account address.
        /// </param>
        /// <param name='cancellationToken'>
        ///     The cancellation token.
        /// </param>
        Task<ResponseWithHeight<IAccount>> GetAuthAccountByAddressAsync(string address, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get the account information on blockchain.
        /// </summary>
        /// <param name='address'>
        ///     Account address.
        /// </param>
        ResponseWithHeight<IAccount> GetAuthAccountByAddress(string address);
    }
}