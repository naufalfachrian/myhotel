using System;
using System.Collections.Generic;
using MyHotel.iOS.ViewCells.FeedItem;
using MyHotel.Models;
using MyHotel.NetworkRequest;
using MyHotel.ViewModels;
using UIKit;

namespace MyHotel.iOS.ViewControllers.RoomList
{
    public partial class RoomListViewController : UITableViewController, IRoomListViewModelObserver
    {
        RoomListViewModel viewModel = new RoomListViewModel();

        public RoomListViewController() : base("RoomListViewController", null)
        {
        }

        public RoomListViewController(IntPtr handle) : base(handle) 
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

        public override nint RowsInSection(UITableView tableView, nint section) => viewModel.Rooms.Count;

        public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath) => 188;

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            FeedItemViewCell cell = (FeedItemViewCell) tableView.DequeueReusableCell("RoomItemViewCell", indexPath);
            var room = viewModel.Rooms[indexPath.Row];
            cell.ShowRoom(room);
            return cell;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            RoomModel room = viewModel.Rooms[indexPath.Row];
            ShowAlertRoomDetail(room);
        }

        public void RoomListFetched()
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
            RefreshControl.EndRefreshing();
            TableView.TableFooterView = BlankFooter;
            TableView.ReloadData();
        }

        public void RoomListFailedToFetchBecause(string reason)
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
            RefreshControl.EndRefreshing();
            var alert = UIAlertController.Create(title: "", message: reason, preferredStyle: UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        public void FetchingRoomList()
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
        }

        private void ShowAlertRoomDetail(RoomModel room)
        {
            var alert = UIAlertController.Create(title: room.Name, message: room.Description, preferredStyle: UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }
    }
}

