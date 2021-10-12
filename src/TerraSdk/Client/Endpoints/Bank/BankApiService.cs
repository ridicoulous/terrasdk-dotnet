using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using TerraSdk.Common.Extensions;

namespace TerraSdk.Client.Endpoints.Bank
{
    public class BankApiService : IBankApiService
    {
        private readonly Func<IFlurlClient> clientGetter;

        public BankApiService(Func<IFlurlClient> clientGetter)
        {
            this.clientGetter = clientGetter;
        }

        public Task<Balance> GetBalanceAsync(string address, CancellationToken cancellationToken = default)
        {
            return clientGetter()
                .Request("cosmos", "bank", "v1beta1", "balances", address)
                .GetJsonAsync<Balance>(cancellationToken)
                .WrapExceptions();
        }

        public Task<Balance> GetTotalSupplyAsync(CancellationToken cancellationToken = default)
        {
            return clientGetter()
                .Request("cosmos","bank", "v1beta1", "supply")
                .GetJsonAsync<Balance>(cancellationToken)
                .WrapExceptions();
        }
    }
}