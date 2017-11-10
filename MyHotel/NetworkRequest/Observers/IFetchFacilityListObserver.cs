using System;
using System.Collections.Generic;
using MyHotel.Models;

namespace MyHotel.NetworkRequest.Observers
{
    public interface IFetchFacilityListObserver
    {
        void FacilityListFetched(List<FacilityModel> facilities);
        void FacilityListFailedToFetchBecause(String reason);
    }
}
