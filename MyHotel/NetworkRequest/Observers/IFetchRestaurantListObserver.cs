using System;
using System.Collections.Generic;
using MyHotel.Models;

namespace MyHotel.NetworkRequest.Observers
{
    public interface IFetchRestaurantListObserver
    {
        void RestaurantListFetched(List<RestaurantModel> restaurants);
        void RestaurantListFailedToFetchBecause(String reason);
    }
}
