using System;

namespace BattleShip.UI
{
    internal static class Output
    {
        internal static void PromptForName(int playerNumber)
        {
            Console.Write( $"Player {playerNumber}, please enter your name: " ); 
        }

        internal static void PromptForCoordinate(string playerName)
        {
            Console.Write( $"{playerName}, please enter a coordinate: " );
        }
    }
}