// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MyHotel.iOS.ViewCells.FeedItem
{
	[Register ("FeedItemViewCell")]
	partial class FeedItemViewCell
	{
		[Outlet]
		UIKit.UIImageView FeedImageView { get; set; }

		[Outlet]
		UIKit.UILabel FeedSubtitleLabel { get; set; }

		[Outlet]
		UIKit.UILabel FeedTitleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FeedImageView != null) {
				FeedImageView.Dispose ();
				FeedImageView = null;
			}

			if (FeedTitleLabel != null) {
				FeedTitleLabel.Dispose ();
				FeedTitleLabel = null;
			}

			if (FeedSubtitleLabel != null) {
				FeedSubtitleLabel.Dispose ();
				FeedSubtitleLabel = null;
			}
		}
	}
}
