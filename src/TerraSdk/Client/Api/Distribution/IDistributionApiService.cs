using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TerraSdk.Client.Models;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Core;
using TerraSdk.Core.Account;

namespace TerraSdk.Client.Api.Distribution
{
    /// <summary>
    /// Fee distribution module APIs.
    /// </summary>
    public interface IDistributionApiService
    {
        /**
         * Gets a delegator's rewards.
         * @param delegator delegator's account address
         */
        Task<DelegationTotalRewardsResponse> GetDelegationTotalRewardsAsync(AccAddress delegatorAddress,
            CancellationToken cancellationToken = default);

        /**
         * Gets a validator's rewards.
         * @param validator validator's operator address
         */
        Task<ValidatorCommissionAccumResponse> GetValidatorCommissionAsync(ValAddress validatorAddress,
            CancellationToken cancellationToken = default);

        /**
         * Gets the withdraw address of a delegator, the address to which rewards are withdrawn.
         * @param delegator
         */
        Task<AccAddress> GetWithdrawAddressAsync(AccAddress delegatorAddress,
            CancellationToken cancellationToken = default);

        /**
         * Gets the current value of the community pool.
         */
        Task<CommunityPoolResponse> GetCommunityPoolAsync(CancellationToken cancellationToken = default);

        /**
         * Gets the current distribution parameters.
         */
        Task<DistributionParams> GetDistributionParamsAsync(CancellationToken cancellationToken = default);
    }
}