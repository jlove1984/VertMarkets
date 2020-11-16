namespace VertMarkets.MagazineStore.API
{
    using System.Collections.Generic;
    using VertMarkets.MagazineStore.API.Model;
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISubscriberApi : Client.IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// This endpoint will return the current subscribers with the magazine Id&#x27;s to which they are subscribed
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>ApiResponse<List<ApiSubscriber>></returns>
        ApiResponse<List<ApiSubscriber>> ApiSubscribersByTokenGet(string token);
        /// <summary>
        /// This endpoint will return the current subscribers with the magazine Id&#x27;s to which they are subscribed
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>ApiResponse of ApiResponse<List<ApiSubscriber>></returns>
        Client.ApiResponse<ApiResponse<List<ApiSubscriber>>> ApiSubscribersByTokenGetWithHttpInfo(string token);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// This endpoint will return the current subscribers with the magazine Id&#x27;s to which they are subscribed
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>Task of ApiResponse<List<ApiSubscriber>></returns>
        System.Threading.Tasks.Task<ApiResponse<List<ApiSubscriber>>> ApiSubscribersByTokenGetAsync(string token);
        /// <summary>
        /// This endpoint will return the current subscribers with the magazine Id&#x27;s to which they are subscribed
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>Task of ApiResponse (ApiResponse<List<ApiSubscriber>>)</returns>
        System.Threading.Tasks.Task<Client.ApiResponse<ApiResponse<List<ApiSubscriber>>>> ApiSubscribersByTokenGetAsyncWithHttpInfo(string token);
        #endregion Asynchronous Operations
    }
}
