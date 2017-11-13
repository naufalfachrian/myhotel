using System;
using System.Collections.Generic;
using System.Net.Http;
using MyHotel.Models;
using MyHotel.NetworkRequest.Base;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.NetworkRequest
{
    public class FetchFacilityListNetworkRequest : BaseNetworkRequest<List<FacilityModel>>
    {
        IFetchFacilityListObserver observer;

        public FetchFacilityListNetworkRequest(IFetchFacilityListObserver observer)
        {
            this.observer = observer;
        }

        public override string EndPoint()
        {
            return "facility";
        }

        public override RequestMethod Method()
        {
            return RequestMethod.GET;
        }

        public override void OnRequestFailure(HttpResponseMessage httpResponse, string message)
        {
            observer.FacilityListFailedToFetchBecause(message);
        }

        public override void OnRequestSuccess(HttpResponseMessage httpResponse, List<FacilityModel> responseObject)
        {
            observer.FacilityListFetched(responseObject);
        }

        public override HttpContent Parameters()
        {
            return null;
        }
    }
}
