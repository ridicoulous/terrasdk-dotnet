using System;
using System.Threading;
using System.Threading.Tasks;
using RestClient.Net;
using TerraSdk.Common.Extensions;
using TerraSdk.Core.Account;
using Urls;

namespace TerraSdk.Client.Api.Distribution
{
    public class DistributionApiService :IDistributionApiService
    {
        private readonly IClient client;

        public DistributionApiService(IClient client)
        {
            this.client = client;
        }

        /**
         * Gets a delegator's rewards.
         * @param delegator delegator's account address
         */
        public async Task<DelegationTotalRewardsResponse> GetDelegationTotalRewardsAsync(AccAddress delegatorAddress,
            CancellationToken cancellationToken = default)
        {
            var response = await client
                .GetAsync<DelegationTotalRewardsResponse>(
                    new RelativeUrl($"cosmos/distribution/v1beta1/delegators/${delegatorAddress.Value}/rewards"), null,
                    cancellationToken)
                .WrapExceptions();

            return response.Body ?? throw new NullReferenceException();
        }

        /**
         * Gets a validator's rewards.
         * @param validator validator's operator address
         */
        public async Task<ValidatorCommissionAccumResponse> GetValidatorCommissionAsync(ValAddress validatorAddress,
            CancellationToken cancellationToken = default)
        {
            var response = await client
                .GetAsync<ValidatorCommissionAccumResponse>(
                    new RelativeUrl($"cosmos/distribution/v1beta1/validators/${validatorAddress.Value}/commission"),
                    null, cancellationToken)
                .WrapExceptions();

            return response.Body ?? throw new NullReferenceException();
        }


        /**
         * Gets the withdraw address of a delegator, the address to which rewards are withdrawn.
         * @param delegator
         */
        public async Task<AccAddress> GetWithdrawAddressAsync(AccAddress delegatorAddress,
            CancellationToken cancellationToken = default)
        {
            var response = await client
                .GetAsync<WithdrawAddressResponse>(
                    new RelativeUrl(
                        $"cosmos/distribution/v1beta1/delegators/${delegatorAddress.Value}/withdraw_address"), null,
                    cancellationToken)
                .WrapExceptions();

            var address = response.Body?.WithdrawAddress ?? throw new NullReferenceException();

            return new AccAddress(address);
        }


        /**
         * Gets the current value of the community pool.
         */
        public async Task<CommunityPoolResponse> GetCommunityPoolAsync(CancellationToken cancellationToken = default)
        {
            var response = await client
                .GetAsync<CommunityPoolResponse>(new RelativeUrl("cosmos/distribution/v1beta1/community_pool"), null,
                    cancellationToken)
                .WrapExceptions();

            return response.Body ?? throw new NullReferenceException();
        }


        /**
         * Gets the current distribution parameters.
         */
        public async Task<DistributionParams> GetDistributionParamsAsync(CancellationToken cancellationToken = default)
        {
            var response = await client
                .GetAsync<DistributionParams>(new RelativeUrl("cosmos/distribution/v1beta1/params"), null,
                    cancellationToken)
                .WrapExceptions();

            return response.Body ?? throw new NullReferenceException();
        }
    }
}