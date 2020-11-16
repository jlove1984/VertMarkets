namespace VertMarkets.MagazineStore.API
{
    using VertMarkets.MagazineStore.API.Model;
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAnswerApi : Client.IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// You will be posting your answer to this endpoint. It should be a json object that holds a list of subscribers.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="body">This is an object with a list of subscriberIds that match the criteria in the exercise (optional)</param>
        /// <returns>ApiResponseAnswerResponse</returns>
        ApiResponse<AnswerResponse> ApiAnswerByTokenPost(string token, Answer body = null);
        /// <summary>
        /// You will be posting your answer to this endpoint. It should be a json object that holds a list of subscribers.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="body">This is an object with a list of subscriberIds that match the criteria in the exercise (optional)</param>
        /// <returns>ApiResponse of ApiResponseAnswerResponse</returns>
        Client.ApiResponse<ApiResponse<AnswerResponse>> ApiAnswerByTokenPostWithHttpInfo(string token, Answer body = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// You will be posting your answer to this endpoint. It should be a json object that holds a list of subscribers.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="body">This is an object with a list of subscriberIds that match the criteria in the exercise (optional)</param>
        /// <returns>Task of ApiResponseAnswerResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<AnswerResponse>> ApiAnswerByTokenPostAsync(string token, Answer body = null);
        /// <summary>
        /// You will be posting your answer to this endpoint. It should be a json object that holds a list of subscribers.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="body">This is an object with a list of subscriberIds that match the criteria in the exercise (optional)</param>
        /// <returns>Task of ApiResponse (ApiResponseAnswerResponse)</returns>
        System.Threading.Tasks.Task<Client.ApiResponse<ApiResponse<AnswerResponse>>> ApiAnswerByTokenPostAsyncWithHttpInfo(string token, Answer body = null);
        #endregion Asynchronous Operations
    }
}
