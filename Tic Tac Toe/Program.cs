using System;
using System.Data;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give the size of the board: ");
            GameBoard board = new GameBoard(Convert.ToInt32(Console.ReadLine()));
            /*Console.Write("Number of players: ");
            int playerCount = Convert.ToInt32(Console.ReadLine());*/
            Console.Write("Player 1 name: ");
            Player player1 = new Player(Console.ReadLine());
            Console.Write("Player 2 name: ");
            Player player2 = new Player(Console.ReadLine());

            bool winner;
            int turn = 0;

            Console.Clear();
            do
            {
                turn++;
                ShowBoard(board.boardSize, board.spaces);
                if (turn % 2 != 0)
                {
                    Console.WriteLine("It's " + player1.playerName + "'s turn");
                    FillTile(player1.playerNumber, board.spaces);
                }
                else 
                {
                    Console.WriteLine("It's " + player2.playerName + "'s turn");
                    FillTile(player2.playerNumber, board.spaces); 
                }
                winner = CheckWinner(board.spaces);
                Console.Clear();
            }while (!winner);

            ShowBoard(board.boardSize, board.spaces);
            if (turn % 2 != 0)
            {
                Console.WriteLine(player1.playerName + " Wins!");
            }
            else
            {
                Console.WriteLine(player2.playerName + " Wins!");
            }
                Console.ReadLine();
        }

        static void ShowBoard(int size, int[,] location)
        {
            for (int i1 = 0; i1 < size; i1++)
            {
                for (int i2 = 0; i2 < size; i2++)
                {
                    Console.Write(location[i1,i2] + "|");
                }
                Console.WriteLine();
                for (int i3 = 0; i3 < size * 2; i3++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }
        }

        static bool CheckWinner(int[,] location)
        {
            bool iswin = false;
            for (int i1 = 0; i1 < location.GetLength(0); i1++)
            {
                for (int i2 = 1; i2 < location.GetLength(1); i2++)
                {
                    if (location[i1, 0] == location[i1, i2] & location[i1, 0] != 0)
                    {
                        iswin = true;
                    }
                    else
                    {
                        iswin = false;
                        break;
                    }
                }
                if (iswin)
                {
                    return true;
                }
            }

            for (int i1 = 0; i1 < location.GetLength(1); i1++)
            {
                for (int i2 = 1; i2 < location.GetLength(0); i2++)
                {
                    if (location[0, i1] == location[i2, i1] & location[0, i1] != 0)
                    {
                        iswin = true;
                    }
                    else
                    {
                        iswin = false;
                        break;
                    }
                }
                if (iswin)
                {
                    return true;
                }
            }
            return false;
        }

        static void FillTile(int playerNumber, int[,] location)
        {
            int xCoord;
            int yCoord;
            Console.Write("X coordinate of your move: ");
            xCoord = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y coordinate of your move: ");
            yCoord = Convert.ToInt32(Console.ReadLine());
            location[yCoord-1, xCoord-1] = playerNumber;
        }
    }
}
