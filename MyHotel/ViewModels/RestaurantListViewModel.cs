using System;
using System.Collections.Generic;
using MyHotel.Models;
using MyHotel.NetworkRequest;
using MyHotel.NetworkRequest.Observers;

namespace MyHotel.ViewModels
{
    public class RestaurantListViewModel : IFetchRestaurantListObserver
    {
        FetchRestaurantListNetworkRequest networkRequest;

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

        public RestaurantListViewModel()
        {
            networkRequest = new FetchRestaurantListNetworkRequest(this);
        }

        public void FetchIfNeeded()
        {
            if (restaurants.Count == 0)
            {
                Fetch();
            }
        }

        public void Fetch()
        {
            networkRequest.Enqueue();
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
