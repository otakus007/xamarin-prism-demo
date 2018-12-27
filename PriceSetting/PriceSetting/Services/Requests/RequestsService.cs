using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PriceSetting.Services
{
    public class RequestsService : IRequestsService
    {
        #region Properties

        private static HttpClient _instance;
        private static HttpClient HttpClientInstance => _instance ?? (_instance = new HttpClient());

        #endregion

        #region HTTP methods

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            SetupHttpClient();

            HttpResponseMessage response = await HttpClientInstance.GetAsync(uri)
                                                                   .ConfigureAwait(false); ;

            await HandleResponse(response);

            string serialized = await response.Content.ReadAsStringAsync();
            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized))
                                       .ConfigureAwait(false);

            return result;
        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data)
        {
            return PostAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
        {
            SetupHttpClient();

            string serialized = await Task.Run(() => JsonConvert.SerializeObject(data))
                                          .ConfigureAwait(false);

            HttpResponseMessage response = await HttpClientInstance.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"))
                                                                   .ConfigureAwait(false);

            await HandleResponse(response);

            string responseData = await response.Content.ReadAsStringAsync()
                                                .ConfigureAwait(false);

            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData));
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data)
        {
            return PutAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
        {
            SetupHttpClient();

            string serialized = await Task.Run(() => JsonConvert.SerializeObject(data))
                                          .ConfigureAwait(false);

            HttpResponseMessage response = await HttpClientInstance.PutAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"))
                                                                   .ConfigureAwait(false);

            await HandleResponse(response);

            string responseData = await response.Content.ReadAsStringAsync()
                                                .ConfigureAwait(false);

            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData));
        }

        #endregion

        #region Setup HTTP Methods

        private void SetupHttpClient()
        {
            HttpClientInstance.DefaultRequestHeaders.Accept.Clear();
            HttpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync()
                                            .ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(content);
                }

                throw new HttpRequestException(content);
            }
        }

        #endregion
    }
}
