using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class GameBoard
    {
        public int[,] spaces;
        public int boardSize;

        public GameBoard(int aSpaces)
        {
            spaces = IntializeBoard(aSpaces);
            boardSize = aSpaces;

            for (int i1 = 0; i1 < aSpaces; i1++)
            {
                for (int i2 = 0; i2 < aSpaces; i2++)
                {
                    spaces[i1, i2] = 0;
                }
            }
        }

        private static int[,] IntializeBoard(int size)
        {
            int[,] array = new int[size, size];
            return array;
        }
    }
}
