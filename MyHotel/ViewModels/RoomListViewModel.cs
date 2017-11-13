using System;
using System.Collections.Generic;
using MyHotel.Models;
using MyHotel.NetworkRequest;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.ViewModels
{
    public class RoomListViewModel : IFetchRoomListObserver
    {
        FetchRoomListNetworkRequest networkRequest;

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

        public RoomListViewModel()
        {
            networkRequest = new FetchRoomListNetworkRequest(this);
        }

        public void FetchIfNeeded()
        {
            if (rooms.Count == 0)
            {
                Fetch();
            }
        }

        public void Fetch()
        {
            networkRequest.Enqueue();
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
