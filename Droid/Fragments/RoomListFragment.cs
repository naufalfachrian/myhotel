
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MyHotel.ViewModels;
using Android.Support.V7.Widget;
using MyHotel.Droid.Adapters;

namespace MyHotel.Droid.Fragments
{
    public class RoomListFragment : BaseListFragment, IRoomListViewModelObserver
    {
        public RoomListViewModel ViewModel;

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            ViewModel.FetchIfNeeded();
        }

        public void FetchingRoomList()
        {
        }

        public void RoomListFailedToFetchBecause(string reason)
        {
        }

        public void RoomListFetched()
        {
            recylerView.HasFixedSize = true;
            recylerView.SetLayoutManager(new LinearLayoutManager(Context));
            recylerView.SetAdapter(new RoomAdapter(Context, ViewModel.Rooms));
            progressBar.Visibility = ViewStates.Gone;
        }
    }
}
