using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Common.Extensions;

namespace TerraSdk.ClientOld.Endpoints
{
    public class Auth : IAuth
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Auth(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        public Task<ResponseWithHeight<IAccount>> GetAuthAccountByAddressAsync(string address, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("auth", "accounts", address)
                .GetJsonAsync<ResponseWithHeight<IAccount>>(cancellationToken: cancellationToken)
                .WrapExceptionsOld();
        }

        public ResponseWithHeight<IAccount> GetAuthAccountByAddress(string address)
        {
            return GetAuthAccountByAddressAsync(address)
                .Sync();
        }
    }
}