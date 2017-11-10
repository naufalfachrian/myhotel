using System;
using System.Collections.Generic;
using MyHotel.Models;
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
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            viewModel.Fetch();
        }

        public override nint NumberOfSections(UITableView tableView) => 1;

        public override nint RowsInSection(UITableView tableView, nint section) => viewModel.Rooms.Count;

        public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath) => 60;

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("BasicCell", indexPath);
            var room = viewModel.Rooms[indexPath.Row];
            cell.TextLabel.Text = room.Name;
            cell.DetailTextLabel.Text = room.Rate.ToString("#,##0 'IDR / night'");
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
            TableView.TableFooterView = new UIView(CoreGraphics.CGRect.Empty);
            TableView.ReloadData();
        }

        public void RoomListFailedToFetchBecause(string reason)
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
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

