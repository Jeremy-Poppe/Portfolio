using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
	static class Input
	{
		internal static string GetPlayerName(int playerNum)
		{
			string playerName = null;
			Output.PromptForName( playerNum );

			playerName = Console.ReadLine();

			return playerName;
		}

		internal static Coordinate GetCoordinateFromUser(string pName)
		{
			int x = -1;
			int y = -1;

			Output.PromptForCoordinate( pName );

			string userInput = Console.ReadLine();

			//Battleship coordinate inputs come in as "A10" or "E5"

			char yPart = userInput[ 0 ];
			string xPart = userInput.Substring( 1 );

			y = yPart - 'A' + 1;
			x = int.Parse( xPart );
			//TODO: switch to TryParse()

			Coordinate userCoord = new Coordinate( x, y );

			return userCoord;
		}

		internal static ShipDirection GetDirectionFromUser()
		{
			throw new NotImplementedException();
		}
	}
}
