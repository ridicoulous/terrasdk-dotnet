using System;
using Newtonsoft.Json;
using TerraSdk.Client.Api.Auth;
using TerraSdk.Client.Api.Tx;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Core;

namespace TerraSdk.ClientOld
{
    /// <summary>
    ///     Interface for setting client configuration before creating.
    /// </summary>
    public interface ITerraApiBuilder
    {
        /// <summary>
        ///     Creates a new instance of Terra Api Client.
        /// </summary>
        ITerraApiClient CreateClient();

        /// <summary>
        ///     Sets settings of created clients using Action.
        /// </summary>
        ITerraApiBuilder Configure(Action<TerraApiClientSettings> configurator);

        /// <summary>
        ///     Sets username and password authorization for created clients.
        /// </summary>
        ITerraApiBuilder UseAuthorization(string username, string password);

        /// <summary>
        ///     Sets the base url used by created clients.
        /// </summary>
        ITerraApiBuilder UseBaseUrl(string url);

        /// <summary>
        ///     Adds a possible subtype of the <see cref="ITx" /> so it can be serialized
        ///     and deserialized properly.
        /// </summary>
        /// <typeparam name="T">Type which might be used where <see cref="ITx" /> is used.</typeparam>
        /// <param name="jsonName">Value of the type discriminator.</param>
        ITerraApiBuilder RegisterTxType<T>(string jsonName) where T : ITx;

        /// <summary>
        ///     Adds a possible subtype of the <see cref="IMsg" /> so it can be serialized
        ///     and deserialized properly.
        /// </summary>
        /// <typeparam name="T">Type which might be used where <see cref="IMsg" /> is used.</typeparam>
        /// <param name="jsonName">Value of the type discriminator.</param>
        ITerraApiBuilder RegisterMsgType<T>(string jsonName) where T : Msg;

        /// <summary>
        ///     Adds a possible subtype of the <see cref="IAccount" /> so it can be serialized
        ///     and deserialized properly.
        /// </summary>
        /// <typeparam name="T">Type which might be used where <see cref="IAccount" /> is used.</typeparam>
        /// <param name="jsonName">Value of the type discriminator.</param>
        ITerraApiBuilder RegisterAccountType<T>(string jsonName) where T : IAccount;

        /// <summary>
        ///     Adds a possible subtype of the <see cref="IProposalContent" /> so it can be serialized
        ///     and deserialized properly.
        /// </summary>
        /// <typeparam name="T">Type which might be used where <see cref="IProposalContent" /> is used.</typeparam>
        /// <param name="jsonName">Value of the type discriminator.</param>
        ITerraApiBuilder RegisterProposalContentType<T>(string jsonName) where T : IProposalContent;

        /// <summary>
        ///     Adds a converter factory to use for serialization and deserialization.
        /// </summary>
        ITerraApiBuilder AddJsonConverter(JsonConverter converter);

        /// <summary>
        ///     Registers json converters for types declared in Terra sdk.
        /// </summary>
        ITerraApiBuilder RegisterTerraSdkTypeConverters();
    }
}