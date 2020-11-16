namespace VertMarkets.MagazineStore.API
{
    using System;
    using System.Collections.Generic;
    using VertMarkets.MagazineStore.API.Model;
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICategoriesApi : Client.IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Returns a list of available magazine categories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>ApiResponseListString</returns>
        ApiResponse<List<String>> ApiCategoriesByTokenGet(string token);
        /// <summary>
        /// Returns a list of available magazine categories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>ApiResponse of ApiResponseListString</returns>
        Client.ApiResponse<ApiResponse<List<String>>> ApiCategoriesByTokenGetWithHttpInfo(string token);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Returns a list of available magazine categories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>Task of ApiResponseListString</returns>
        System.Threading.Tasks.Task<ApiResponse<List<String>>> ApiCategoriesByTokenGetAsync(string token);
        /// <summary>
        /// Returns a list of available magazine categories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>Task of ApiResponse (ApiResponseListString)</returns>
        System.Threading.Tasks.Task<Client.ApiResponse<ApiResponse<List<String>>>> ApiCategoriesByTokenGetAsyncWithHttpInfo(string token);
        #endregion Asynchronous Operations
    }
}
