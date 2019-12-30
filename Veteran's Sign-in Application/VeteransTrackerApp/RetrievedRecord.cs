
/*
 * Steven Richter
 * UW Oshkosh
 * CS 341
 * Veteran's Department App
 */

using System;
using System.IO;
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
	public class RetrievedRecord : Record
	{
		public string connectionString = "Server=localhost;port=3306;user=team5;password=x287;database=team5";

		public void view(string inInitials)
		{
			MySqlConnection conn = null;
			MySqlCommand command = null;
			MySqlDataReader reader = null;

			try
			{
				conn = new MySqlConnection(connectionString);
				conn.Open();

				string strCommand = "SELECT * FROM `Records` WHERE initials='" + inInitials + "'";

				command = new MySqlCommand(strCommand, conn);
				MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

				reader = command.ExecuteReader();

				while (reader.Read())
				{

					Object initials = reader.GetValue(0);
					this.initials = initials.ToString();

					Object time = reader.GetValue(1);
					this.time = time.ToString();

					Object date = reader.GetValue(2);
					this.date = date.ToString();

					Object area = reader.GetValue(3);
					this.area = area.ToString();

					MessageBox.Show(this.initials + ", " + this.time + ", " + this.date + ", " + this.area);
				}
			}

			catch
			{
				MessageBox.Show("Failed");
			}
		}

		public void viewer(string inDateS, string inDateE, string inArea)
		{
			bool lab = findArea(inArea, "lab");
			bool desk = findArea(inArea, "desk");
			bool lounge = findArea(inArea, "lounge");
			bool email = findArea(inArea, "email");
			bool phone = findArea(inArea, "phone");
			MySqlConnection conn = null;
			MySqlCommand command = null;
			MySqlDataReader reader = null;

			try
			{
				conn = new MySqlConnection(connectionString);
				conn.Open();

                // Get all db entries
                string strCommand = "SELECT * FROM `Records`";
                command = new MySqlCommand(strCommand, conn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Object initials = reader.GetValue(0);
                    this.initials = initials.ToString();

                    Object time = reader.GetValue(1);
                    this.time = time.ToString();

                    Object date = reader.GetValue(2);
                    this.date = date.ToString();

                    Object area = reader.GetValue(3);
                    this.area = area.ToString();
                    if (lab || desk || lounge || email || phone)
                    {
                        string item = "" + this.initials + ", " + this.time + ", " + this.date + ", " + this.area;
                        export(item);
                    }
                }
            }

            catch
			{
				MessageBox.Show("Failed");
			}
		}

		public bool findArea(string areas, string reqArea)
		{
			 return areas.ToLower().Contains(reqArea);
		}

		public void export(string inString)
		{
			string path = @"c:\ProgramData\entries.csv";

            try
            {
                if (!(File.Exists(path)))
                {
                    var file = File.Create(path);
                    StringBuilder content = new StringBuilder();
                    file.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // This is the entry content
            string info = inString;

            content.AppendLine("Entries");
            content.AppendLine(info);

            File.AppendAllText(path, content.ToString());

            MessageBox.Show("Successfully downloaded entries.");

            return;
        }
	}
}
