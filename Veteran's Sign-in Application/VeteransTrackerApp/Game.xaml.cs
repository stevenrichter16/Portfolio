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
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Game : Window
	{
		public Game()
		{
			InitializeComponent();
		}

		private bool singles = true;
		private bool origin = true;
		private bool x = true;
		private board b = new board();
		private CompPlay ci = new CompPlay();
		private int compMove = 0;
		private int moveCnt = 1;
		private bool board = false;
		private string player = "a";
		private int doublesPlay = 0;

		private void Menu_Item_Quitter(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void L0Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(0);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out0.Visibility = Visibility.Visible;
							Out0.Text = " " + player;
							b.changeBoard(0, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(0, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out0.Visibility = Visibility.Visible;
							Out0.Text = " X";
							b.changeBoard(0, "X");
						}
						else
						{
							doublesPlay = 0;
							Out0.Visibility = Visibility.Visible;
							Out0.Text = " O";
							b.changeBoard(0, "O");
						}
						b.winCheck();
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void L1Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(1);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out1.Visibility = Visibility.Visible;
							Out1.Text = " " + player;
							b.changeBoard(1, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(1, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out1.Visibility = Visibility.Visible;
							Out1.Text = " X";
							b.changeBoard(1, "X");
						}
						else
						{
							doublesPlay = 0;
							Out1.Visibility = Visibility.Visible;
							Out1.Text = " O";
							b.changeBoard(1, "O");
						}
						b.winCheck();
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void L2Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(2);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out2.Visibility = Visibility.Visible;
							Out2.Text = " " + player;
							b.changeBoard(2, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(2, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out2.Visibility = Visibility.Visible;
							Out2.Text = " X";
							b.changeBoard(2, "X");
						}
						else
						{
							doublesPlay = 0;
							Out2.Visibility = Visibility.Visible;
							Out2.Text = " O";
							b.changeBoard(2, "O");
						}
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void L3Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(3);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out3.Visibility = Visibility.Visible;
							Out3.Text = " " + player;
							b.changeBoard(3, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(3, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out3.Visibility = Visibility.Visible;
							Out3.Text = " X";
							b.changeBoard(3, "X");
						}
						else
						{
							doublesPlay = 0;
							Out3.Visibility = Visibility.Visible;
							Out3.Text = " O";
							b.changeBoard(3, "O");
						}
						b.winCheck();
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void L4Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(4);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out4.Visibility = Visibility.Visible;
							Out4.Text = " " + player;
							b.changeBoard(4, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(4, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out4.Visibility = Visibility.Visible;
							Out4.Text = " X";
							b.changeBoard(4, "X");
						}
						else
						{
							doublesPlay = 0;
							Out4.Visibility = Visibility.Visible;
							Out4.Text = " O";
							b.changeBoard(4, "O");
						}
						b.winCheck();
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void L5Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(5);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out5.Visibility = Visibility.Visible;
							Out5.Text = " " + player;
							b.changeBoard(5, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(5, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out5.Visibility = Visibility.Visible;
							Out5.Text = " X";
							b.changeBoard(5, "X");
						}
						else
						{
							doublesPlay = 0;
							Out5.Visibility = Visibility.Visible;
							Out5.Text = " O";
							b.changeBoard(5, "O");
						}
						b.winCheck();
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void L6Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(6);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out6.Visibility = Visibility.Visible;
							Out6.Text = " " + player;
							b.changeBoard(6, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(6, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out6.Visibility = Visibility.Visible;
							Out6.Text = " X";
							b.changeBoard(6, "X");
						}
						else
						{
							doublesPlay = 0;
							Out6.Visibility = Visibility.Visible;
							Out6.Text = " O";
							b.changeBoard(6, "O");
						}
						b.winCheck();
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void L7Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(7);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out7.Visibility = Visibility.Visible;
							Out7.Text = " " + player;
							b.changeBoard(7, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(7, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out7.Visibility = Visibility.Visible;
							Out7.Text = " X";
							b.changeBoard(7, "X");
						}
						else
						{
							doublesPlay = 0;
							Out7.Visibility = Visibility.Visible;
							Out7.Text = " O";
							b.changeBoard(7, "O");
						}
						b.winCheck();
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void L8Click(object sender, RoutedEventArgs e)
		{
			bool ok = b.free(8);
			if (board)
			{
				if (ok)
				{
					if (singles)
					{
						if (!origin)
						{
							Out8.Visibility = Visibility.Visible;
							Out8.Text = " " + player;
							b.changeBoard(8, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											Out0.Visibility = Visibility.Visible;
											Out0.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 1:
											Out1.Visibility = Visibility.Visible;
											Out1.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 2:
											Out2.Visibility = Visibility.Visible;
											Out2.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 3:
											Out3.Visibility = Visibility.Visible;
											Out3.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 4:
											Out4.Visibility = Visibility.Visible;
											Out4.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 5:
											Out5.Visibility = Visibility.Visible;
											Out5.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 6:
											Out6.Visibility = Visibility.Visible;
											Out6.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 7:
											Out7.Visibility = Visibility.Visible;
											Out7.Text = " " + ci.getMyT();
											b.printBoard();
											break;
										case 8:
											Out8.Visibility = Visibility.Visible;
											Out8.Text = " " + ci.getMyT();
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
						else
						{
							i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/blood-hand-png-1.png", UriKind.RelativeOrAbsolute));
							b.changeBoard(8, player);
							b.printBoard();
							compMove = ci.compInt(b.cells, moveCnt);
							b.winCheck();
							moveCnt++;
							if (!b.winning())
							{
								if (b.free(compMove))
								{
									b.changeBoard(compMove, ci.getMyT());
									switch (compMove)
									{
										case 0:
											i0.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 1:
											i1.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 2:
											i2.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 3:
											i3.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 4:
											i4.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 5:
											i5.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 6:
											i6.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 7:
											i7.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
										case 8:
											i8.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/CompO.jpg", UriKind.RelativeOrAbsolute));
											b.printBoard();
											break;
									}
								}
							}
							else
							{
								if (b.whoWin())
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/Term.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "BOW BEFORE YOUR COMPUTER OVERLORD WEAK HUMAN!!!!!!!!!!!";
								}
								else
								{
									EndGame.Source = new BitmapImage(new Uri("C:\\Users\\timot\\Programs\\CS341\\ImagesForTictacno/John-Connor.jpg", UriKind.RelativeOrAbsolute));
									EndGameT.Visibility = Visibility.Visible;
									EndGameT.Text = "Wow, You won a game of Tic tac toe against a calculator... WEAK!!!!!!!";
								}
							}
						}
					}
					else
					{
						if (doublesPlay == 0)
						{
							doublesPlay++;
							Out8.Visibility = Visibility.Visible;
							Out8.Text = " X";
							b.changeBoard(8, "X");
						}
						else
						{
							doublesPlay = 0;
							Out8.Visibility = Visibility.Visible;
							Out8.Text = " O";
							b.changeBoard(8, "O");
						}
						b.winCheck();
						if (b.winning())
						{
							if (!b.whoWin())
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 2 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Congrats... You defeated a human... What can't you handle a real challenge?";
							}
							else
							{
								EndGame2.Visibility = Visibility.Visible;
								EndGame2.Text = "Player 1 is the Winner";
								EndGameT.Visibility = Visibility.Visible;
								EndGameT.Text = "Woop-d-doo... You can defeat a human... Go ahead and call home... Your mom might even write a note saying you won a game and hang it on the fridge... Yawn";
							}
						}
					}
				}
			}

		}

		private void Original_Click(object sender, RoutedEventArgs e)
		{
			x = true;
			origin = true;
			board = true;
			b.clearBoard();
			player = "X";
			moveCnt = 1;
			ci.changeTok(player);
			Out0.Visibility = Visibility.Hidden;
			Out1.Visibility = Visibility.Hidden;
			Out2.Visibility = Visibility.Hidden;
			Out3.Visibility = Visibility.Hidden;
			Out4.Visibility = Visibility.Hidden;
			Out5.Visibility = Visibility.Hidden;
			Out6.Visibility = Visibility.Hidden;
			Out7.Visibility = Visibility.Hidden;
			Out8.Visibility = Visibility.Hidden;
			EndGameT.Visibility = Visibility.Hidden;
			EndGame2.Visibility = Visibility.Hidden;
			i0.Source = null;
			i1.Source = null;
			i2.Source = null;
			i3.Source = null;
			i4.Source = null;
			i5.Source = null;
			i6.Source = null;
			i7.Source = null;
			i8.Source = null;
			EndGame.Source = null;
		}

		private void X_Click(object sender, RoutedEventArgs e)
		{
			origin = false;
			x = true;
			board = true;
			b.clearBoard();
			player = "X";
			moveCnt = 1;
			ci.changeTok(player);
			Out0.Visibility = Visibility.Hidden;
			Out1.Visibility = Visibility.Hidden;
			Out2.Visibility = Visibility.Hidden;
			Out3.Visibility = Visibility.Hidden;
			Out4.Visibility = Visibility.Hidden;
			Out5.Visibility = Visibility.Hidden;
			Out6.Visibility = Visibility.Hidden;
			Out7.Visibility = Visibility.Hidden;
			Out8.Visibility = Visibility.Hidden;
			EndGameT.Visibility = Visibility.Hidden;
			EndGame2.Visibility = Visibility.Hidden;
			i0.Source = null;
			i1.Source = null;
			i2.Source = null;
			i3.Source = null;
			i4.Source = null;
			i5.Source = null;
			i6.Source = null;
			i7.Source = null;
			i8.Source = null;
			EndGame.Source = null;
		}

		private void O_Click(object sender, RoutedEventArgs e)
		{
			origin = false;
			x = false;
			board = true;
			b.clearBoard();
			moveCnt = 1;
			player = "O";
			ci.changeTok(player);
			Out0.Visibility = Visibility.Hidden;
			Out1.Visibility = Visibility.Hidden;
			Out2.Visibility = Visibility.Hidden;
			Out3.Visibility = Visibility.Hidden;
			Out4.Visibility = Visibility.Hidden;
			Out5.Visibility = Visibility.Hidden;
			Out6.Visibility = Visibility.Hidden;
			Out7.Visibility = Visibility.Hidden;
			Out8.Visibility = Visibility.Hidden;
			EndGameT.Visibility = Visibility.Hidden;
			EndGame2.Visibility = Visibility.Hidden;
			i0.Source = null;
			i1.Source = null;
			i2.Source = null;
			i3.Source = null;
			i4.Source = null;
			i5.Source = null;
			i6.Source = null;
			i7.Source = null;
			i8.Source = null;
			EndGame.Source = null;
		}

		private void Doubles_Click(object sender, RoutedEventArgs e)
		{
			doublesPlay = 0;
			singles = false;
			board = true;
			b.clearBoard();
			ci.changeTok("O");
			Out0.Visibility = Visibility.Hidden;
			Out1.Visibility = Visibility.Hidden;
			Out2.Visibility = Visibility.Hidden;
			Out3.Visibility = Visibility.Hidden;
			Out4.Visibility = Visibility.Hidden;
			Out5.Visibility = Visibility.Hidden;
			Out6.Visibility = Visibility.Hidden;
			Out7.Visibility = Visibility.Hidden;
			Out8.Visibility = Visibility.Hidden;
			EndGameT.Visibility = Visibility.Hidden;
			EndGame2.Visibility = Visibility.Hidden;
			i0.Source = null;
			i1.Source = null;
			i2.Source = null;
			i3.Source = null;
			i4.Source = null;
			i5.Source = null;
			i6.Source = null;
			i7.Source = null;
			i8.Source = null;
			EndGame.Source = null;
		}
	}
}
