/*
 * Timothy Davis + Steven Richter
 * UW Oshkosh
 * CS 341
 * Veterans Department App
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace VeteransTrackerApp
{

	public partial class DownloadData : Window
	{
		public string connectionString = "Server=localhost;port=3306;user=team5;password=x287;database=team5";
		public string initialsInput = "";
		public string areaInput = "";
		public bool lab = false;
		public bool frontDesk = false;
		public bool lounge = false;
		public bool email = false;
		public bool phone = false;
		public SubmittedRecord submittedRecord;
		public RetrievedRecord retrievedRecord;
        public string startMonthInput;
        public string endMonthInput;
        public string startYearInput;
        public string endYearInput;
        public string startDateInput;
        public string endDateInput;
		public DateTime startDate;
		public DateTime endDate;

		public DownloadData()
		{
			InitializeComponent();
		}

		private void Check(object sender, RoutedEventArgs e)
		{
			CheckBox check = (CheckBox)sender;

			if ((string)check.Content == "Lab")
			{
				lab = true;
				if (areaInput.Length == 0)
					areaInput += "Lab ";
				else
					areaInput += ": Lab ";

			}

			if ((string)check.Content == "Desk")
			{
				frontDesk = true;
				if (areaInput.Length == 0)
					areaInput += "FrontDesk ";
				else
					areaInput += ": FrontDesk ";
			}

			if ((string)check.Content == "Lounge")
			{
				lounge = true;
				if (areaInput.Length == 0)
					areaInput += "Lounge ";
				else
					areaInput += ": Lounge ";
			}

			if ((string)check.Content == "Email")
			{
				email = true;
				if (areaInput.Length == 0)
					areaInput += "Email ";
				else
					areaInput += ": Email ";
			}

			if ((string)check.Content == "Phone")
			{
				phone = true;
				if (areaInput.Length == 0)
					areaInput += "Phone ";
				else
					areaInput += ": Phone ";
			}
		}

		private void Dates()
		{
			startDate = new DateTime();

			startDate = Convert.ToDateTime(startMonthInput + "/" + "01/" + startYearInput);

			startDateInput = startDate.Month + "/" + startDate.Day + "/" + startDate.Year;
		}

		private void Gather(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;

			Dates();

			retrievedRecord = new RetrievedRecord { };
			if (initialsInput.Length < 1)
				initialsInput = "Test";

			retrievedRecord.viewer(startDateInput, this.areaInput);
		}

        private void StartMonth_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox startMonthTextbox = (TextBox)sender;
            startMonthInput = startMonthTextbox.Text;
        }

        private void StartYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox startYearTextbox = (TextBox)sender;
            startYearInput = startYearTextbox.Text;
        }

        // This method resets the data to download. The checkboxes clear and the user reselects data to download.
        private void Reset(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            areaInput = "";

            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Object i in GridDownloadData.Children)
            {
                if (i.GetType().ToString() == "System.Windows.Controls.CheckBox")
                {
                    checkBoxes.Add((CheckBox)i);
                }
            }

            foreach (CheckBox checkBox in checkBoxes)
            {
                checkBox.IsChecked = false;
            }

        }


        // This method is called when the user unchecks a checkbox in the DownloadData (Certifying Official) window.
        // The checkbox gets unchecked and then the method iterates through all checkboxes to see which ones are 
        // Still checked, and recreates areaInput based on that.
        public void DownloadClear(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            areaInput = "";

            // Get all checkboxes, see which are checked. Make areaInput based on that
            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Object i in GridDownloadData.Children)
            {
                if (i.GetType().ToString() == "System.Windows.Controls.CheckBox")
                    checkBoxes.Add((CheckBox)i);
            }

            foreach (CheckBox i in checkBoxes)
            {
                if ((string)i.Content == "Lab" && i.IsChecked == true)
                {
                    areaInput = "Lab ";
                }

                if ((string)i.Content == "Front Desk" && i.IsChecked == true)
                {
                    if (areaInput.Length == 0)
                        areaInput = "FrontDesk ";
                    else
                        areaInput += ": FrontDesk ";
                }

                if ((string)i.Content == "Lounge" && i.IsChecked == true)
                {
                    if (areaInput.Length == 0)
                        areaInput = "Lounge ";
                    else
                        areaInput += ": Lounge ";
                }

                if ((string)i.Content == "Email" && i.IsChecked == true)
                {
                    if (areaInput.Length == 0)
                        areaInput = "Email ";
                    else
                        areaInput += ": Email ";
                }

                if ((string)i.Content == "Phone" && i.IsChecked == true)
                {
                    if (areaInput.Length == 0)
                        areaInput = "Phone ";
                    else
                        areaInput += ": Phone ";
                }
            }
        }
    }
}
