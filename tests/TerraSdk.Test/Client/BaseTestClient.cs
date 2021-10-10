using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Util;
using TerraSdk.Client;
using TerraSdk.Core;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Client
{
    public class BaseTestClient : BaseTest,IAsyncLifetime
    {
        public BaseTestClient(ITestOutputHelper outputHelper): base(outputHelper)
        {
            OutputHelper = outputHelper;
            Configuration = TestConfiguration.Create();
        }

        public ITestOutputHelper OutputHelper { get; }
        public TestConfiguration Configuration { get; }

        protected IFlurlResponse? LastResponse { get; set; }

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


        public Task DisposeAsync()
        {
            return Task.FromResult(0);
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
                    s.OnAfterCallAsync = async afterCall =>
                    {
                        OutputHelper.WriteLine($"Sent http request at {afterCall.StartedUtc}");
                        await WriteRequest(afterCall.Request);
                        if (afterCall?.Response != null)
                        {
                            OutputHelper.WriteLine($"Got response at {afterCall.EndedUtc}");
                            var response = afterCall.Response;
                            OutputHelper.WriteLine($"HTTP/{response.ResponseMessage.Version} {response.StatusCode} {response.ResponseMessage.ReasonPhrase}");
                            WriteHeaders((INameValueList<string>)response.Headers);
                            await WriteContent(response.ResponseMessage.Content);
                        }

                        LastResponse = afterCall?.Response;
                    };
                    s.OnBeforeCallAsync = async beforeCall =>
                    {
                        OutputHelper.WriteLine("Sending http request");
                        await WriteRequest(beforeCall.Request);
                    };
                });
        }

        private ITerraApiBuilder CreateSilentClient(string? baseUrl)
        {
            return new TerraApiBuilder()
                .UseBaseUrl(baseUrl ?? Configuration.LocalBaseUrl)
                .RegisterTerraSdkTypeConverters();
        }


        private Task WriteRequest(IFlurlRequest request)
        {
            OutputHelper.WriteLine($"{request.Verb.Method} {request.Url}"); //HTTP/{request.Version}
            WriteHeaders(request.Headers);
            //return WriteContent(request);
            return Task.CompletedTask;
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

        //protected void CheckStdTx(BaseReq baseRequest, StdTx stdTx)
        //{
        //    Assert.Equal(baseRequest.Memo, ((StdTx.MsgValue)stdTx.Value).Memo);
        //}

        //protected void CoinNotEmpty(Coin coin)
        //{
        //    Assert.NotEmpty(coin.Denom);
        //    Assert.True(coin.Amount > 0);
        //}

        //protected void TxIsDelegateAndNotEmpty(TxResponse txResponse)
        //{
        //    Assert.True(txResponse.Height > 0);
        //    Assert.True(txResponse.GasUsed > 0);
        //    Assert.True(txResponse.GasWanted > 0);
        //    Assert.NotEmpty(txResponse.Logs);
        //    Assert.NotEmpty(txResponse.RawLog);
        //    Assert.NotEmpty(txResponse.TxHash);

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
        //}
    }
}