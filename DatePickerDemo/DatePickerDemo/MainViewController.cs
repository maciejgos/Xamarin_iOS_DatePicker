using Foundation;
using System;
using UIKit;

namespace DatePickerDemo
{
    public partial class MainViewController : UITableViewController
    {
        private NSDateFormatter formatter;
        private bool showDatePicker;

        public MainViewController (IntPtr handle) : base (handle)
        {
            formatter = new NSDateFormatter();
            formatter.DateStyle = NSDateFormatterStyle.Short;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            dateLabel.Text = formatter.ToString(datePicker.Date);
            datePicker.ValueChanged += DatePicker_ValueChanged;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            nfloat rowHeight = tableView.RowHeight;

            if(indexPath.Section == 1 && indexPath.Row == 2)
            {
                rowHeight = 0;
            }

            if (showDatePicker && (indexPath.Section == 1 && indexPath.Row ==2))
            {
                rowHeight = 216;
            }

            return rowHeight;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.BeginUpdates();

            if (indexPath.Section == 1 && indexPath.Row == 1)
            {
                showDatePicker = !showDatePicker;
            }

            tableView.DeselectRow(indexPath, true);
            tableView.EndUpdates();
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            dateLabel.Text = formatter.ToString(datePicker.Date);
        }
    }
}