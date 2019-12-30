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
	class board
	{
		public Cell[] cells = new Cell[9];
		private CompPlay ci = new CompPlay();
		private bool win = false;
		private bool comp = false;
		public board()
		{
			for (int i = 0; i < 9; i++)
			{
				Cell c = new Cell(i);
				cells[i] = c;
			}
		}
		public bool winning() { return win; }
		public bool whoWin() { return comp; }
		public bool free(int loc)
		{
			if (winCheck() > 99)
			{
				win = true;
			}
			if (cells[loc].getNam().Equals("a"))
			{
				return true;
			}
			return false;
		}
		public void clearBoard()
		{
			for (int i = 0; i < 9; i++)
			{
				cells[i].setNam("a");
			}
			win = false;
			comp = false;
		}
		public Cell[] getCells() { return cells; }
		public void printBoard()
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					if (!cells[i].getNam().Equals("a"))
					{
						Console.Write(cells[i].getNam());
						i++;
					}
					else
					{
						Console.Write(cells[i].getLoc());
						i++;
					}
					Console.Write("|");
				}
				if (!cells[i].getNam().Equals("a"))
				{
					Console.Write(cells[i].getNam() + "\n");
				}
				else
				{
					Console.Write(cells[i].getLoc() + "\n");
				}
				if (i < 7)
				{
					Console.Write("-----\n");
				}

			}
		}
		public void changeBoard(int loc, string nam)
		{
			cells[loc].setNam(nam);
		}
		public int winCheck()
		{
			string a = cells[0].getNam();
			string b = cells[1].getNam();
			string c = cells[2].getNam();
			if (winCheckDriver(a, b, c) == 100)
			{
				return 100;
			}
			b = cells[4].getNam();
			c = cells[8].getNam();
			if (winCheckDriver(a, b, c) == 100)
			{
				return 100;
			}
			b = cells[3].getNam();
			c = cells[6].getNam();
			if (winCheckDriver(a, b, c) == 100)
			{
				return 100;
			}
			a = cells[1].getNam();
			b = cells[4].getNam();
			c = cells[7].getNam();
			if (winCheckDriver(a, b, c) == 100)
			{
				return 100;
			}
			a = cells[2].getNam();
			b = cells[5].getNam();
			c = cells[8].getNam();
			if (winCheckDriver(a, b, c) == 100)
			{
				return 100;
			}
			b = cells[4].getNam();
			c = cells[6].getNam();
			if (winCheckDriver(a, b, c) == 100)
			{
				return 100;
			}
			a = cells[3].getNam();
			b = cells[4].getNam();
			c = cells[5].getNam();
			if (winCheckDriver(a, b, c) == 100)
			{
				return 100;
			}
			a = cells[6].getNam();
			b = cells[7].getNam();
			c = cells[8].getNam();
			if (winCheckDriver(a, b, c) == 100)
			{
				return 100;
			}
			return 0;
		}
		public int winCheckDriver(string a, string b, string c)
		{
			if (tieCheck())
			{
				win = true;
				comp = true;
			}
			if (!a.Equals("a"))
			{
				if (a.Equals(b) && a.Equals(c))
				{
					if (a.Equals(ci.getTok()))
					{
						printBoard();
						Console.Write("\n\n\nYou Win!!!!!\n");
						win = true;
						comp = false;
						return 100;
					}
					else
					{
						printBoard();
						Console.Write("\n\n\nGame Over\nYou Lose");
						win = true;
						comp = true;
						return 100;
					}
				}
			}
			else
			{
				return 0;
			}
			return 0;
		}
		public bool tieCheck()
		{
			bool notTie = true;
			for (int i = 0; i < 9; i++)
			{
				if (cells[i].getNam().Equals("a"))
				{
					notTie = false;
				}
			}
			return notTie;
		}
	}
}