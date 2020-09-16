using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Player
    {
        public int number = 0;
        public string name;
        public int score = 0;
        private static int playerCount = 0;

        public Player(string aPlayerName)
        {
            name = aPlayerName;
            playerCount++;

            number = playerCount;
        }
    }
}
