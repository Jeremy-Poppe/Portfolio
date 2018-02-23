using System;
using System.Linq;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI;

namespace BattleShip.UI
{
	internal class UserInput
	{
		internal static string GetUserName(int player)
		{
			string name = null;
			Console.Clear();
			UserOutput.PromptUserForName(player);
			name = Console.ReadLine();
			return name;
		}

		internal static Coordinate GetCoordinateForPlacement(string name)
		{
			char coordinateChar1 = ' ';
			char coordinateChar2 = ' ';
			string coordinateSubstring2 = "";
			bool invalidAnswer = true;
			int x = -1;
			int y = -1;
			string userAnswer = null;
			while (invalidAnswer)
			{
				UserOutput.GetCoordiante(name);
				userAnswer = null;
				userAnswer = Console.ReadLine();
				if (userAnswer.Length == 2)
				{
					coordinateChar1 = userAnswer[0];
					coordinateChar2 = userAnswer[1];
				}
				else if (userAnswer.Length == 3)
				{
					coordinateChar1 = userAnswer[0];
					coordinateSubstring2 = userAnswer.Substring(1, 2);
				}
				else
				{
					invalidAnswer = true;
					break;
				}
				string validChars = "ABCDEFGHIJabcdefghij";
				string validNumbers = "123456789";
				if (validChars.Contains(coordinateChar1))
				{
					invalidAnswer = false;
					switch (coordinateChar1.ToString().ToUpper())
					{
						case "A":
							y = 1;
							break;
						case "B":
							y = 2;
							break;
						case "C":
							y = 3;
							break;
						case "D":
							y = 4;
							break;
						case "E":
							y = 5;
							break;
						case "F":
							y = 6;
							break;
						case "G":
							y = 7;
							break;
						case "H":
							y = 8;
							break;
						case "I":
							y = 9;
							break;
						case "J":
							y = 10;
							break;
						default:
							UserOutput.InvalidCoordinate();
							invalidAnswer = true;
							break;
					}
				}
				else
				{
					UserOutput.InvalidCoordinate();
					invalidAnswer = true;
					break;
				}
				// y coordinate parsing 
				if (coordinateSubstring2.Length == 2)
				{
					int value;
					if (int.TryParse(coordinateSubstring2.Substring(0, 2), out value))
					{
						x = value;
					}
					else
					{
						UserOutput.InvalidCoordinate();
						invalidAnswer = true;
						break;
					}
				}
				else if (validNumbers.Contains(coordinateChar2))
				{
					int value;
					if (int.TryParse(coordinateChar2.ToString(), out value))
					{
						x = value;
					}
					else
					{
						UserOutput.InvalidCoordinate();
						invalidAnswer = true;
						break;
					}
				}
				else
				{
					UserOutput.InvalidCoordinate();
					invalidAnswer = true;
				}
			}
			Coordinate PlacementCoordinate = new Coordinate(x, y);
			return PlacementCoordinate;
		}

		internal static bool PlayAgain()
		{
			bool playAgain = false;
			bool invalidInput = true;
			while (invalidInput)
			{
				string userInput = "";
				UserOutput.PlayAgain();
				userInput = Console.ReadLine();

				if (userInput.ToLower() == "yes")
				{
					playAgain = true;
					invalidInput = false;
					break;
				}
				else if (userInput.ToLower() == "no")
				{
					playAgain = false;
					invalidInput = false;
					break;
				}
				else
				{
					invalidInput = true;
				}
			}
			return playAgain;
		}

		internal static ShipDirection GetShipDirection(ShipType shipToBePlaced)
		{
			ShipDirection direction = ShipDirection.Up;
			bool invalidAnswer = true;
				UserOutput.GetDirection(shipToBePlaced);
				string userAnswer = null;
				userAnswer = Console.ReadLine();
				switch (userAnswer.ToLower())
				{
					case "u":
						direction = ShipDirection.Up;
						invalidAnswer = false;
						break;
					case "d":
						direction = ShipDirection.Down;
						invalidAnswer = false;
						break;
					case "l":
						direction = ShipDirection.Left;
						invalidAnswer = false;
						break;
					case "r":
						direction = ShipDirection.Right;
						invalidAnswer = false;
						break;
					default:
						invalidAnswer = true;
						UserOutput.InvalidCoordinate();
						break;
				}
			while (invalidAnswer);
			return direction;
		}

		public static bool AttackAndCheckShotStatus(FireShotResponse response, string name)
		{
			bool invalidShot = false;
			{
				switch (response.ShotStatus)
				{
					case ShotStatus.Duplicate:
						UserOutput.DuplicateShot(name);
						invalidShot = true;
						break;
					case ShotStatus.Invalid:
						UserOutput.InvalidShot(name);
						invalidShot = true;
						break;
					case ShotStatus.Hit:
						UserOutput.Hit(name);
						invalidShot = false;
						break;
					case ShotStatus.HitAndSunk:
						UserOutput.HitAndSunk(name);
						invalidShot = false;
						break;
					case ShotStatus.Miss:
						UserOutput.Miss(name);
						invalidShot = false;
						break;
					case ShotStatus.Victory:
						UserOutput.Victory(name);
						invalidShot = false;
						break;
				}
			}
			return invalidShot;
		}
	}






	

}