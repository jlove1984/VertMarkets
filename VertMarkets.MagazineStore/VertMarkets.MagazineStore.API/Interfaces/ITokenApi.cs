namespace VertMarkets.MagazineStore.API
{
    using VertMarkets.MagazineStore.API.Model;
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITokenApi : Client.IApiAccessor
    {        
        #region Synchronous Operations
        /// <summary>
        /// Use this API call to initiate your program. It will return a token  that you must then pass along to all subsequent calls.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse</returns>
        ApiResponse ApiTokenGet();
        /// <summary>
        /// Use this API call to initiate your program. It will return a token  that you must then pass along to all subsequent calls.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of ApiResponse</returns>
        Client.ApiResponse<ApiResponse> ApiTokenGetWithHttpInfo();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Use this API call to initiate your program. It will return a token  that you must then pass along to all subsequent calls.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse> ApiTokenGetAsync();
        /// <summary>
        /// Use this API call to initiate your program. It will return a token  that you must then pass along to all subsequent calls.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (ApiResponse)</returns>
        System.Threading.Tasks.Task<Client.ApiResponse<ApiResponse>> ApiTokenGetAsyncWithHttpInfo();
        #endregion Asynchronous Operations
    }
    }