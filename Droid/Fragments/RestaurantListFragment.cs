
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using MyHotel.Droid.Adapters;
using MyHotel.ViewModels;

namespace MyHotel.Droid.Fragments
{
    public class RestaurantListFragment : BaseListFragment, IRestaurantListViewModelObserver
    {
        public RestaurantListViewModel ViewModel;

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            ViewModel.FetchIfNeeded();
        }

        public void FetchingRestaurantList()
        {
            refreshLayout.Refreshing = true;
        }

        public void RestaurantListFailedToFetchBecause(string reason)
        {
            refreshLayout.Refreshing = false;
        }

        public void RestaurantListFetched()
        {
            refreshLayout.Refreshing = false;
            recylerView.HasFixedSize = true;
            recylerView.SetLayoutManager(new LinearLayoutManager(Context));
            recylerView.SetAdapter(new RestaurantAdapter(Context, ViewModel.Restaurants));
        }

        protected override void OnRefresh(object sender, EventArgs e)
        {
            ViewModel.Fetch();
        }
    }
}
