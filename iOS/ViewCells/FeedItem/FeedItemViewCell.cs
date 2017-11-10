using System;

using Foundation;
using MyHotel.Models;
using SDWebImage;
using UIKit;

namespace MyHotel.iOS.ViewCells.FeedItem
{
    public partial class FeedItemViewCell : UITableViewCell
    {
        protected FeedItemViewCell(IntPtr handle) : base(handle)
        {
        }

        public void ShowRoom(RoomModel room)
        {
            FeedImageView.SetImage(new NSUrl(room.ImageUrl));
            FeedTitleLabel.Text = room.Name;
            FeedSubtitleLabel.Text = room.Rate.ToString("'start from '#,##0 'IDR / night'");
        }

        public void ShowRestaurant(RestaurantModel restaurant)
        {
            FeedImageView.SetImage(new NSUrl(restaurant.ImageUrl));
            FeedTitleLabel.Text = restaurant.Name;
        }

        public void ShowFacility(FacilityModel facility)
        {
            FeedImageView.SetImage(new NSUrl(facility.ImageUrl));
            FeedTitleLabel.Text = facility.Name;
        }
    }
}
