﻿/* 
 * Vertmarkets Inc. Magazine Store
 *
 * API endpoints to work with magazine data
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
namespace VertMarkets.MagazineStore.API
{
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using VertMarkets.MagazineStore.API.Model;
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SubscriberApi : ISubscriberApi
    {
        private VertMarkets.MagazineStore.API.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriberApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SubscriberApi(String basePath)
        {
            this.Configuration = new VertMarkets.MagazineStore.API.Client.Configuration { BasePath = basePath };
            ExceptionFactory = VertMarkets.MagazineStore.API.Client.Configuration.DefaultExceptionFactory;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriberApi"/> class
        /// </summary>
        /// <returns></returns>
        public SubscriberApi()
        {
            this.Configuration = VertMarkets.MagazineStore.API.Client.Configuration.Default;
            ExceptionFactory = VertMarkets.MagazineStore.API.Client.Configuration.DefaultExceptionFactory;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriberApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SubscriberApi(VertMarkets.MagazineStore.API.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = VertMarkets.MagazineStore.API.Client.Configuration.Default;
            else
                this.Configuration = configuration;
            ExceptionFactory = VertMarkets.MagazineStore.API.Client.Configuration.DefaultExceptionFactory;
        }
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public VertMarkets.MagazineStore.API.Client.Configuration Configuration { get; set; }
        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public VertMarkets.MagazineStore.API.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }
        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }
        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }
        /// <summary>
        /// This endpoint will return the current subscribers with the magazine Id&#x27;s to which they are subscribed 
        /// </summary>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>ApiResponse<List<ApiSubscriber>></returns>
        public ApiResponse<List<ApiSubscriber>> ApiSubscribersByTokenGet(string token)
        {
            Client.ApiResponse<ApiResponse<List<ApiSubscriber>>> localVarResponse = ApiSubscribersByTokenGetWithHttpInfo(token);
            return localVarResponse.Data;
        }
        /// <summary>
        /// This endpoint will return the current subscribers with the magazine Id&#x27;s to which they are subscribed 
        /// </summary>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>ApiResponse of ApiResponse<List<ApiSubscriber>></returns>
        public Client.ApiResponse<ApiResponse<List<ApiSubscriber>>> ApiSubscribersByTokenGetWithHttpInfo(string token)
        {
            // verify the required parameter 'token' is set
            if (token == null)
                throw new Client.ApiException(400, "Missing required parameter 'token' when calling SubscriberApi->ApiSubscribersByTokenGet");
            var localVarPath = "/api/subscribers/{token}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;
            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);
            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);
            if (token != null) localVarPathParams.Add("token", this.Configuration.ApiClient.ParameterToString(token)); // path parameter
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);
            int localVarStatusCode = (int)localVarResponse.StatusCode;
            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ApiSubscribersByTokenGet", localVarResponse);
                if (exception != null) throw exception;
            }
            return new Client.ApiResponse<ApiResponse<List<ApiSubscriber>>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ApiResponse<List<ApiSubscriber>>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ApiResponse<List<ApiSubscriber>>)));
        }
        /// <summary>
        /// This endpoint will return the current subscribers with the magazine Id&#x27;s to which they are subscribed 
        /// </summary>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>Task of ApiResponse<List<ApiSubscriber>></returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<ApiSubscriber>>> ApiSubscribersByTokenGetAsync(string token)
        {
            Client.ApiResponse<ApiResponse<List<ApiSubscriber>>> localVarResponse = await ApiSubscribersByTokenGetAsyncWithHttpInfo(token);
            return localVarResponse.Data;
        }
        /// <summary>
        /// This endpoint will return the current subscribers with the magazine Id&#x27;s to which they are subscribed 
        /// </summary>
        /// <exception cref="VertMarkets.MagazineStore.API.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token">This is a string token received from the token endpoint</param>
        /// <returns>Task of ApiResponse (ApiResponse<List<ApiSubscriber>>)</returns>
        public async System.Threading.Tasks.Task<Client.ApiResponse<ApiResponse<List<ApiSubscriber>>>> ApiSubscribersByTokenGetAsyncWithHttpInfo(string token)
        {
            // verify the required parameter 'token' is set
            if (token == null)
                throw new Client.ApiException(400, "Missing required parameter 'token' when calling SubscriberApi->ApiSubscribersByTokenGet");
            var localVarPath = "/api/subscribers/{token}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;
            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);
            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);
            if (token != null) localVarPathParams.Add("token", this.Configuration.ApiClient.ParameterToString(token)); // path parameter
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);
            int localVarStatusCode = (int)localVarResponse.StatusCode;
            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ApiSubscribersByTokenGet", localVarResponse);
                if (exception != null) throw exception;
            }
            return new Client.ApiResponse<ApiResponse<List<ApiSubscriber>>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ApiResponse<List<ApiSubscriber>>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ApiResponse<List<ApiSubscriber>>)));
        }
    }
}