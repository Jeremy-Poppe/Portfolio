using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
	class SetupWorkflow
	{
		public Board Player1Board
		{ get; private set; }

		public Board Player2Board
		{
			get; private set;
		}

		public string Player1Name
		{
			get; private set;
		}

		public string Player2Name
		{
			get; private set;
		}

		public bool Player1GoesFirst
		{
			get; private set;
		}

		public void Start()
		{
			Player1Name = Input.GetPlayerName(1);
			Player2Name = Input.GetPlayerName(2);

			Player1Board = SetUpBoard( Player1Name );
			Player2Board = SetUpBoard( Player2Name );

			Player1GoesFirst = DecideWhoGoesFirst();

		}

		private bool DecideWhoGoesFirst()
		{
			throw new NotImplementedException();
		}

		private Board SetUpBoard(string pName)
		{
			Board toReturn = new Board();

			for( ShipType currentType = ShipType.Destroyer; currentType <= ShipType.Carrier; currentType++ )
			{
				PlaceShip( toReturn, currentType, pName );
			}

			return toReturn;
		}

		private void PlaceShip( Board placeOn, ShipType currentType, string playerName )
		{
			PlaceShipRequest req = new PlaceShipRequest()
			{
				ShipType = currentType,
				Coordinate = Input.GetCoordinateFromUser( playerName ),
				Direction = Input.GetDirectionFromUser()
			};

			ShipPlacement placementResult = placeOn.PlaceShip( req );

			//TODO: loop if ship placement failed
		}
	}
}
