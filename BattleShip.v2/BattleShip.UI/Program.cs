using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
			WorkflowSetUp start = new WorkflowSetUp();
			start.SetupBoard();
			PlayGame newGame = new PlayGame();
			newGame.PlayGameNow();
        }
    }
}
