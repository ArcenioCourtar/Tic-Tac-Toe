using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Player
    {
        public int playerNumber = 0;
        public string playerName;
        private static int playerCount = 0;

        public Player(string aPlayerName)
        {
            playerName = aPlayerName;
            playerCount++;

            playerNumber = playerCount;
        }
    }
}
