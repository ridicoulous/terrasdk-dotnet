using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TerraSdk.Client.Api.Auth;
using TerraSdk.Client.Api.Bank;
using TerraSdk.Client.Api.Gov;
using TerraSdk.Client.Api.Tendermint;
using TerraSdk.Client.Api.Tx;
using TerraSdk.ClientOld.Crypto;
using TerraSdk.ClientOld.Endpoints;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Common.Serialization;
using TerraSdk.Core;
using TerraSdk.Core.Account;
using TerraSdk.Core.Bank.Msgs;

namespace TerraSdk.ClientOld
{
    public interface ITerraApiClient : IDisposable
    {
        IGaiaREST GaiaRest { get; }
        ITendermintApiService TendermintApiService { get; }
        ITransactionsApiService TransactionsApiService { get; }
        IAuth Auth { get; }

        IBankApiService BankApiService { get; }
        //IStakingApiService StakingApiService { get; }
        //IGovernanceApiService GovernanceApiService { get; }
        //ISlashingApiService SlashingApiService { get; }
        //IDistributionApiService Distribution { get; }
        //IMintApiService MintApiService { get; }

        HttpClient HttpClient { get; }
        ISerializer Serializer { get; }
        ICryptoService CryptoService { get; }

        /// <summary>
        ///     Creates signed transaction and broadcasts it.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="coins"></param>
        /// <param name="mode"></param>
        /// <param name="fee"></param>
        /// <param name="privateKey"></param>
        /// <param name="passphrase"></param>
        /// <param name="memo"></param>
        /// <param name="cancellationToken"></param>
        public Task<BroadcastTxResult> SendAsync(string fromAddress, string toAddress, IList<Coin> coins, BroadcastTxMode mode, StdFee fee,
            string privateKey, string passphrase, string memo = "", CancellationToken cancellationToken = default)
        {
            var msg = new MsgSend(new AccAddress(fromAddress), new AccAddress(toAddress), new Coins(coins));
            var tx = new StdTx(new[] {msg}, fee, new StdSignature[] { }, memo, null);

            return SignAndBroadcastStdTxAsync(tx, new[] {new SignerWithAddress(fromAddress, privateKey, passphrase)}, mode, cancellationToken);
        }

        public async Task<BaseReq> CreateBaseReq(string from, string? memo, IList<Coin>? fees, IList<Coin>? gasPrices, string? gas,
            string? gasAdjustment, CancellationToken cancellationToken = default)
        {
            var chainTask = GaiaRest.GetNodeInfoAsync(cancellationToken);
            var accountTask = Auth.GetAuthAccountByAddressAsync(from, cancellationToken);

            var (nodeInfo, account) = await (chainTask, accountTask);

            return new BaseReq(from, memo, nodeInfo.NodeInfo.Network, account.Result.GetAccountNumber(), account.Result.GetSequence(), fees,
                gasPrices, gas, gasAdjustment);
        }

        public async Task<BroadcastTxResult> SignAndBroadcastStdTxAsync(StdTx tx, IEnumerable<SignerWithAddress> signers,
            BroadcastTxMode mode = BroadcastTxMode.Async, CancellationToken cancellationToken = default)
        {
            var signersSelector = signers.Select(async s => new Signer((await Auth.GetAuthAccountByAddressAsync(s.Address, cancellationToken)).Result,
                s.EncodedPrivateKey, s.Passphrase));

            var (nodeInfo, accountSigners) = await (GaiaRest.GetNodeInfoAsync(cancellationToken), Task.WhenAll(signersSelector));
            CryptoService.SignStdTx(tx, accountSigners, nodeInfo.NodeInfo.Network, Serializer);
            return await TransactionsApiService.PostBroadcastAsync(new BroadcastTxBody(tx, mode), cancellationToken);
        }
    }
}