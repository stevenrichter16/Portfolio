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
	class CompPlay
	{
		private static string token = "a";
		private string myTok = "a";
		public void changeTok(string tok)
		{
			token = tok;
			if (token.Equals("X")) { myTok = "O"; }
			else { myTok = "X"; }
		}
		public string getTok() { return token; }
		public string getMyT() { return myTok; }
		public int compInt(Cell[] cells, int round)
		{
			if (round == 1)
			{
				if (cells[4].getNam().Equals(token))
				{
					return 6;
				}
				else if (cells[6].getNam().Equals(token))
				{
					return 4;
				}
				else
				{
					return 6;
				}
			}
			else if (round == 2)
			{
				if (cells[4].getNam().Equals(token))
				{
					int secMove = 0;
					for (int i = 0; i < 9; i++)
					{
						if (i == 4) { i++; }
						if (cells[i].getNam().Equals(token)) { secMove = i; }

					}
					switch (secMove)
					{
						case 0:
							return 8;
							break;
						case 1:
							return 7;
							break;
						case 2:
							return 8;
							break;
						case 3:
							return 5;
							break;
						case 5:
							return 3;
							break;
						case 7:
							return 1;
							break;
						case 8:
							return 0;
							break;
						default:
							return 2;
							break;
					}
				}
				else
				{
					int[] moves = new int[2];
					int index = 0;
					for (int i = 0; i < 9; i++)
					{
						if (index == 2)
						{
							i = 9;
						}
						else
						{
							if (cells[i].getNam().Equals(token))
							{
								moves[index] = cells[i].getLoc();
								index++;
							}
						}
					}
					switch (moves[0])
					{
						case 0:
							switch (moves[1])
							{
								case 1:
									return 2;
									break;
								case 2:
									return 1;
									break;
								case 3:
									return 2;
									break;
								case 6:
									return 3;
									break;
								case 8:
									return 4;
									break;
								default:
									return 2;
									break;
							}
							break;
						case 1:
							if (moves[1] == 7)
							{
								return 4;
							}
							else if (moves[1] == 2)
							{
								return 0;
							}
							else
							{
								return 2;
							}
							break;
						case 2:
							if (moves[1] == 5)
							{
								return 8;
							}
							else if (moves[1] == 6)
							{
								if (cells[4].getNam().Equals("a"))
								{
									return 4;
								}
								else
								{
									return 8;
								}
							}
							else if (moves[1] == 8)
							{
								return 5;
							}
							else
							{
								return 8;
							}
							break;
						case 3:
							if (moves[1] == 5)
							{
								return 4;
							}
							else if (moves[1] == 6)
							{
								return 0;
							}
							else if (moves[1] == 2)
							{
								return 8;
							}
							else
							{
								return 2;
							}
							break;
						case 5:
							if (moves[1] == 8)
							{
								return 2;
							}
							else
							{
								return 2;
							}
							break;
						case 6:
							if (moves[1] == 7)
							{
								return 8;
							}
							else
							{
								return 7;
							}
							break;
						default:
							if (moves[1] == 2)
							{
								return 8;
							}
							else
							{
								return 2;
							}
							break;
					}
				}
			}
			else if (round == 3)
			{
				int[] avLoc = new int[4];
				int index = 0;
				for (int i = 0; i < 9; i++)
				{
					if (index == 4)
					{
						i = 9;
					}
					else
					{
						if (cells[i].getNam().Equals("a"))
						{
							avLoc[index] = i;
							index++;
						}
					}
				}
				int[] strength = new int[4];
				index = 0;
				int maxStr = 0;
				for (int i = 0; i < avLoc.Length; i++)
				{
					strength[i] = strengthTest(avLoc[i], cells);
					if (strength[i] > maxStr)
					{
						index = i;
						maxStr = strength[i];
					}
				}
				return avLoc[index];
			}
			else
			{
				int[] avLoc = new int[2];
				int index = 0;
				for (int i = 0; i < 9; i++)
				{
					if (index == 2)
					{
						i = 9;
					}
					else
					{
						if (cells[i].getNam().Equals("a"))
						{
							avLoc[index] = i;
							index++;
						}
					}
				}
				int[] strength = new int[4];
				index = 0;
				int maxStr = 0;
				for (int i = 0; i < avLoc.Length; i++)
				{
					strength[i] = strengthTest(avLoc[i], cells);
					if (strength[i] > maxStr)
					{
						index = i;
						maxStr = strength[i];
					}
				}
				return avLoc[index];
			}
		}
		private int strengthTest(int loc, Cell[] cells)
		{
			int strength = 0;
			switch (loc)
			{
				case 0:
					if (cells[1].getNam().Equals(token) && cells[2].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[3].getNam().Equals(token) && cells[6].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[4].getNam().Equals(token) && cells[8].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[1].getNam().Equals(token) || cells[2].getNam().Equals(token) || cells[3].getNam().Equals(token) ||
						cells[4].getNam().Equals(token) || cells[6].getNam().Equals(token) || cells[8].getNam().Equals(token))
					{
						strength += 1;
					}
					else
					{
						strength = 0;
					}
					break;
				case 1:
					if (cells[0].getNam().Equals(token) && cells[1].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[4].getNam().Equals(token) && cells[7].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[0].getNam().Equals(token) || cells[1].getNam().Equals(token) || cells[4].getNam().Equals(token) ||
						cells[7].getNam().Equals(token))
					{
						strength += 1;
					}
					else
					{
						strength = 0;
					}
					break;
				case 2:
					if (cells[0].getNam().Equals(token) && cells[1].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[5].getNam().Equals(token) && cells[8].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[4].getNam().Equals(token) && cells[6].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[0].getNam().Equals(token) || cells[1].getNam().Equals(token) || cells[5].getNam().Equals(token) ||
						cells[8].getNam().Equals(token) || cells[4].getNam().Equals(token) || cells[6].getNam().Equals(token))
					{
						strength += 1;
					}
					else
					{
						strength = 0;
					}
					break;
				case 3:
					if (cells[0].getNam().Equals(token) && cells[6].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[4].getNam().Equals(token) && cells[5].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[0].getNam().Equals(token) || cells[6].getNam().Equals(token) || cells[4].getNam().Equals(token) ||
						cells[5].getNam().Equals(token))
					{
						strength += 1;
					}
					else
					{
						strength = 0;
					}
					break;
				case 4:
					strength = 9001;
					break;
				case 5:
					if (cells[2].getNam().Equals(token) && cells[8].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[4].getNam().Equals(token) && cells[3].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[2].getNam().Equals(token) || cells[8].getNam().Equals(token) || cells[4].getNam().Equals(token) ||
						cells[3].getNam().Equals(token))
					{
						strength += 1;
					}
					else
					{
						strength = 0;
					}
					break;
				case 6:
					if (cells[0].getNam().Equals(token) && cells[3].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[7].getNam().Equals(token) && cells[8].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[4].getNam().Equals(token) && cells[2].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[0].getNam().Equals(token) || cells[3].getNam().Equals(token) || cells[7].getNam().Equals(token) ||
						cells[8].getNam().Equals(token) || cells[4].getNam().Equals(token) || cells[2].getNam().Equals(token))
					{
						strength += 1;
					}
					else
					{
						strength = 0;
					}
					break;
				case 7:
					if (cells[6].getNam().Equals(token) && cells[8].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[4].getNam().Equals(token) && cells[1].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[6].getNam().Equals(token) || cells[8].getNam().Equals(token) || cells[4].getNam().Equals(token) ||
						cells[1].getNam().Equals(token))
					{
						strength = 1;
					}
					else
					{
						strength = 0;
					}
					break;
				default:
					if (cells[0].getNam().Equals(token) && cells[4].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[7].getNam().Equals(token) && cells[6].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[5].getNam().Equals(token) && cells[2].getNam().Equals(token))
					{
						strength = 2;
					}
					else if (cells[0].getNam().Equals(token) || cells[4].getNam().Equals(token) || cells[7].getNam().Equals(token) ||
						cells[6].getNam().Equals(token) || cells[5].getNam().Equals(token) || cells[2].getNam().Equals(token))
					{
						strength += 1;
					}
					else
					{
						strength = 0;
					}
					break;

			}
			return strength;
		}
	}
}
