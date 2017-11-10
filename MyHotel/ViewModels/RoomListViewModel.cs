using System;
using System.Collections.Generic;
using MyHotel.Models;
using MyHotel.NetworkRequest;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.ViewModels
{
    public class RoomListViewModel : IFetchRoomListObserver
    {
        public IRoomListViewModelObserver Observer;

        List<RoomModel> rooms = new List<RoomModel>();
        public List<RoomModel> Rooms
        {
            get
            {
                return rooms;
            }
            private set
            {
                rooms = value;
            }
        }

        public void Fetch()
        {
            var fetchRequest = new RestApiClient().FetchRoomList(this);
            Observer.FetchingRoomList();
        }

        public void RoomListFetched(List<RoomModel> rooms)
        {
            this.rooms = rooms;
            Observer.RoomListFetched();
        }

        public void RoomListFailedToFetchBecause(string reason)
        {
            Observer.RoomListFailedToFetchBecause(reason);
        }
    }

    public interface IRoomListViewModelObserver
    {
        void FetchingRoomList();
        void RoomListFetched();
        void RoomListFailedToFetchBecause(String reason);
    }
}
