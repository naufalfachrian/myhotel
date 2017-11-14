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
        }

        public void FacilityListFailedToFetchBecause(string reason)
        {
        }

        public void FacilityListFetched()
        {
            recylerView.HasFixedSize = true;
            recylerView.SetLayoutManager(new LinearLayoutManager(Context));
            recylerView.SetAdapter(new FacilityAdapter(Context, ViewModel.Facilities));
            progressBar.Visibility = ViewStates.Gone;
        }
    }
}
