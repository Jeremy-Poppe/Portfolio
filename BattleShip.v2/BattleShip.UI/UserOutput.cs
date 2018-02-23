using System;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
	internal class UserOutput
	{
		internal static void PromptUserForName(int player)
		{
			Console.Write($"player {player} please enter your name: ", player);
		}

		internal static void GetCoordiante(string name)
		{
			Console.Write($"{name}, Please enter the coordinate where you like to place the ship (A1, B8)");
		}

		internal static void GetDirection(ShipType shipToBePlaced )
		{
			Console.WriteLine($"Please enter the direction you would like {shipToBePlaced} (U)p, (D)own, (R)ight, (L)eft");
		}

		internal static void InvalidCoordinate()
		{
			Console.WriteLine("The coordiante you have entered to place your ship is invalid");
		}

		internal static void CoordinateForShot(string name)
		{
			Console.WriteLine($"{name}, Please enter the coordinate you would like to attack (A1 B3)");
		}

		internal static void DuplicateShot(string name)
		{
			Console.WriteLine($"{name} Please enter another shot, the previous one was a duplicate");
		}

		internal static void Hit(string name)
		{
			Console.WriteLine($"{name} The shot was a hit!");
		}

		internal static void InvalidShot(string name)
		{
			Console.WriteLine($"{name} Your shot was invalid.  Please try again.");
		}

		internal static void HitAndSunk(string name)
		{
			Console.WriteLine($"{name} You have hit and sunk a ship!");
		}

		internal static void Miss(string name)
		{
			Console.WriteLine($"{name} Your shot is a miss.");
		}

		internal static void BoardDisplay(Board playerBoard)
		{
			string leftSideOfMap = "ABCDEFGHIJ";
			string topOfMap = "0123456789";



			for (int i = 0; i < 11; i++)
			{
				Console.WriteLine();
				for (int j = 0; j < 11; j++)
				{
					if (i == 0 && j == 0)
					{
						Console.Write("  ");
					}
					else if (i == 0 && j == 10)
					{
						Console.Write(topOfMap[1] + "" + topOfMap[0]);
					}
					else if (i == 0 && j != 10)
					{
						Console.Write(topOfMap[j] + " ");

					}
					else if (j == 0 && i != 0)
					{
						Console.Write(leftSideOfMap[i - 1]);
					}
					else if (i != 0)
					{
						Coordinate coordinateToDisplay = new Coordinate(j,i);
						ShotHistory positionHistory = playerBoard.CheckCoordinate(coordinateToDisplay);
						if (positionHistory == ShotHistory.Hit)
						{
							Console.Write(" x");
						}
						else if (positionHistory == ShotHistory.Miss)
						{
							Console.Write(" o");
						}
						else
						{
							Console.Write(" ~");
						}
					}
				}
			}
		}

		internal static void Victory(string name)
		{
			Console.WriteLine($"{name} Congratulations, you have won!");
		}

		internal static void NotEnoughSpace()
		{
			Console.WriteLine("There is not enough space where you attempted to put your code");
		}

		internal static void OverLap()
		{
			Console.WriteLine("The ships overlap, please re-enter the coordinates");
		}

		internal static void ShipPlacedSuccessfully(ShipType currentType)
		{
			Console.WriteLine($"The {currentType} has been placed successfully!");
		}

		internal static void PlayAgain()
		{
			Console.WriteLine("Would you like to play again (Yes/No)");
		}
	}
}