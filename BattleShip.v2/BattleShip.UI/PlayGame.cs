using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
	public class PlayGame
	{
		public void PlayGameNow()
		{
			bool player1Turn = RandomGenerator.WhosTurnFirst();
			bool gameStillGoing = true;
			Player player1 = new Player();
			Player player2 = new Player();
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
					if (response.ShotStatus == ShotStatus.Victory)
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
				bool playAgain = UserInput.PlayAgain();
		}
	}
}
