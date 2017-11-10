using System;
using System.Collections.Generic;
using MyHotel.Models;
using MyHotel.NetworkRequest;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.ViewModels
{
    public class RestaurantListViewModel : IFetchRestaurantListObserver
    {
        public IRestaurantListViewModelObserver Observer;

        List<RestaurantModel> restaurants = new List<RestaurantModel>();
        public List<RestaurantModel> Restaurants
        {
            get
            {
                return restaurants;
            }
            private set
            {
                restaurants = value;
            }
        }

        public void Fetch()
        {
            var fetchRequest = new RestApiClient().FetchRestaurantList(this);
            Observer.FetchingRestaurantList();
        }

        public void RestaurantListFailedToFetchBecause(string reason)
        {
            Observer.RestaurantListFailedToFetchBecause(reason);
        }

        public void RestaurantListFetched(List<RestaurantModel> restaurants)
        {
            this.restaurants = restaurants;
            Observer.RestaurantListFetched();
        }
    }

    public interface IRestaurantListViewModelObserver
    {
        void FetchingRestaurantList();
        void RestaurantListFetched();
        void RestaurantListFailedToFetchBecause(String reason);
    }
}
