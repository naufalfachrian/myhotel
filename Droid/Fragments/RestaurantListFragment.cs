
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
        RestaurantListViewModel viewModel = new RestaurantListViewModel();

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            viewModel.Observer = this;
            viewModel.Fetch();
        }

        public void FetchingRestaurantList()
        {
        }

        public void RestaurantListFailedToFetchBecause(string reason)
        {
        }

        public void RestaurantListFetched()
        {
            recylerView.HasFixedSize = true;
            recylerView.SetLayoutManager(new LinearLayoutManager(Context));
            recylerView.SetAdapter(new RestaurantAdapter(Context, viewModel.Restaurants));
            progressBar.Visibility = ViewStates.Gone;
        }
    }
}
