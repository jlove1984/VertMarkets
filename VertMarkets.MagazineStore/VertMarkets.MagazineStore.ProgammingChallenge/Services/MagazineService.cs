

namespace VertMarkets.MagazineStore.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using VertMarkets.MagazineStore.API;
    using VertMarkets.MagazineStore.API.Client;
    using VertMarkets.MagazineStore.API.Model;
    using VertMarkets.MagazineStore.Core.Interfaces;
    /// <summary>
    /// Represents a collection of functions to interact with the Magazine Store API endpoints
    /// </summary>
    public class MagazineService : IMagazineService
    {
        /// <summary>
        /// Utilizes the Magazine API endpoints to identify all subscribers that are subscribed to at least one magazine in each
        /// category.Then submit their id's to the answer endpoint and print the result to the console.
        /// The answer endpoint will return a result object, that will let you know how long it took for you to
        /// get to the answer as well as if it was correct.
        /// </summary>        
        /// <returns></returns>
        public API.Model.ApiResponse<AnswerResponse> Challenge()
        {
            API.Client.Configuration config = new API.Client.Configuration();
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            var tokenResponse = GetToken(config);
            List<API.Model.Magazine> AllMagazines = new List<API.Model.Magazine>();

            if (tokenResponse.Success ?? false)
            {
                Debug.WriteLine(tokenResponse.ToString());
                var categoriesResponse = GetCategories(tokenResponse.Token, config);
                var subscriberResponse = GetSubscribers(tokenResponse.Token, config);

                if (categoriesResponse.Success ?? false)
                {
                    Debug.WriteLine(categoriesResponse.ToString());
                    var categories = categoriesResponse.Data;
                    for (var i = 0; i < categories.Count; i++)
                    {
                        var category = categories[i];
                        var magazinesResponse = GetMagazines(tokenResponse.Token, category, config);
                        if (magazinesResponse.Success ?? false)
                        {
                            Debug.WriteLine(magazinesResponse.ToString());
                            AllMagazines.AddRange(magazinesResponse.Data);
                        }
                    }
                }

                var answer = GetAnswer(categoriesResponse.Data, subscriberResponse.Data, AllMagazines);
                var answerResponse = SubmitAnswer(tokenResponse.Token, answer);
                if (answerResponse.Success ?? false)
                {
                    Debug.WriteLine(answerResponse.ToString());                    
                }
                Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
                return answerResponse;
            }
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return new API.Model.ApiResponse<API.Model.AnswerResponse>(null, tokenResponse.Success, tokenResponse.Token, tokenResponse.Message);
        }

        /// <summary>
        /// Utilizes the Magazine API endpoints to identify all subscribers that are subscribed to at least one magazine in each
        /// category.Then submit their id's to the answer endpoint and print the result to the console.
        /// The answer endpoint will return a result object, that will let you know how long it took for you to
        /// get to the answer as well as if it was correct.
        /// </summary>        
        /// <returns></returns>
        public async Task<API.Model.ApiResponse<AnswerResponse>> ChallengeAsync()
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            API.Client.Configuration config = new API.Client.Configuration();
            var tokenResponse = await GetTokenAsync(config);
            List<API.Model.Magazine> AllMagazines = new List<API.Model.Magazine>();

            if (tokenResponse.Success ?? false)
            {
                Debug.WriteLine(tokenResponse.ToString());
                var categoriesResponse = await GetCategoriesAsync(tokenResponse.Token, config);                

                if (categoriesResponse.Success ?? false)
                {
                    Debug.WriteLine(categoriesResponse.ToString());
                    var categories = categoriesResponse.Data;
                    for (var i = 0; i < categories.Count; i++)
                    {
                        var category = categories[i];
                        var magazinesResponse = await GetMagazinesAsync(tokenResponse.Token, category, config);
                        if (magazinesResponse.Success ?? false)
                        {
                            Debug.WriteLine(magazinesResponse.ToString());
                            AllMagazines.AddRange(magazinesResponse.Data);
                        }
                    }
                }

                var subscriberResponse = await GetSubscribersAsync(tokenResponse.Token, config);

                var answer = GetAnswer(categoriesResponse.Data, subscriberResponse.Data, AllMagazines);
                var answerResponse = await SubmitAnswerAsync(tokenResponse.Token, answer);
                if (answerResponse.Success ?? false)
                {
                    Debug.WriteLine(answerResponse.ToString());                    
                }

                Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
                return answerResponse;
            }
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return new API.Model.ApiResponse<API.Model.AnswerResponse>(null, tokenResponse.Success, tokenResponse.Token, tokenResponse.Message);
        }

        /// <summary>
        /// Returns a filtered list of in-memory magazines for the given category
        /// </summary>
        /// <param name="magazines">This is an in-memory list of all magazines, for all categories</param>
        /// <param name="category">This is the name of the category from the categories endpoint</param>
        /// <returns></returns>
        public IEnumerable<Magazine> FilterMagazinesByCategory(List<Magazine> magazines, string category)
        {
            return magazines?.Where(a => a.Category == category);
        }

        /// <summary>
        /// Identify all subscribers that are subscribed to at least one magazine in each category.
        /// </summary>
        /// <param name="categories">This is the list of categories that will be used for matching. Subscribers must subscriber to at least one magazine from each of these categories.</param>
        /// <param name="subscribers">This is the list of subscribers, each containing the magazines they are subscribed to</param>
        /// <param name="magazines">This is an in-memory list of all magazines, for all categories</param>
        /// <returns></returns>
        public List<Guid?> FilterSubscribers(List<ApiSubscriber> subscribers, List<string> categories, List<Magazine> magazines)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            Dictionary<Guid?, int> SubscribersAgg = new Dictionary<Guid?, int>();
            int totalCategories = categories.Count;
            foreach (var subscriber in subscribers)
            {
                if (!SubscribersAgg.ContainsKey(subscriber.Id))
                    SubscribersAgg.Add(subscriber.Id, 0);

                foreach (var category in categories)
                {
                    var magazinesByCategory = FilterMagazinesByCategory(magazines, category);
                    // If the subscriber has any magazine in the filtered category
                    if (magazinesByCategory.Any(a => subscriber.MagazineIds.Contains(a.Id)))
                    {
                        SubscribersAgg[subscriber.Id]++;
                    }
                    else
                    {
                        //Short-circuit to move to the next subscriber since this subscriber does not subscribe to at least one magazine from each category
                        break;
                    }
                }
            }

            var filteredSubscribers = SubscribersAgg.Where(a => a.Value == totalCategories).Select(a => a.Key).ToList();
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return filteredSubscribers;
        }

        /// <summary>
        /// Identify all subscribers that are subscribed to at least one magazine in each category.
        /// </summary>
        /// <param name="categories">This is the list of categories that will be used for matching. Subscribers must subscriber to at least one magazine from each of these categories.</param>
        /// <param name="subscribers">This is the list of subscribers, each containing the magazines they are subscribed to</param>
        /// <param name="magazines">This is an in-memory list of all magazines, for all categories</param>
        /// <returns></returns>
        public async Task<List<Guid?>> FilterSubscribersAsync(List<ApiSubscriber> subscribers, List<string> categories, List<Magazine> magazines)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            Dictionary<Guid?, int> SubscribersAgg = new Dictionary<Guid?, int>();
            int totalCategories = categories.Count;
            Parallel.ForEach(subscribers, (subscriber) =>
            {
                if (!SubscribersAgg.ContainsKey(subscriber.Id))
                    SubscribersAgg.Add(subscriber.Id, 0);

                foreach (var category in categories)
                {
                    var magazinesByCategory = FilterMagazinesByCategory(magazines, category);
                    // If the subscriber has any magazine in the filtered category
                    if (magazinesByCategory.Any(a => subscriber.MagazineIds.Contains(a.Id)))
                    {
                        SubscribersAgg[subscriber.Id]++;
                    }
                    else
                    {
                        //Short-circuit to move to the next subscriber since this subscriber does not subscribe to at least one magazine from each category
                        break;
                    }
                }
            });

            var filteredSubscribers = SubscribersAgg.Where(a => a.Value == totalCategories).Select(a => a.Key).ToList();
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return filteredSubscribers;
        }

        /// <summary>
        /// Returns a list of subscriber ids that are subscribed to at least one magazine in each category.
        /// </summary>
        /// <param name="categories">This is the list of categories that will be used for matching. Subscribers must subscriber to at least one magazine from each of these categories.</param>
        /// <param name="subscribers">This is the list of subscribers, each containing the magazines they are subscribed to</param>
        /// <param name="magazines">This is the list of all magazines, for all categories</param>
        /// <returns></returns>
        public Answer GetAnswer(List<string> categories, List<ApiSubscriber> subscribers, List<Magazine> magazines)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            List<Guid?> filteredSubscribers = FilterSubscribers(subscribers, categories, magazines);
            API.Model.Answer result = new API.Model.Answer(filteredSubscribers);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }

        /// <summary>
        /// Returns a list of subscriber ids that are subscribed to at least one magazine in each category.
        /// </summary>
        /// <param name="categories">This is the list of categories that will be used for matching. Subscribers must subscriber to at least one magazine from each of these categories.</param>
        /// <param name="subscribers">This is the list of subscribers, each containing the magazines they are subscribed to</param>
        /// <param name="magazines">This is the list of all magazines, for all categories</param>
        /// <returns></returns>
        public async Task<Answer> GetAnswerAsync(List<string> categories, List<ApiSubscriber> subscribers, List<Magazine> magazines)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            List<Guid?> filteredSubscribers = await FilterSubscribersAsync(subscribers, categories, magazines);
            API.Model.Answer result = new API.Model.Answer(filteredSubscribers);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }

        /// <summary>
        /// Returns the current magazine categories
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        public API.Model.ApiResponse<List<string>> GetCategories(string token, Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            ICategoriesApi api = new CategoriesApi(config);
            var result = api.ApiCategoriesByTokenGet(token);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Returns the current magazine categories
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        public async Task<API.Model.ApiResponse<List<string>>> GetCategoriesAsync(string token, Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            ICategoriesApi api = new CategoriesApi(config);
            var result = await api.ApiCategoriesByTokenGetAsync(token);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Return a list of magazines for a given category
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="category">This is the name of the category from the categories endpoint.</param>
        /// <param name="config">An instance of Configuration</param>
        /// <returns></returns>
        public API.Model.ApiResponse<List<Magazine>> GetMagazines(string token, string category, Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            IMagazineApi api = new MagazineApi(config);
            var result = api.ApiMagazinesByTokenByCategoryGet(token, category);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Return a list of magazines for a given category
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="category">This is the name of the category from the categories endpoint.</param>
        /// <param name="config">An instance of Configuration</param>
        /// <returns></returns>
        public async Task<API.Model.ApiResponse<List<Magazine>>> GetMagazinesAsync(string token, string category, Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            IMagazineApi api = new MagazineApi(config);
            var result = await api.ApiMagazinesByTokenByCategoryGetAsync(token, category);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Return our current subscribers along with the magazine ids that they are subscribed to.
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        public API.Model.ApiResponse<List<ApiSubscriber>> GetSubscribers(string token, Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            ISubscriberApi api = new SubscriberApi(config);
            var result =  api.ApiSubscribersByTokenGet(token);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Return our current subscribers along with the magazine ids that they are subscribed to.
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="config">An instance of Configuration.</param>
        /// <returns></returns>
        public async Task<API.Model.ApiResponse<List<ApiSubscriber>>> GetSubscribersAsync(string token, Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            ISubscriberApi api = new SubscriberApi(config);
            var result = await api.ApiSubscribersByTokenGetAsync(token);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Retrievs a token from the token endpoint, which is passed along to any subsequent call. Don't reuse the token across multiple runs of
        /// your program as they expire.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public ApiResponse GetToken(Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            ITokenApi api = new TokenApi(config);
            var result = api.ApiTokenGet();
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Retrievs a token from the token endpoint, which is passed along to any subsequent call. Don't reuse the token across multiple runs of
        /// your program as they expire.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetTokenAsync(Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            ITokenApi api = new TokenApi(config);
            var result = await api.ApiTokenGetAsync();
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Post your answer to this endpoint. It should be a json object that holds a list of subscribers.
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="answer">This is an object with a list of subscriberIds that match the criteria in the exercise</param>
        /// <param name="config">An instance of Configuration</param>
        /// <returns></returns>
        public API.Model.ApiResponse<AnswerResponse> SubmitAnswer(string token, Answer answer, Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            IAnswerApi api = new AnswerApi(config);
            var result = api.ApiAnswerByTokenPost(token, answer);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
        /// <summary>
        /// Post your answer to this endpoint. It should be a json object that holds a list of subscribers.
        /// </summary>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <param name="answer">This is an object with a list of subscriberIds that match the criteria in the exercise</param>
        /// <param name="config">An instance of Configuration</param>
        /// <returns></returns>
        public async Task<API.Model.ApiResponse<AnswerResponse>> SubmitAnswerAsync(string token, Answer answer, Configuration config = null)
        {
            Trace.WriteLine($"Starting {MethodBase.GetCurrentMethod().Name}");
            IAnswerApi api = new AnswerApi(config);
            var result = await api.ApiAnswerByTokenPostAsync(token, answer);
            Trace.WriteLine($"Ending {MethodBase.GetCurrentMethod().Name}");
            return result;
        }
    }
}
