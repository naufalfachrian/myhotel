using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyHotel.Models;
using MyHotel.NetworkRequest.Observers;
using Newtonsoft.Json;

namespace MyHotel.NetworkRequest
{
    public class RestApiClient
    {
        static HttpClient httpClient;

        public RestApiClient()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://faizal-hotel-xyz.96.lt/api/"),
                    MaxResponseContentBufferSize = 256000,
                };
                httpClient.DefaultRequestHeaders.Add("x-api-key", "DlSOCbO3MAdFbmNZVGSLivgnIY0rpR2I");
            }
        }

        public async Task FetchRoomList(IFetchRoomListObserver observer)
        {
            var httpResponse = await httpClient.GetAsync("room");
            if (httpResponse.IsSuccessStatusCode)
            {
                var rawResponse = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<List<RoomModel>>>(rawResponse);
                if (response.Status == 200)
                {
                    observer.RoomListFetched(response.Data);
                }
                else
                {
                    observer.RoomListFailedToFetchBecause(response.Message);
                }
            }
            else
            {
                observer.RoomListFailedToFetchBecause("Internal Server Error.");
            }
        }

        public async Task FetchRestaurantList(IFetchRestaurantListObserver observer)
        {
            var httpResponse = await httpClient.GetAsync("restaurant");
            if (httpResponse.IsSuccessStatusCode)
            {
                var rawResponse = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<List<RestaurantModel>>>(rawResponse);
                if (response.Status == 200)
                {
                    observer.RestaurantListFetched(response.Data);
                }
                else
                {
                    observer.RestaurantListFailedToFetchBecause(response.Message);
                }
            }
            else
            {
                observer.RestaurantListFailedToFetchBecause("Internal Server Error.");
            }
        }

        public async Task FetchFacilityList(IFetchFacilityListObserver observer)
        {
            var httpResponse = await httpClient.GetAsync("facility");
            if (httpResponse.IsSuccessStatusCode)
            {
                var rawResponse = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<List<FacilityModel>>>(rawResponse);
                if (response.Status == 200)
                {
                    observer.FacilityListFetched(response.Data);
                }
                else
                {
                    observer.FacilityListFailedToFetchBecause(response.Message);
                }
            }
            else
            {
                observer.FacilityListFailedToFetchBecause("Internal Server Error.");
            }
        }
    }
}
