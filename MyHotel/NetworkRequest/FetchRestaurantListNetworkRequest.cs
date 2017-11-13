using System;
using System.Collections.Generic;
using System.Net.Http;
using MyHotel.Models;
using MyHotel.NetworkRequest.Base;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.NetworkRequest
{
    public class FetchRestaurantListNetworkRequest : BaseNetworkRequest<List<RestaurantModel>>
    {
        IFetchRestaurantListObserver observer;

        public FetchRestaurantListNetworkRequest(IFetchRestaurantListObserver observer)
        {
            this.observer = observer;
        }

        public override string EndPoint()
        {
            return "restaurant";
        }

        public override RequestMethod Method()
        {
            return RequestMethod.GET;
        }

        public override void OnRequestFailure(HttpResponseMessage httpResponse, string message)
        {
            observer.RestaurantListFailedToFetchBecause(message);
        }

        public override void OnRequestSuccess(HttpResponseMessage httpResponse, List<RestaurantModel> responseObject)
        {
            observer.RestaurantListFetched(responseObject);
        }

        public override HttpContent Parameters()
        {
            return null;
        }
    }
}
