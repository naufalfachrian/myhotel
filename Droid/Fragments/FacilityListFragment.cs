using System;
using Android.Support.V7.Widget;
using Android.Views;
using MyHotel.Droid.Adapters;
using MyHotel.ViewModels;

namespace MyHotel.Droid.Fragments
{
    public class FacilityListFragment : BaseListFragment, IFacilityListViewModelObserver
    {
        public FacilityListViewModel ViewModel;

        public override void OnViewCreated(Android.Views.View view, Android.OS.Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
           
            ViewModel.FetchIfNeeded();
        }

        public void FetchingFacilityList()
        {
            refreshLayout.Refreshing = true;
        }

        public void FacilityListFailedToFetchBecause(string reason)
        {
            refreshLayout.Refreshing = false;
        }

        public void FacilityListFetched()
        {
            refreshLayout.Refreshing = false;
            recylerView.HasFixedSize = true;
            recylerView.SetLayoutManager(new LinearLayoutManager(Context));
            recylerView.SetAdapter(new FacilityAdapter(Context, ViewModel.Facilities));
        }

        protected override void OnRefresh(object sender, EventArgs e)
        {
            ViewModel.Fetch();
        }
    }
}
