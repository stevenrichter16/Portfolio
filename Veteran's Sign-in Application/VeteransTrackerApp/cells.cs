/*
 * Timothy Davis 
 * UW Oshkosh
 * CS 341
 * Veterans Department App
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeteransTrackerApp
{
	class Cell
	{
		public int myLoc = 16;
		public string myNam = "a";
		public Cell(int curLoc)
		{
			myLoc = curLoc;
		}
		public Cell()
		{

		}
		public void setNam(string newNam) { myNam = newNam; }
		public string getNam() { return myNam; }
		public int getLoc() { return myLoc; }
	}
}
