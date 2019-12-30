/*
 * Nathan Moder
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

namespace VeteransTrackerApp
{

	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		
		//Open the SignIn Window and close the current Window
		private void SwapSignIn(object sender, RoutedEventArgs e)
		{
			Window signInWindow = new SignIn();
			signInWindow.Show();
			this.Close();
		}

		//Open the Workstudy Window and close the current Window
		private void SwapPhoneEmail(object sender, RoutedEventArgs e)
		{
			Window phoneEmailWindow = new Workstudy();
			phoneEmailWindow.Show();
			this.Close();
		}

		//Open the DownloadData window and close the current Window
		private void SwapDownloadData(object sender, RoutedEventArgs e)
		{
			Window downloadDataWindow = new DownloadData();
			downloadDataWindow.Show();
			this.Close();
		}
	}
}
