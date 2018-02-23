using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI;

namespace BattleShip.UI
{
	class WorkflowSetUp
	{

		public void SetupBoard()
		{
			Player player1 = new Player();
			Player player2 = new Player();
			player1.Name = UserInput.GetUserName(1);
			player2.Name = UserInput.GetUserName(2);

			bool playAgain = true;

			bool player1Turn = RandomGenerator.WhosTurnFirst();
			while (playAgain)
			{

				player1.playerBoard = SetUpBoard(player1.Name);
				player2.playerBoard = SetUpBoard(player2.Name);
				bool gameStillGoing = true;
				while (gameStillGoing)
					{
						bool failedShotTurn1 = true;
						bool failedShotTurn2 = true;
						if (player1Turn)
						{
								UserOutput.BoardDisplay(player1.playerBoard);
								Coordinate attackCoordinate = UserInput.GetCoordinateForPlacement(player1.Name);
								FireShotResponse response = player1.playerBoard.FireShot(attackCoordinate);
								failedShotTurn1 = UserInput.AttackAndCheckShotStatus(response, player1.Name);
								if(response.ShotStatus == ShotStatus.Victory)
								{
									gameStillGoing = false;
								}
								else
								{
									player1Turn = false;
								}
						}
						else
						{
							while (failedShotTurn2)
							{
								UserOutput.BoardDisplay(player2.playerBoard);
								Coordinate attackCoordinate = UserInput.GetCoordinateForPlacement(player2.Name);
								FireShotResponse response = player2.playerBoard.FireShot(attackCoordinate);
								failedShotTurn2 = UserInput.AttackAndCheckShotStatus(response, player2.Name);
								if (response.ShotStatus == ShotStatus.Victory)
								{
									gameStillGoing = false;
								}
								else
								{
									player1Turn = true;
								}
							}
						}
					}
					playAgain = UserInput.PlayAgain();
			}
		}

		Board SetUpBoard(string name)
		{
			Board toReturn = new Board();				
			for (int i = 0; i < 5; i++)
			{
				ShipType currentType = SelectShip(i);
				PlaceShipRequest req = PlaceShip(toReturn, currentType, name);
				ShipPlacement response = toReturn.PlaceShip(req);
				if (response == ShipPlacement.NotEnoughSpace)
				{
					UserOutput.NotEnoughSpace();
					i--;
				}
				else if (response == ShipPlacement.Overlap)
				{
					UserOutput.OverLap();
					i--;
				}
				else
				{
					UserOutput.ShipPlacedSuccessfully(currentType);
				}
			}
			return toReturn;
		}

		private PlaceShipRequest PlaceShip(Board toReturn, ShipType currentType, string name)
		{
			PlaceShipRequest req1 = new PlaceShipRequest
			{
				Coordinate = UserInput.GetCoordinateForPlacement(name),
				ShipType = currentType,
				Direction = UserInput.GetShipDirection(currentType)
			};
			return req1;
		}

		private ShipType SelectShip(int i)
		{
			ShipType choice = ShipType.Battleship;
			int number = i;

			switch (number)
			{
				case 0:
					choice = ShipType.Battleship;
					break;
				case 1:
					choice = ShipType.Carrier;
					break;
				case 2:
					choice = ShipType.Cruiser;
					break;
				case 3:
					choice = ShipType.Destroyer;
					break;
				case 4:
					choice = ShipType.Submarine;
					break;
			}
			return choice;
		}

	}
}
