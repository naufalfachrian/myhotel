
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
    public class RoomListFragment : Fragment, IRoomListViewModelObserver
    {
        RoomListViewModel viewModel = new RoomListViewModel();

        RecyclerView recylerView;

        ProgressBar progressBar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.ListFragment, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            recylerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBar);

            viewModel.Observer = this;
            viewModel.Fetch();
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
            recylerView.SetAdapter(new RoomAdapter(Context, viewModel.Rooms));
            progressBar.Visibility = ViewStates.Gone;
        }
    }
}
