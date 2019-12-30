
/*
 * Steven Richter
 * UW Oshkosh
 * CS 341
 * Veteran's Department App
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

// ZFR
namespace VeteransTrackerApp
{
    public partial class SignIn : Window
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

        public SignIn()
        {
            InitializeComponent();
        }

        // Area checkboxes
        private void Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            if ((string)checkbox.Content == "Lab")
            {
                lab = true;
                if (areaInput.Length == 0)
                    areaInput += "Lab ";
                else
                    areaInput += ": Lab ";

            }

            else if ((string)checkbox.Content == "Front Desk")
            {
                frontDesk = true;
                if (areaInput.Length == 0)
                    areaInput += "FrontDesk ";
                else
                    areaInput += ": FrontDesk ";
            }

            else if ((string)checkbox.Content == "Lounge")
            {
                lounge = true;
                if (areaInput.Length == 0)
                    areaInput += "Lounge ";
                else
                    areaInput += ": Lounge ";
            }

            if (areaInput.Contains("Lab") && areaInput.Contains("FrontDesk") && areaInput.Contains("Lounge"))
            {
                areaInput = "Lab : FrontDesk : Lounge ";
            }

            else if (areaInput.Contains("Lab") && areaInput.Contains("FrontDesk") && !(areaInput.Contains("Lounge")))
            {
                areaInput = "Lab : FrontDesk ";
            }

            else if (areaInput.Contains("Lab") && areaInput.Contains("Lounge") && !(areaInput.Contains("FrontDesk")))
            {
                areaInput = "Lab : Lounge ";
            }

            else if (areaInput.Contains("FrontDesk") && areaInput.Contains("Lounge") && !(areaInput.Contains("Lab")))
            {
                areaInput = "FrontDesk : Lounge ";
            }
        }

        // This method is called when the user unchecks a checkbox in the SignIn window.
        // The checkbox gets unchecked and then the method iterates through all checkboxes to see which ones are 
        // Still checked, and recreates areaInput based on that.
        private void Clear(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            areaInput = "";

            // Get all checkboxes, see which are checked. Make areaInput based on that
            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Object i in AreaCanvas.Children)
            {
                if (i.GetType().ToString() == "System.Windows.Controls.CheckBox")
                    checkBoxes.Add((CheckBox)i);
            }

            foreach (CheckBox i in checkBoxes)
            {
                if ((string)i.Content == "Lab" && i.IsChecked == true)
                    areaInput = "Lab";

                if ((string)i.Content == "Front Desk" && i.IsChecked == true)
                {
                    if (areaInput.Length == 0)
                        areaInput = "FrontDesk";
                    else
                        areaInput += ": FrontDesk ";
                }

                if ((string)i.Content == "Lounge" && i.IsChecked == true)
                {
                    if (areaInput.Length == 0)
                        areaInput = "Lounge";
                    else
                        areaInput += ": Lounge ";
                }
            }
        }


        // Submit button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            string timeInput = DateTime.Now.ToString("h:mm tt");
            string dateInput = DateTime.Today.ToString("dd/MM/yyyy");

            submittedRecord = new SubmittedRecord { initials = initialsInput, time = timeInput, date = dateInput, area = areaInput };
            submittedRecord.SubmitRecord();

            initialsInput = "";
            areaInput = "";

            // Clear initials textbox
            foreach (Object i in MainCanvas.Children)
            {
                if (i.GetType().ToString() == "System.Windows.Controls.TextBox")
                    ((TextBox)i).Text = "";
            }

            // Clear area checkboxes
            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Object i in AreaCanvas.Children)
            {
                if (i.GetType().ToString() == "System.Windows.Controls.CheckBox")
                    checkBoxes.Add((CheckBox)i);
            }

            foreach (CheckBox checkBox in checkBoxes)
                checkBox.IsChecked = false;
        }

        // Get Entry button
        private void GetDBEntry(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            retrievedRecord = new RetrievedRecord { };
            if (initialsInput.Length < 1)
                initialsInput = "Test";

            retrievedRecord.view(initialsInput);
        }

        // initialsInput textbox
        private void TextBox_Initials(object sender, TextChangedEventArgs e)
        {
            TextBox initialsTextBox = (TextBox)sender;
            initialsInput = initialsTextBox.Text;
        }
    }
}
