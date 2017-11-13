using System;
using System.Collections.Generic;
using System.Net.Http;
using MyHotel.Models;
using MyHotel.NetworkRequest.Base;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.NetworkRequest
{
    public class FetchRoomListNetworkRequest : BaseNetworkRequest<List<RoomModel>>
    {
        IFetchRoomListObserver observer;

        public FetchRoomListNetworkRequest(IFetchRoomListObserver observer) : base()
        {
            this.observer = observer;
        }

        public override string EndPoint()
        {
            return "room";
        }

        public override RequestMethod Method()
        {
            return RequestMethod.GET;
        }

        public override void OnRequestFailure(HttpResponseMessage httpResponse, string message)
        {
            observer.RoomListFailedToFetchBecause(message);
        }

        public override void OnRequestSuccess(HttpResponseMessage httpResponse, List<RoomModel> responseObject)
        {
            observer.RoomListFetched(responseObject);
        }

        public override HttpContent Parameters()
        {
            return null;
        }
    }
}
