
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


namespace VeteransTrackerApp
{
	public class SubmittedRecord : Record
	{
		public string connectionString = "Server=localhost;port=3306;user=team5;password=x287;database=team5";

        public void SubmitRecord()
		{
			MySqlConnection conn = null;
			MySqlCommand command = null;
			MySqlDataReader reader = null;

			try
			{
				conn = new MySqlConnection(connectionString);
				conn.Open();

				string strCommand = "INSERT INTO `Records`(`initials`, `inTime`, `date`, `area`) VALUES('" + this.initials + "','" + this.time + "','" + this.date + "','" + this.area + "')";

				command = new MySqlCommand(strCommand, conn);
				MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

				reader = command.ExecuteReader();

                MessageBox.Show("Submitted.");

    //            while (reader.Read())
				//{
				//	Object thing = reader.GetValue(0);
				//	MessageBox.Show("Submitted.");
				//}
			}
			catch
			{
				MessageBox.Show("Failed");
			}
		}
	}
}
