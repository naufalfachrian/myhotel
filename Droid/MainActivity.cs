using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using MyHotel.Droid.Fragments;

namespace MyHotel.Droid
{
    [Activity(Label = "MyHotel", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        RoomListFragment roomListFragment = new RoomListFragment();
        RestaurantListFragment restaurantListFragment = new RestaurantListFragment();
        FacilityListFragment facilityListFragment = new FacilityListFragment();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            DisplayRoomListFragment();

            var navigation = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigation);
            navigation.NavigationItemSelected += (sender, e) => {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.actionRoom:
                        DisplayRoomListFragment();
                        break;
                    case Resource.Id.actionRestaurant:
                        DisplayRestaurantFragment();
                        break;
                    case Resource.Id.actionFacility:
                        DisplayFacilityFragment();
                        break;
                }
            };
        }

        void DisplayRoomListFragment()
        {
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment, roomListFragment).Commit();
        }

        void DisplayRestaurantFragment()
        {
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment, restaurantListFragment).Commit();
        }

        void DisplayFacilityFragment()
        {
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment, facilityListFragment).Commit();
        }
    }
}

