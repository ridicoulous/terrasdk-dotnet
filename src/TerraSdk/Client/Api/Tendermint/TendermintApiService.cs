using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using TerraSdk.Common.Extensions;

namespace TerraSdk.Client.Api.Tendermint
{
    internal class TendermintApiService : ITendermintApiService
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public TendermintApiService(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        public Task<NodeSyncingStatus> GetSyncingAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("syncing")
                .GetJsonAsync<NodeSyncingStatus>(cancellationToken)
                .WrapExceptionsOld();
        }

        public NodeSyncingStatus GetSyncing()
        {
            return GetSyncingAsync().Sync();
        }

        public Task<BlockQuery> GetLatestBlockAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("blocks", "latest")
                .GetJsonAsync<BlockQuery>(cancellationToken)
                .WrapExceptionsOld();
        }

        public BlockQuery GetLatestBlock()
        {
            return GetLatestBlockAsync().Sync();
        }

        public Task<BlockQuery> GetBlockByHeightAsync(long height, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("blocks", height)
                .GetJsonAsync<BlockQuery>(cancellationToken)
                .WrapExceptionsOld();
        }

        public BlockQuery GetBlockByHeight(long height)
        {
            return GetBlockByHeightAsync(height).Sync();
        }

        public Task<ResponseWithHeight<ValidatorSet>> GetLatestValidatorSetAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("validatorsets", "latest")
                .GetJsonAsync<ResponseWithHeight<ValidatorSet>>(cancellationToken)
                .WrapExceptionsOld();
        }

        public ResponseWithHeight<ValidatorSet> GetLatestValidatorSet()
        {
            return GetLatestValidatorSetAsync().Sync();
        }

        public Task<ResponseWithHeight<ValidatorSet>> GetValidatorSetByHeightAsync(long height, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("validatorsets", height)
                .GetJsonAsync<ResponseWithHeight<ValidatorSet>>(cancellationToken)
                .WrapExceptionsOld();
        }

        public ResponseWithHeight<ValidatorSet> GetValidatorSetByHeight(long height)
        {
            return GetValidatorSetByHeightAsync(height).Sync();
        }
    }
}