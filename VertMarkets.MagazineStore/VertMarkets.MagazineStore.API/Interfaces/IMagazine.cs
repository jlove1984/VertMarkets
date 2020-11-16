namespace VertMarkets.MagazineStore.API
{
    using System.Collections.Generic;
    using VertMarkets.MagazineStore.API.Model;

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMagazineApi : Client.IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// This endpoint will return a list of magazines for a given category
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="category">This is the name of the category from the categories endpoint.</param>
        /// <returns>ApiResponseListMagazine</returns>
        ApiResponse<List<Magazine>> ApiMagazinesByTokenByCategoryGet(string token, string category);
        /// <summary>
        /// This endpoint will return a list of magazines for a given category
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="category">This is the name of the category from the categories endpoint.</param>
        /// <returns>ApiResponse of ApiResponseListMagazine</returns>
        Client.ApiResponse<ApiResponse<List<Magazine>>> ApiMagazinesByTokenByCategoryGetWithHttpInfo(string token, string category);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// This endpoint will return a list of magazines for a given category
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="category">This is the name of the category from the categories endpoint.</param>
        /// <returns>Task of ApiResponseListMagazine</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Magazine>>> ApiMagazinesByTokenByCategoryGetAsync(string token, string category);
        /// <summary>
        /// This endpoint will return a list of magazines for a given category
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="category">This is the name of the category from the categories endpoint.</param>
        /// <returns>Task of ApiResponse (ApiResponseListMagazine)</returns>
        System.Threading.Tasks.Task<Client.ApiResponse<ApiResponse<List<Magazine>>>> ApiMagazinesByTokenByCategoryGetAsyncWithHttpInfo(string token, string category);
        #endregion Asynchronous Operations
    }
}
