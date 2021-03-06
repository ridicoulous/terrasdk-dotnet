using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using TerraSdk.Client.Api.Auth;
using TerraSdk.Client.Api.Bank;
using TerraSdk.Client.Api.Tendermint;
using TerraSdk.Client.Api.Tx;
using TerraSdk.ClientOld.Callbacks;
using TerraSdk.ClientOld.Crypto;
using TerraSdk.ClientOld.Endpoints;
using TerraSdk.Common.Extensions;
using TerraSdk.Common.Flurl;
using TerraSdk.Common.Serialization;
using ISerializer = TerraSdk.Common.Serialization.ISerializer;

namespace TerraSdk.ClientOld
{
    public class TerraApiClient : ITerraApiClient
    {
        private readonly TerraApiClientSettings _settings;
        private Lazy<IFlurlClient>? _flurlClient;

        public TerraApiClient(TerraApiClientSettings settings)
        {
            _settings = settings;
            _flurlClient = new Lazy<IFlurlClient>(CreateClient, LazyThreadSafetyMode.ExecutionAndPublication);

            GaiaRest = new GaiaREST(GetClient);
            TendermintApiService = new TendermintApiService(GetClient);
            TransactionsApiService = new TransactionsApiService(GetClient);
            Auth = new Auth(GetClient);
            //BankApiService = new BankApiService(GetClient);
            //StakingApiService = new StakingApiService(GetClient);
            //GovernanceApiService = new GovernanceApiService(GetClient);
            //SlashingApiService = new SlashingApiService(GetClient);
            //Distribution = new Distribution(GetClient);
            //MintApiService = new MintApiService(GetClient);
            var jsonSerializerSettings = JsonSerializerSettings();
            Serializer = new NewtownJsonSerializer(jsonSerializerSettings);
        }

        public IGaiaREST GaiaRest { get; }
        public ITendermintApiService TendermintApiService { get; }
        public ITransactionsApiService TransactionsApiService { get; }
        public IAuth Auth { get; }

        public IBankApiService BankApiService { get; }
        //public IStakingApiService StakingApiService { get; }
        //public IGovernanceApiService GovernanceApiService { get; }
        //public ISlashingApiService SlashingApiService { get; }
        //public IDistributionApiService Distribution { get; }
        //public IMintApiService MintApiService { get; }

        public HttpClient HttpClient =>
            _flurlClient?.Value.HttpClient ?? throw new ObjectDisposedException(nameof(TerraApiClient));

        public ISerializer Serializer { get; }
        public ICryptoService CryptoService => _settings.CryptoService;

        public void Dispose()
        {
            if (_flurlClient?.IsValueCreated == true)
            {
                _flurlClient.Value.Dispose();
                _flurlClient = null;
            }
        }

        private IFlurlClient GetClient()
        {
            return _flurlClient?.Value ?? throw new ObjectDisposedException(nameof(TerraApiClient));
        }

        private IFlurlClient CreateClient()
        {
            var client = new FlurlClient()
                .Configure(s =>
                {
                    s.ConnectionLeaseTimeout = _settings.ConnectionLeaseTimeout;
                    s.Timeout = _settings.Timeout;
                    if (_settings.HttpClientFactory != null || _settings.CreateMessageHandlerFactory != null)
                        s.HttpClientFactory = new DelegateClientFactory(_settings.HttpClientFactory, _settings.CreateMessageHandlerFactory);

                    if (_settings.OnError != null)
                        s.OnError = call =>
                        {
                            var error = new Error(call.Request, call.Response, call.StartedUtc, call.EndedUtc, call.Exception.WrapExceptionOld(),
                                call.ExceptionHandled);
                            _settings.OnError(error);
                            call.ExceptionHandled = error.Handled;
                        };
                    if (_settings.OnErrorAsync != null)
                        s.OnErrorAsync = async call =>
                        {
                            var error = new Error(call.Request, call.Response, call.StartedUtc, call.EndedUtc, call.Exception.WrapExceptionOld(),
                                call.ExceptionHandled);
                            await _settings.OnErrorAsync(error);
                            call.ExceptionHandled = error.Handled;
                        };

                    if (_settings.OnBeforeCall != null) s.BeforeCall = call => _settings.OnBeforeCall(new BeforeCall(call.Request));
                    if (_settings.OnBeforeCallAsync != null) s.BeforeCallAsync = call => _settings.OnBeforeCallAsync(new BeforeCall(call.Request));

                    if (_settings.OnAfterCall != null)
                        s.AfterCall = call => _settings.OnAfterCall(new AfterCall(call.Request, call.Response, call.StartedUtc, call.EndedUtc));
                    if (_settings.OnAfterCallAsync != null)
                        s.AfterCallAsync = call =>
                            _settings.OnAfterCallAsync(new AfterCall(call.Request, call.Response, call.StartedUtc, call.EndedUtc));

                    var jsonSerializerSettings = JsonSerializerSettings();

                    s.JsonSerializer = new NewtonsoftJsonSerializer(jsonSerializerSettings);
                });
            if (_settings.BaseUrl != null)
            {
                client.BaseUrl = _settings.BaseUrl;
                client.HttpClient.BaseAddress = new Uri(_settings.BaseUrl);
            }

            if (_settings.Username != null && _settings.Password != null) client = client.WithBasicAuth(_settings.Username, _settings.Password);

            return client;
        }

        private JsonSerializerSettings JsonSerializerSettings()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            foreach (var converter in _settings.Converters) jsonSerializerSettings.Converters.Add(converter);

            jsonSerializerSettings.Converters.Add(new BigDecimalConverter());
            if (_settings.MsgConverter.JsonNameToType.Any()) jsonSerializerSettings.Converters.Add(_settings.MsgConverter);
            if (_settings.TxConverter.JsonNameToType.Any()) jsonSerializerSettings.Converters.Add(_settings.TxConverter);
            if (_settings.AccountConverter.JsonNameToType.Any()) jsonSerializerSettings.Converters.Add(_settings.AccountConverter);
            if (_settings.ProposalContentConverter.JsonNameToType.Any()) jsonSerializerSettings.Converters.Add(_settings.ProposalContentConverter);
            return jsonSerializerSettings;
        }
    }
}