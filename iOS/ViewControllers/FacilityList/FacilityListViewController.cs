using System;
using System.Text.RegularExpressions;
using MyHotel.iOS.ViewCells.FeedItem;
using MyHotel.Models;
using MyHotel.ViewModels;
using UIKit;

namespace MyHotel.iOS.ViewControllers.FacilityList
{
    public partial class FacilityListViewController : UITableViewController, IFacilityListViewModelObserver
    {
        FacilityListViewModel viewModel = new FacilityListViewModel();

        public FacilityListViewController() : base("FacilityListViewController", null)
        {
        }

        public FacilityListViewController(IntPtr handle) : base(handle)
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
            viewModel.FetchIfNeeded();
        }

        public override nint NumberOfSections(UITableView tableView) => 1;

        public override nint RowsInSection(UITableView tableView, nint section) => viewModel.Facilities.Count;

        public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath) => 188;

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            FeedItemViewCell cell = (FeedItemViewCell)tableView.DequeueReusableCell("FacilityItemViewCell", indexPath);
            var facility = viewModel.Facilities[indexPath.Row];
            cell.ShowFacility(facility);
            return cell;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            var facility = viewModel.Facilities[indexPath.Row];
            ShowAlertFacilityDetail(facility);
        }

        private void ShowAlertFacilityDetail(FacilityModel facility)
        {
            var facilityDescription = Regex.Replace(facility.Description, "<.*?>", String.Empty);
            var alert = UIAlertController.Create(title: facility.Name, message: facilityDescription, preferredStyle: UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        public void FetchingFacilityList()
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
        }

        public void FacilityListFetched()
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
            TableView.TableFooterView = BlankFooter;
            TableView.ReloadData();
        }

        public void FacilityListFailedToFetchBecause(string reason)
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
            var alert = UIAlertController.Create(title: "", message: reason, preferredStyle: UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }
    }
}