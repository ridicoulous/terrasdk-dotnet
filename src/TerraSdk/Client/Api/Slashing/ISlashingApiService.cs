using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TerraSdk.Client.Api.Gov;
using TerraSdk.ClientOld.ModelsOld;
using TerraSdk.Core;

namespace TerraSdk.Client.Api.Slashing
{
    /// <summary>
    ///     SlashingApiService module APIs.
    /// </summary>
    public interface ISlashingApiService
    {
        /// <summary>
        ///     Get sign info of a validator.
        /// </summary>
        /// <param name="publicKey">Validators public key.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<ValidatorSigningInfo>> GetSigningInfoAsync(string publicKey, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get sign info of a validator.
        /// </summary>
        /// <param name="publicKey">Validators public key.</param>
        /// <returns></returns>
        ResponseWithHeight<ValidatorSigningInfo> GetSigningInfo(string publicKey);

        /// <summary>
        ///     Get sign info of given all validators.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="limit">Maximum number of items per page.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<ValidatorSigningInfo>>> GetSigningInfosAsync(int? page = default, int? limit = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get sign info of given all validators.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="limit">Maximum number of items per page.</param>
        /// <returns></returns>
        ResponseWithHeight<IList<ValidatorSigningInfo>> GetSigningInfos(int? page = default, int? limit = default);

        /// <summary>
        ///     Post a simulation of an unjail validator request.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostUnjailSimulationAsync(string validatorAddress, UnjailRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Post a simulation of an unjail validator request.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostUnjailSimulation(string validatorAddress, UnjailRequest request);

        /// <summary>
        ///     Post an unjail validator request.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostUnjailAsync(string validatorAddress, UnjailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Post an unjail validator request.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        StdTx PostUnjail(string validatorAddress, UnjailRequest request);

        /// <summary>
        ///     Get the current slashing parameters.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<SlashingParams>> GetParametersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get the current slashing parameters.
        /// </summary>
        /// <returns></returns>
        ResponseWithHeight<SlashingParams> GetParameters();
    }
}