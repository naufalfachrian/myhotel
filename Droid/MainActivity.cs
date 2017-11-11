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
                        break;
                    case Resource.Id.actionFacility:
                        break;
                }
            };
        }

        void DisplayRoomListFragment()
        {
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment, new RoomListFragment()).Commit();
        }
    }
}

