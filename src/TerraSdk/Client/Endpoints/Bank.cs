using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using TerraSdk.Client.Models;
using TerraSdk.Common.Extensions;
using TerraSdk.Core;

namespace TerraSdk.Client.Endpoints
{
    public class Bank : IBank
    {
        private readonly Func<IFlurlClient> clientGetter;

        public Bank(Func<IFlurlClient> clientGetter)
        {
            this.clientGetter = clientGetter;
        }

        public Task<ResponseWithHeight<IList<Coin>>> GetBalanceAsync(string address, CancellationToken cancellationToken = default)
        
        {
         Console.Write(clientGetter()
            .Request("cosmos", "bank", "v1beta1", "balances", address)
        .GetJsonAsync());

            return clientGetter()
                .Request("cosmos", "bank", "v1beta1", "balances", address)
                .GetJsonAsync<ResponseWithHeight<IList<Coin>>>(cancellationToken)
                .WrapExceptions();
        }


}
}

//import
//{ BaseAPI }
//from './BaseAPI';
//import
//{ Coins, AccAddress }
//from '../../../core';
//import
//{ APIParams }
//from '../APIRequester';

//export class BankAPI extends BaseAPI
//{
///**
//   * Look up the balance of an account by its address.
//   * @param address address of account to look up.
//   */
//public async balance(
//    address: AccAddress,
//params: APIParams = { }
//): Promise<Coins> {
//    return this.c
//        .get<Coins.Data>(`/ bank / balances /${ address}`, params)
//    .then(d => Coins.fromData(d.result));
//}

///**
// * Get the total supply of tokens in circulation for all denominations.
// */
//public async total(): Promise<Coins> {
//    return this.c
//        .get <{ supply: Coins.Data }> (`/ bank / total`)
//        .then(d => Coins.fromData(d.result.supply));
//}
//}