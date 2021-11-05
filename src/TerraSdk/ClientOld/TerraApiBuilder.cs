using System;
using System.Collections.Immutable;
using Newtonsoft.Json;
using TerraSdk.Client.Api.Auth;
using TerraSdk.Client.Api.Tx;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Core;
using TerraSdk.Core.Bank.Msgs;
using TerraSdk.Core.Distribution.Msgs;
using TerraSdk.Core.Distribution.Proposals;
using TerraSdk.Core.Gov.Msgs;
using TerraSdk.Core.Gov.Proposals;
using TerraSdk.Core.Params.Proposals;
using TerraSdk.Core.Slashing.Msgs;
using TerraSdk.Core.Upgrade.Proposals;

namespace TerraSdk.ClientOld
{
    public class TerraApiBuilder : ITerraApiBuilder
    {
        private readonly ImmutableList<Action<TerraApiClientSettings>> settingConfigurators = ImmutableList.Create<Action<TerraApiClientSettings>>();

        internal TerraApiBuilder(ImmutableList<Action<TerraApiClientSettings>> settingConfigurators)
        {
            this.settingConfigurators = settingConfigurators;
        }

        public TerraApiBuilder()
        {
        }

        public ITerraApiClient CreateClient()
        {
            var settings = new TerraApiClientSettings();
            foreach (var configurator in settingConfigurators) configurator(settings);

            return new TerraApiClient(settings);
        }

        public ITerraApiBuilder Configure(Action<TerraApiClientSettings> configurator)
        {
            return new TerraApiBuilder(settingConfigurators.Add(configurator));
        }

        public ITerraApiBuilder UseAuthorization(string username, string password)
        {
            return Configure(s =>
            {
                s.Password = password;
                s.Username = username;
            });
        }

        public ITerraApiBuilder UseBaseUrl(string url)
        {
            return Configure(s => s.BaseUrl = url);
        }

        public ITerraApiBuilder RegisterTxType<T>(string jsonName) where T : ITx
        {
            return Configure(s => s.TxConverter.AddType<T>(jsonName));
        }

        public ITerraApiBuilder RegisterMsgType<T>(string jsonName) where T : Msg
        {
            return Configure(s => s.MsgConverter.AddType<T>(jsonName));
        }

        public ITerraApiBuilder RegisterAccountType<T>(string jsonName) where T : IAccount
        {
            return Configure(s => s.AccountConverter.AddType<T>(jsonName));
        }

        public ITerraApiBuilder RegisterProposalContentType<T>(string jsonName) where T : IProposalContent
        {
            return Configure(s => s.ProposalContentConverter.AddType<T>(jsonName));
        }

        public ITerraApiBuilder AddJsonConverter(JsonConverter converter)
        {
            return Configure(configuration => configuration.Converters.Add(converter));
        }

        public ITerraApiBuilder RegisterTerraSdkTypeConverters()
        {
            return Configure(configuration =>
            {
                configuration.TxConverter.AddType<StdTx>("Terra-sdk/StdTx");

                configuration.MsgConverter.AddType<MsgMultiSend>("Terra-sdk/MsgMultiSend");
                configuration.MsgConverter.AddType<MsgSend>("Terra-sdk/MsgSend");
                configuration.MsgConverter.AddType<MsgDelegate>("Terra-sdk/MsgDelegate");
                configuration.MsgConverter.AddType<MsgUndelegate>("Terra-sdk/MsgUndelegate");
                configuration.MsgConverter.AddType<MsgBeginRedelegate>("Terra-sdk/MsgBeginRedelegate");
                configuration.MsgConverter.AddType<MsgSubmitProposal>("Terra-sdk/MsgSubmitProposal");
                configuration.MsgConverter.AddType<MsgVerifyInvariant>("Terra-sdk/MsgVerifyInvariant");
                configuration.MsgConverter.AddType<MsgSetWithdrawAddress>("Terra-sdk/MsgModifyWithdrawAddress");
                configuration.MsgConverter.AddType<MsgWithdrawDelegatorReward>("Terra-sdk/MsgWithdrawDelegationReward");
                configuration.MsgConverter.AddType<MsgWithdrawValidatorCommission>("Terra-sdk/MsgWithdrawValidatorCommission");
                configuration.MsgConverter.AddType<MsgDeposit>("Terra-sdk/MsgDeposit");
                configuration.MsgConverter.AddType<MsgVote>("Terra-sdk/MsgVote");
                configuration.MsgConverter.AddType<MsgUnjail>("Terra-sdk/MsgUnjail");
                configuration.MsgConverter.AddType<MsgCreateValidator>("Terra-sdk/MsgCreateValidator");

                configuration.AccountConverter.AddType<BaseAccount>("Terra-sdk/Account");

                configuration.ProposalContentConverter.AddType<TextProposal>("Terra-sdk/TextProposal");
                configuration.ProposalContentConverter.AddType<CommunityPoolSpendProposal>("Terra-sdk/CommunityPoolSpendProposal");
                configuration.ProposalContentConverter.AddType<SoftwareUpgradeProposal>("Terra-sdk/SoftwareUpgradeProposal");
                configuration.ProposalContentConverter.AddType<ParameterChangeProposal>("Terra-sdk/ParameterChangeProposal");
            });
        }
    }
}