using System;
using System.Collections.Generic;
using MyHotel.Models;
using MyHotel.NetworkRequest;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.ViewModels
{
    public class FacilityListViewModel : IFetchFacilityListObserver
    {
        FetchFacilityListNetworkRequest networkRequest;

        public IFacilityListViewModelObserver Observer;

        List<FacilityModel> facilities = new List<FacilityModel>();
        public List<FacilityModel> Facilities
        {
            get
            {
                return facilities;
            }
            private set
            {
                facilities = value;
            }
        }

        public FacilityListViewModel()
        {
            networkRequest = new FetchFacilityListNetworkRequest(this);
        }

        public void FetchIfNeeded()
        {
            if (facilities.Count == 0) 
            {
                Fetch();
            }
            else
            {
                Observer.FacilityListFetched();
            }
        }

        public void Fetch()
        {
            networkRequest.Enqueue();
            Observer.FetchingFacilityList();
        }

        public void FacilityListFailedToFetchBecause(string reason)
        {
            Observer.FacilityListFailedToFetchBecause(reason);
        }

        public void FacilityListFetched(List<FacilityModel> facilities)
        {
            this.facilities = facilities;
            Observer.FacilityListFetched();
        }
    }

    public interface IFacilityListViewModelObserver
    {
        void FetchingFacilityList();
        void FacilityListFetched();
        void FacilityListFailedToFetchBecause(String reason);
    }
}
