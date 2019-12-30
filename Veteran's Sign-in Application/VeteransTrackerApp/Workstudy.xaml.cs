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

namespace VeteransTrackerApp
{
	public partial class Workstudy : Window
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

		public Workstudy()
		{
			InitializeComponent();
		}

		//Submit to the database a new entry with the following details
		//    Initials: Workstudy
		//    Time: Time from datetime function
		//    Date: Date from datetime function
		//    areaInput: "Email "
		private void Email(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;

            areaInput = "";

            string timeInput = DateTime.Now.ToString("h:mm tt");
			string dateInput = DateTime.Today.ToString("dd/MM/yyyy");
			areaInput += "Email ";
			submittedRecord = new SubmittedRecord { initials = "Workstudy", time = timeInput, date = dateInput, area = areaInput };
			submittedRecord.SubmitRecord();
		}

		//Submit to the database a new entry with the following details
		//    Initials: Workstudy
		//    Time: Time from datetime function
		//    Date: Date from datetime function
		//    areaInput: "Phone "
		private void Phone(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;

            areaInput = "";

            string timeInput = DateTime.Now.ToString("h:mm tt");
			string dateInput = DateTime.Today.ToString("dd/MM/yyyy");
			areaInput += "Phone ";
			submittedRecord = new SubmittedRecord { initials = "Workstudy", time = timeInput, date = dateInput, area = areaInput };
			submittedRecord.SubmitRecord();
		}

		//Easter Egg window which opens a little game hidden from the Certifying Official 
		//    to allow the workstudies to play when not bogged down with work
		private void Game(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;

			Window game = new Game();
			game.Show();
		}
	}
}
