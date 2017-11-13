using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyHotel.Models;
using Newtonsoft.Json;

namespace MyHotel.NetworkRequest.Base
{
    public abstract class BaseNetworkRequest<ResponseObjectType>
    {
        static HttpClient httpClient;

        protected BaseNetworkRequest()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://faizal-hotel-xyz.96.lt/api/"),
                    Timeout = TimeSpan.FromSeconds(20),
                };
                httpClient.DefaultRequestHeaders.Add("x-api-key", "DlSOCbO3MAdFbmNZVGSLivgnIY0rpR2I");
            }
        }

        public void Enqueue()
        {
            if (httpClient != null)
            {
                switch (Method())
                {
                    case RequestMethod.POST:
                        var postRequest = PostAsync();
                        break;
                    case RequestMethod.GET:
                        var getRequest = GetAsync();
                        break;
                }
            }
            else
            {
                OnRequestFailure(null, "We don't have an HttpClient instance.");
            }
        }

        public abstract RequestMethod Method();

        public abstract String EndPoint();

        public abstract HttpContent Parameters();

        public abstract void OnRequestSuccess(HttpResponseMessage httpResponse, ResponseObjectType responseObject);

        public abstract void OnRequestFailure(HttpResponseMessage httpResponse, String message);

        async Task PostAsync()
        {
            var httpResponse = await httpClient.PostAsync(EndPoint(), Parameters());
            var processResponse = ProceedResponseAsync(httpResponse);
        }

        async Task GetAsync()
        {
            var httpResponse = await httpClient.GetAsync(EndPoint());
            var processResponse = ProceedResponseAsync(httpResponse);
        }

        async Task ProceedResponseAsync(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                var rawResponse = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<ResponseObjectType>>(rawResponse);
                if (response.Status == 200)
                {
                    OnRequestSuccess(httpResponse, response.Data);
                }
                else 
                {
                    OnRequestFailure(httpResponse, response.Message);
                }
            }
            else
            {
                OnRequestFailure(httpResponse, "Connection failed.");
            }
        }
    }

    public enum RequestMethod
    {
        POST, GET,
    }
}
