using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using MyHotel.Models;

namespace MyHotel.Droid.Adapters
{
    public class RoomAdapter : RecyclerView.Adapter
    {
        Context context;
        List<RoomModel> rooms;

        const int ITEM = 230;
        const int BLANK_ITEM = 534;

        public RoomAdapter(Context context, List<RoomModel> rooms)
        {
            this.context = context;
            this.rooms = rooms;
        }

        public override int ItemCount => rooms.Count + 2;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (position >= 1 && position <= rooms.Count)
            {
                var viewHolder = holder as RoomViewHolder;
                var room = rooms[position - 1];
                viewHolder.RoomTitleLabel.Text = room.Name;
                Glide.With(context).Load(room.ImageUrl).Into(viewHolder.RoomImageView);
            }
        }

        public override int GetItemViewType(int position)
        {
            if (position >= 1 && position <= rooms.Count) 
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
                return new RoomViewHolder(view);
            }
            view = LayoutInflater.From(context).Inflate(Resource.Layout.BlankItem, parent, false);
            return new BlankItemViewHolder(view); 
        }
    }

    public class RoomViewHolder : RecyclerView.ViewHolder
    {
        public ImageView RoomImageView { get; private set; }

        public TextView RoomTitleLabel { get; private set; }

        public RoomViewHolder(View itemView) : base(itemView)
        {
            RoomImageView = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            RoomTitleLabel = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }
}