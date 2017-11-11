using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MyHotel.Droid.Fragments
{
    public class BaseListFragment : Fragment
    {
        protected RecyclerView recylerView;

        protected ProgressBar progressBar;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.ListFragment, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            recylerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBar);
        }
    }
}
