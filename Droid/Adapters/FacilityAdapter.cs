using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Bumptech.Glide;
using MyHotel.Models;

namespace MyHotel.Droid.Adapters
{
    public class FacilityAdapter : RecyclerView.Adapter
    {
        Context context;
        List<FacilityModel> facilities;

        const int ITEM = 801;
        const int BLANK_ITEM = 230;

        public FacilityAdapter(Context context, List<FacilityModel> facilities)
        {
            this.context = context;
            this.facilities = facilities;
        }

        public override int ItemCount => facilities.Count + 2;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (position >= 1 && position <= facilities.Count)
            {
                var viewHolder = holder as ItemViewHolder;
                var facility = facilities[position - 1];
                viewHolder.TitleLabel.Text = facility.Name;
                Glide.With(context).Load(facility.ImageUrl).Into(viewHolder.ImageView);
            }
        }

        public override int GetItemViewType(int position)
        {
            if (position >= 1 && position <= facilities.Count)
            {
                return ITEM;
            }
            return BLANK_ITEM;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view;
            if (viewType == ITEM)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.Item, parent, false);
                return new ItemViewHolder(view);
            }
            view = LayoutInflater.From(context).Inflate(Resource.Layout.BlankItem, parent, false);
            return new BlankItemViewHolder(view);
        }
    }
}
