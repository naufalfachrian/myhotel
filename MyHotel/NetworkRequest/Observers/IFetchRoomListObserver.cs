using System;
using System.Collections.Generic;
using MyHotel.Models;

namespace MyHotel.NetworkRequest.Observers
{
    public interface IFetchRoomListObserver
    {
        void RoomListFetched(List<RoomModel> rooms);
        void RoomListFailedToFetchBecause(String reason);
    }
}
