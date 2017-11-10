using System;
using System.Collections.Generic;
using MyHotel.Models;
using MyHotel.NetworkRequest;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.ViewModels
{
    public class FacilityListViewModel : IFetchFacilityListObserver
    {
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

        public void Fetch()
        {
            var fetchFacilities = new RestApiClient().FetchFacilityList(this);
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
