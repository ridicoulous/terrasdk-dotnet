using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Common.Extensions;
using TerraSdk.Common.Types.BigDecimal;

namespace TerraSdk.Client.Api.Mint
{
    public class MintApiService : IMintApiService
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public MintApiService(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        public Task<ResponseWithHeight<MintParams>> GetParamsAsync(long? height = default, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("minting", "parameters")
                .GetJsonAsync<ResponseWithHeight<MintParams>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<MintParams> GetParams(long? height = default)
        {
            return GetParamsAsync(height)
                .Sync();
        }

        public Task<ResponseWithHeight<BigDecimal>> GetInflationAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("minting", "inflation")
                .GetJsonAsync<ResponseWithHeight<BigDecimal>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<BigDecimal> GetInflation()
        {
            return GetInflationAsync()
                .Sync();
        }

        public Task<ResponseWithHeight<BigDecimal>> GetAnnualProvisionsAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("minting", "annual-provisions")
                .GetJsonAsync<ResponseWithHeight<BigDecimal>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<BigDecimal> GetAnnualProvisions()
        {
            return GetAnnualProvisionsAsync()
                .Sync();
        }
    }
}