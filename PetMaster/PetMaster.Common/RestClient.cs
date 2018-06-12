using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PetMaster.Common
{
    public class RestClient<T>
    {
        private readonly int _numberOfTimesToRetry;
        private readonly int _millisecondsBetweenRetries;

        private static readonly HttpClient Client = new HttpClient();

        public RestClient(int numberOfTimesToRetry = 5, int millisecondsBetweenRetries = 5000)
        {
            _numberOfTimesToRetry = numberOfTimesToRetry;
            _millisecondsBetweenRetries = millisecondsBetweenRetries;
        }

        public T Get(string uri)
        {
            var numberOfAttempts = 0;
            while (true)
            {
                try
                {
                    var response = HttpGetAsync(uri).Result;
                    if (!response.IsSuccessStatusCode && RetryableError(response.StatusCode))
                    {
                        numberOfAttempts++;
                        if (numberOfAttempts < _numberOfTimesToRetry) continue;

                        RetrySleep(numberOfAttempts);
                    }

                    return ProcessResponse(response);
                }
                catch (AggregateException ex)
                {
                    throw ex.InnerException;
                }
            }
        }

        private async Task<HttpResponseMessage> HttpGetAsync(string requestUri)
        {
            var numberOfAttempts = 0;
            while (true)
            {
                try
                {
                    return await Client.GetAsync(requestUri);
                }
                catch (Exception ex)
                {
                    if (ex is HttpRequestException || ex is TaskCanceledException)
                    {
                        numberOfAttempts++;
                        if (numberOfAttempts >= _numberOfTimesToRetry)
                            throw;

                        RetrySleep(numberOfAttempts);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private bool RetryableError(HttpStatusCode code)
        {
            return code == HttpStatusCode.InternalServerError || code == HttpStatusCode.BadGateway ||
                   code == HttpStatusCode.ServiceUnavailable || code == HttpStatusCode.GatewayTimeout;
        }

        private void RetrySleep(int numberOfAttempts)
        {
            System.Threading.Thread.Sleep(_millisecondsBetweenRetries * numberOfAttempts);
        }

        private static T ProcessResponse(HttpResponseMessage response)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
                throw new ApiResponseException(response.StatusCode, responseContent);

            return JsonConvert.DeserializeObject<T>(responseContent, new StringEnumConverter());
        }
    }
}
