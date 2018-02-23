using System;

namespace BattleShip.UI
{
	internal class RandomGenerator
	{
		public static bool WhosTurnFirst()
		{
			Random rnd = new Random();
			bool player1Turn;
			int whosTurn = rnd.Next(0,2);
			if (whosTurn == 1)
			{
				player1Turn = true;
			}
			else
			{
				player1Turn = false;
			}
			return player1Turn;
		}
	}
}