using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MyHotel.Droid
{
    public class ItemViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ImageView { get; private set; }

        public TextView TitleLabel { get; private set; }

        public ItemViewHolder(View itemView) : base(itemView)
        {
            ImageView = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            TitleLabel = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }
}
