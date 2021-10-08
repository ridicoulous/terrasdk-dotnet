using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Util;
using TerraSdk.Client;
using TerraSdk.Client.Callbacks;
using TerraSdk.Client.Models;
using TerraSdk.Core;
using Xunit;
using Xunit.Abstractions;


namespace TerraSdk.Test.Client
{
    public class BaseTestClient: IAsyncLifetime
    {
        public ITestOutputHelper OutputHelper { get; }
        public TestConfiguration Configuration { get; }
        
        public BaseTestClient(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            Configuration = TestConfiguration.Create();
        }

        public async Task<string> GetChainId(ITerraApiClient TerraApiClient)
        {
            return (await TerraApiClient
                    .GaiaRest
                    .GetNodeInfoAsync())
                .NodeInfo
                .Network;
        }

        public ITerraApiClient CreateClient(string? baseUrl = default)
        {
            return ConfigureBuilder(baseUrl)
                .CreateClient();
        }

        public ITerraApiBuilder ConfigureBuilder(string? baseUrl)
        {
            return CreateSilentClient(baseUrl)
                .Configure(s =>
                {
                    s.OnAfterCallAsync = OnAfterCall;
                    s.OnBeforeCallAsync = OnBeforeCall;
                });
        }

        private ITerraApiBuilder CreateSilentClient(string? baseUrl)
        {
            return new TerraApiBuilder()
                .UseBaseUrl(baseUrl ?? Configuration.LocalBaseUrl)
                .RegisterTerraSdkTypeConverters();
        }

        private Task OnBeforeCall(BeforeCall beforeCall)
        {
            OutputHelper.WriteLine("Sending http request");
            return WriteRequest(beforeCall.Request);
        }

        private async Task OnAfterCall(AfterCall afterCall)
        {
            OutputHelper.WriteLine($"Sent http request at {afterCall.StartedUtc}");
            await WriteRequest(afterCall.Request);
            if (afterCall.Response != null)
            {
                OutputHelper.WriteLine($"Got response at {afterCall.EndedUtc}");
                await WriteResponse(afterCall.Response);
            }
        }

        private Task WriteResponse(IFlurlResponse response)
        {
            OutputHelper.WriteLine($"HTTP/{response.ResponseMessage.Version} {response.StatusCode} {response.ResponseMessage.ReasonPhrase}");
            WriteHeaders((INameValueList<string>)response.Headers);
            return WriteContent(response.ResponseMessage.Content);
        }

        private Task WriteRequest(IFlurlRequest request)
        {
            OutputHelper.WriteLine($"{request.Verb.Method} {request.Url}"); //HTTP/{request.Version}
            WriteHeaders(request.Headers);
            return WriteContent(null /*request.Content*/);
        }

        private async Task WriteContent(HttpContent? content)
        {
            if (content == null)
            {
                OutputHelper.WriteLine("No Content");
            }
            else
            {
                OutputHelper.WriteLine("");
                try
                {
                    var contentString = await content.ReadAsStringAsync();
                    WriteLineCutIfTooLong(contentString, "Content is too long, cutting");
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }

        private void WriteHeaders(INameValueList<string> headers)
        {
            foreach (var header in headers)
            {
                OutputHelper.WriteLine($"  >{header.Name}: {string.Join(",", header.Value)}");
            }
        }

        public void Dump(object o)
        {
            var dump = ObjectDumper.Dump(o, DumpStyle.CSharp);
            WriteLineCutIfTooLong(dump, "Object is too big, cutting.");
        }

        public void WriteLineCutIfTooLong(string message, string cutWarning)
        {
            //var punchCardLength = 80 * 12;
            //if (Configuration.CutLongOutput && message.Length > punchCardLength * 2)
            //{
            //    OutputHelper.WriteLine(cutWarning);
            //    OutputHelper.WriteLine(message[..(punchCardLength * 2 - 3)] + "...");
            //}
            //else
            //{
                OutputHelper.WriteLine(message);
            //}
        }

        protected void CheckStdTx(BaseReq baseRequest, StdTx stdTx)
        {
            Assert.Equal(baseRequest.Memo, ((StdTx.MsgValue)stdTx.Value).Memo);
        }

        protected void CoinNotEmpty(Coin coin)
        {
            Assert.NotEmpty(coin.Denom);
            Assert.True(coin.Amount > 0);
        }

        protected void TxIsDelegateAndNotEmpty(TxResponse txResponse)
        {
            Assert.True(txResponse.Height > 0);
            Assert.True(txResponse.GasUsed > 0);
            Assert.True(txResponse.GasWanted > 0);
            Assert.NotEmpty(txResponse.Logs);
            Assert.NotEmpty(txResponse.RawLog);
            Assert.NotEmpty(txResponse.TxHash);

            //var stdTx = Assert.IsType<StdTx>(txResponse.Tx);
            //Assert.NotEmpty(stdTx.Signatures);
            //Assert.All(stdTx.Signatures, s =>
            //{
            //    Assert.NotEmpty(s.Signature);
            //});
            //if (stdTx.Fee.Gas == 0)
            //{
            //    Assert.NotEmpty(stdTx.Fee.Amount);
            //    Assert.All(stdTx.Fee.Amount, CoinNotEmpty);
            //}

            //var delegateMsg = stdTx
            //    .Msg
            //    .OfType<MsgDelegate>()
            //    .First();
            //CoinNotEmpty(delegateMsg.Amount);
            //Assert.NotEmpty(delegateMsg.DelegatorAddress);
            //Assert.NotEmpty(delegateMsg.ValidatorAddress);
        }

        public Task InitializeAsync()
        {
        //    var client = CreateSilentClient(Configuration.LocalBaseUrl).CreateClient();
        //    var proposals = await client.Governance.GetProposalsAsync(depositor: Configuration.LocalAccount1Address);
        //    if (proposals.Result.Any())
        //    {
        //        return;
        //    }
            
        //    await CreateDelegateTx(client);
        //    await CreateUnbondTx(client);
        //    await CreateSubmitProposal(client);
        //    await CreateDepositAccount2(client);
        //    await CreateDepositDelegator1(client);
        //    await Task.Delay(TimeSpan.FromSeconds(20));
        //    await CreateVoteNo(client);
        //    await CreateVoteAbstain(client);
        //    await CreateVoteYes(client);

        return Task.FromResult(true);

        }

        //private async Task CreateVoteAbstain(ITerraApiClient client)
        //{
        //    var tx = await client.Governance.PostVoteAsync(1, new VoteReq(
        //        await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null),
        //        Configuration.LocalDelegator1Address, 
        //        VoteOption.Abstain));
        //    await client.SignAndBroadcastStdTxAsync(tx, Delegator1Signer(), BroadcastTxMode.Block);
        //}

        //private async Task CreateVoteNo(ITerraApiClient client)
        //{
        //    var tx = await client.Governance.PostVoteAsync(1, new VoteReq(
        //        await client.CreateBaseReq(Configuration.LocalAccount2Address, null, null, null, null, null),
        //        Configuration.LocalAccount2Address, 
        //        VoteOption.No));
        //    await client.SignAndBroadcastStdTxAsync(tx, Account2Signer(), BroadcastTxMode.Block);
        //}

        //private async Task CreateVoteYes(ITerraApiClient client)
        //{
        //    var tx = await client.Governance.PostVoteAsync(1, new VoteReq(
        //        await client.CreateBaseReq(Configuration.LocalAccount1Address, null, null, null, null, null),
        //        Configuration.LocalAccount1Address, 
        //        VoteOption.Yes));
        //    await client.SignAndBroadcastStdTxAsync(tx, Account1Signer(), BroadcastTxMode.Block);
        //}

        //private async Task CreateDepositDelegator1(ITerraApiClient client)
        //{
        //    var tx = await client.Governance.PostDepositAsync(1, new DepositReq(
        //        await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null),
        //        Configuration.LocalDelegator1Address, 
        //        new [] { new Coin("stake", 2000000)}));
        //    await client.SignAndBroadcastStdTxAsync(tx, Delegator1Signer(), BroadcastTxMode.Block);
        //}

        //private async Task CreateDepositAccount2(ITerraApiClient client)
        //{
        //    var tx = await client.Governance.PostDepositAsync(1, new DepositReq(
        //        await client.CreateBaseReq(Configuration.LocalAccount2Address, null, null, null, null, null),
        //        Configuration.LocalAccount2Address, 
        //        new [] { new Coin("stake", 2000000)}));
        //    await client.SignAndBroadcastStdTxAsync(tx, Account2Signer(), BroadcastTxMode.Block);
        //}

        //private async Task CreateSubmitProposal(ITerraApiClient client)
        //{
        //    var tx = await client.Governance.PostProposalAsync(new PostProposalReq(
        //        await client.CreateBaseReq(Configuration.LocalAccount1Address, null, null, null, null, null),
        //        "Test Proposal Title",
        //        "Test Proposal Description",
        //        "Text",
        //        Configuration.LocalAccount1Address, 
        //        new [] { new Coin("stake", 7000000)}));
        //    await client.SignAndBroadcastStdTxAsync(tx, Account1Signer(), BroadcastTxMode.Block);
        //}

        //private async Task CreateUnbondTx(ITerraApiClient client)
        //{
        //    var tx = await client.Staking.PostUnbondingDelegationAsync(new UndelegateRequest(
        //        await client.CreateBaseReq(Configuration.LocalAccount1Address, null, null, null, null, null),
        //        Configuration.LocalAccount1Address, Configuration.LocalValidator1Address, 
        //        new Coin("stake", 99)));
        //    await client.SignAndBroadcastStdTxAsync(tx, Account1Signer(), BroadcastTxMode.Block);
        //}

        //private async Task CreateDelegateTx(ITerraApiClient client)
        //{
        //    var tx = await client.Staking.PostDelegationsAsync(new DelegateRequest(
        //        await client.CreateBaseReq(Configuration.LocalAccount1Address, null, null, null, null, null),
        //        Configuration.LocalAccount1Address, Configuration.LocalValidator1Address, 
        //        new Coin("stake", 9999)));
        //    await client.SignAndBroadcastStdTxAsync(tx, Account1Signer(), BroadcastTxMode.Block);
        //}

        //private SignerWithAddress[] Delegator1Signer()
        //{
        //    return new[]
        //    {
        //        new SignerWithAddress(Configuration.LocalDelegator1Address, Configuration.LocalDelegator1PrivateKey,
        //            Configuration.LocalDelegator1Passphrase),
        //    };
        //}

        //private SignerWithAddress[] Account1Signer()
        //{
        //    return new[]
        //    {
        //        new SignerWithAddress(Configuration.LocalAccount1Address, Configuration.LocalAccount1PrivateKey,
        //            Configuration.LocalAccount1Passphrase),
        //    };
        //}

        //private SignerWithAddress[] Account2Signer()
        //{
        //    return new[]
        //    {
        //        new SignerWithAddress(Configuration.LocalAccount2Address, Configuration.LocalAccount2PrivateKey,
        //            Configuration.LocalAccount2Passphrase),
        //    };
        //}

        public Task DisposeAsync()
        {
            return Task.FromResult(0);
        }
    }
}