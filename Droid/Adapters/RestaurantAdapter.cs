using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using MyHotel.Models;
using Square.Picasso;

namespace MyHotel.Droid.Adapters
{
    public class RestaurantAdapter : RecyclerView.Adapter
    {
        Context context;
        List<RestaurantModel> restaurants;

        const int RESTAURANT_VIEW_MODEL = 890;
        const int BLANK_ITEM = 290;

        public RestaurantAdapter(Context context, List<RestaurantModel> restaurant)
        {
            this.context = context;
            this.restaurants = restaurant;
        }

        public override int ItemCount => restaurants.Count + 2;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (position >= 1 && position <= restaurants.Count)
            {
                var viewHolder = holder as ItemViewHolder;
                var restaurant = restaurants[position - 1];
                viewHolder.TitleLabel.Text = restaurant.Name;
                Picasso.With(context).Load(restaurant.ImageUrl).Into(viewHolder.ImageView);
            }
        }

        public override int GetItemViewType(int position)
        {
            if (position >= 1 && position <= restaurants.Count)
            {
                return RESTAURANT_VIEW_MODEL;
            }
            return BLANK_ITEM;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view;
            if (viewType == RESTAURANT_VIEW_MODEL)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.Item, parent, false);
                return new ItemViewHolder(view);
            }
            view = LayoutInflater.From(context).Inflate(Resource.Layout.BlankItem, parent, false);
            return new BlankItemViewHolder(view);
        }
    }
}
