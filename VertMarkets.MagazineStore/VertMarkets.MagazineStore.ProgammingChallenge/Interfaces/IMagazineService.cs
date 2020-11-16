namespace VertMarkets.MagazineStore.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VertMarkets.MagazineStore.API.Client;
    /// <summary>
    /// Represents a collection of functions to interact with the Magazine Store API endpoints
    /// </summary>
    public interface IMagazineService
    {
        /// <summary>
        /// Utilizes the Magazine API endpoints to identify all subscribers that are subscribed to at least one magazine in each
        /// category.Then submit their id's to the answer endpoint and print the result to the console.
        /// The answer endpoint will return a result object, that will let you know how long it took for you to
        /// get to the answer as well as if it was correct.
        /// </summary>        
        /// <returns></returns>
        API.Model.ApiResponse<API.Model.AnswerResponse> Challenge();
        /// <summary>
        /// Retrievs a token from the token endpoint, which is passed along to any subsequent call. Don't reuse the token across multiple runs of
        /// your program as they expire.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        API.Model.ApiResponse GetToken(Configuration config = null);
        /// <summary>
        /// Returns the current magazine categories
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        API.Model.ApiResponse<List<string>> GetCategories(string token, Configuration config = null);
        /// <summary>
        /// Return our current subscribers along with the magazine ids that they are subscribed to.
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        API.Model.ApiResponse<List<API.Model.ApiSubscriber>> GetSubscribers(string token, Configuration config = null);
        /// <summary>
        /// Return a list of magazines for a given category
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="category">This is the name of the category from the categories endpoint.</param>
        /// <param name="config">An instance of Configuration</param>
        /// <returns></returns>
        API.Model.ApiResponse<List<API.Model.Magazine>> GetMagazines(string token, string category, Configuration config = null);

        /// <summary>
        /// Post your answer to this endpoint. It should be a json object that holds a list of subscribers.
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="answer">This is an object with a list of subscriberIds that match the criteria in the exercise</param>
        /// <param name="config">An instance of Configuration</param>
        /// <returns></returns>
        API.Model.ApiResponse<API.Model.AnswerResponse> SubmitAnswer(string token, API.Model.Answer answer, Configuration config = null);

        /// <summary>
        /// Utilizes the Magazine API endpoints to identify all subscribers that are subscribed to at least one magazine in each
        /// category.Then submit their id's to the answer endpoint and print the result to the console.
        /// The answer endpoint will return a result object, that will let you know how long it took for you to
        /// get to the answer as well as if it was correct.
        /// </summary>        
        /// <returns></returns>
        Task<API.Model.ApiResponse<API.Model.AnswerResponse>> ChallengeAsync();
        /// <summary>
        /// Retrievs a token from the token endpoint, which is passed along to any subsequent call. Don't reuse the token across multiple runs of
        /// your program as they expire.
        /// </summary>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        Task<API.Model.ApiResponse> GetTokenAsync(Configuration config = null);
        /// <summary>
        /// Returns the current magazine categories
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        Task<API.Model.ApiResponse<List<string>>> GetCategoriesAsync(string token, Configuration config = null);
        /// <summary>
        /// Return our current subscribers along with the magazine ids that they are subscribed to.
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        Task<API.Model.ApiResponse<List<API.Model.ApiSubscriber>>> GetSubscribersAsync(string token, Configuration config = null);
        /// <summary>
        /// Return a list of magazines for a given category
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="category">This is the name of the category from the categories endpoint.</param>
        /// <param name="config">An instance of Configuration</param>
        /// <returns></returns>
        Task<API.Model.ApiResponse<List<API.Model.Magazine>>> GetMagazinesAsync(string token, string category, Configuration config = null);
        /// <summary>
        /// Post your answer to this endpoint. It should be a json object that holds a list of subscribers.
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="answer">This is an object with a list of subscriberIds that match the criteria in the exercise</param>
        /// <param name="config">An instance of Configuration</param>
        /// <returns></returns>
        Task<API.Model.ApiResponse<API.Model.AnswerResponse>> SubmitAnswerAsync(string token, API.Model.Answer answer, Configuration config = null);
        

        /// <summary>
        /// Returns a list of subscriber ids that are subscribed to at least one magazine in each category.
        /// </summary>
        /// <param name="categories">This is the list of categories that will be used for matching. Subscribers must subscriber to at least one magazine from each of these categories.</param>
        /// <param name="subscribers">This is the list of subscribers, each containing the magazines they are subscribed to</param>
        /// <param name="magazines">This is the list of all magazines, for all categories</param>
        /// <returns></returns>
        API.Model.Answer GetAnswer(List<string> categories, List<API.Model.ApiSubscriber> subscribers, List<API.Model.Magazine> magazines);
        /// <summary>
        /// Returns a list of subscriber ids that are subscribed to at least one magazine in each category.
        /// </summary>
        /// <param name="categories">This is the list of categories that will be used for matching. Subscribers must subscriber to at least one magazine from each of these categories.</param>
        /// <param name="subscribers">This is the list of subscribers, each containing the magazines they are subscribed to</param>
        /// <param name="magazines">This is the list of all magazines, for all categories</param>
        /// <returns></returns>
        Task<API.Model.Answer> GetAnswerAsync(List<string> categories, List<API.Model.ApiSubscriber> subscribers, List<API.Model.Magazine> magazines);
        /// <summary>
        /// Identify all subscribers that are subscribed to at least one magazine in each category.
        /// </summary>
        /// <param name="categories">This is the list of categories that will be used for matching. Subscribers must subscriber to at least one magazine from each of these categories.</param>
        /// <param name="subscribers">This is the list of subscribers, each containing the magazines they are subscribed to</param>
        /// <param name="magazines">This is an in-memory list of all magazines, for all categories</param>
        /// <returns></returns>
        List<Guid?> FilterSubscribers(List<API.Model.ApiSubscriber> subscribers, List<string> categories, List<API.Model.Magazine> magazines);
        /// <summary>
        /// Identify all subscribers that are subscribed to at least one magazine in each category.
        /// </summary>
        /// <param name="categories">This is the list of categories that will be used for matching. Subscribers must subscriber to at least one magazine from each of these categories.</param>
        /// <param name="subscribers">This is the list of subscribers, each containing the magazines they are subscribed to</param>
        /// <param name="magazines">This is an in-memory list of all magazines, for all categories</param>
        /// <returns></returns>
        Task<List<Guid?>> FilterSubscribersAsync(List<API.Model.ApiSubscriber> subscribers, List<string> categories, List<API.Model.Magazine> magazines);
        /// <summary>
        /// Returns a filtered list of in-memory magazines for the given category
        /// </summary>
        /// <param name="magazines">This is an in-memory list of all magazines, for all categories</param>
        /// <param name="category">This is the name of the category from the categories endpoint</param>
        /// <returns></returns>
        IEnumerable<API.Model.Magazine> FilterMagazinesByCategory(List<API.Model.Magazine> magazines, string category);
        
    }
}
