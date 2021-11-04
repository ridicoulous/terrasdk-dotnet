using System;
using System.Threading;
using System.Threading.Tasks;
using RestClient.Net;
using TerraSdk.Common.Extensions;
using Urls;

namespace TerraSdk.Client.Api.Bank
{
    public class BankApiService : IBankApiService
    {
        private readonly IClient client;

        public BankApiService(IClient client)
        {
            this.client = client;
        }

        public async Task<BalanceResponse> GetBalanceAsync(string address,
            CancellationToken cancellationToken = default)
        {
            var response = await client
                .GetAsync<BalanceResponse>(new RelativeUrl($"cosmos/bank/v1beta1/balances/{address}"), null,
                    cancellationToken)
                .WrapExceptions();

            return response.Body ?? throw new NullReferenceException();
        }

        public async Task<BalanceResponse> GetTotalSupplyAsync(CancellationToken cancellationToken = default)
        {
            var response = await client
                .GetAsync<BalanceResponse>(new RelativeUrl("cosmos/bank/v1beta1/supply"), null, cancellationToken)
                .WrapExceptions();

            return response.Body ?? throw new NullReferenceException();
        }
    }
}