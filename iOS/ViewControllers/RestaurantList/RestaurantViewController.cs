using System;
using System.Text.RegularExpressions;
using MyHotel.iOS.ViewCells.FeedItem;
using MyHotel.Models;
using MyHotel.ViewModels;
using UIKit;

namespace MyHotel.iOS.ViewControllers.RestaurantList
{
    public partial class RestaurantViewController : UITableViewController, IRestaurantListViewModelObserver
    {
        RestaurantListViewModel viewModel = new RestaurantListViewModel();

        public RestaurantViewController() : base("RestaurantViewController", null)
        {
        }

        public RestaurantViewController(IntPtr handle) : base(handle) 
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            viewModel.Observer = this;
            RefreshControl.ValueChanged += RefreshControlPulled;
        }

        private void RefreshControlPulled(object sender, EventArgs e)
        {
            viewModel.Fetch();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            viewModel.FetchIfNeeded();
            RefreshControl.EndRefreshing();
        }

        public override nint NumberOfSections(UITableView tableView) => 1;

        public override nint RowsInSection(UITableView tableView, nint section) => viewModel.Restaurants.Count;

        public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath) => 188;

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            FeedItemViewCell cell = (FeedItemViewCell)tableView.DequeueReusableCell("RestaurantItemViewCell", indexPath);
            var restaurant = viewModel.Restaurants[indexPath.Row];
            cell.ShowRestaurant(restaurant);
            return cell;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            var restaurant = viewModel.Restaurants[indexPath.Row];
            ShowAlertRestaurantDetail(restaurant);
        }

        public void FetchingRestaurantList()
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
        }

        public void RestaurantListFetched()
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
            RefreshControl.EndRefreshing();
            TableView.TableFooterView = BlankFooter;
            TableView.ReloadData();
        }

        public void RestaurantListFailedToFetchBecause(string reason)
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
            RefreshControl.EndRefreshing();
            var alert = UIAlertController.Create(title: "", message: reason, preferredStyle: UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        private void ShowAlertRestaurantDetail(RestaurantModel restaurant)
        {
            var restaurantDescription = Regex.Replace(restaurant.Description, "<.*?>", String.Empty);
            var alert = UIAlertController.Create(title: restaurant.Name, message: restaurantDescription, preferredStyle: UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }
    }
}

