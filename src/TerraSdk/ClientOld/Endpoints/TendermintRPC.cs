﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Common.Extensions;

namespace TerraSdk.ClientOld.Endpoints
{
    internal class TendermintRPC : ITendermintRPC
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public TendermintRPC(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        public Task<NodeSyncingStatus> GetSyncingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("syncing")
                .GetJsonAsync<NodeSyncingStatus>(cancellationToken: cancellationToken)
                .WrapExceptionsOld();
        }

        public NodeSyncingStatus GetSyncing()
        {
            return GetSyncingAsync().Sync();
        }

        public Task<BlockQuery> GetLatestBlockAsync(CancellationToken cancellationToken = default(CancellationToken))
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

        public Task<BlockQuery> GetBlockByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken))
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

        public Task<ResponseWithHeight<ValidatorSet>> GetLatestValidatorSetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("validatorsets", "latest")
                .GetJsonAsync<ResponseWithHeight<ValidatorSet>>(cancellationToken: cancellationToken)
                .WrapExceptionsOld();
        }

        public ResponseWithHeight<ValidatorSet> GetLatestValidatorSet()
        {
            return GetLatestValidatorSetAsync().Sync();
        }

        public Task<ResponseWithHeight<ValidatorSet>> GetValidatorSetByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("validatorsets", height)
                .GetJsonAsync<ResponseWithHeight<ValidatorSet>>(cancellationToken: cancellationToken)
                .WrapExceptionsOld();
        }

        public ResponseWithHeight<ValidatorSet> GetValidatorSetByHeight(long height)
        {
            return GetValidatorSetByHeightAsync(height).Sync();
        }
    }
}