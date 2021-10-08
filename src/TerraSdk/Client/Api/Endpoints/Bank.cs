﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using TerraSdk.Client.Api.Models;
using TerraSdk.Common.Extensions;

namespace TerraSdk.Client.Api.Endpoints
{
    public class Bank : IBank
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Bank(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        public Task<ResponseWithHeight<IList<Coin>>> GetBankBalancesByAddressAsync(string address, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("bank", "balances", address)
                .GetJsonAsync<ResponseWithHeight<IList<Coin>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Coin>> GetBankBalancesByAddress(string address)
        {
            return GetBankBalancesByAddressAsync(address).Sync();
        }
    }
}