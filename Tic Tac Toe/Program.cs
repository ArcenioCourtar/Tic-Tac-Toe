using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give the size of the board: ");
            GameBoard board = new GameBoard(int.Parse(Console.ReadLine()));
            Console.Write("Player 1 name: ");
            Player player1 = new Player(Console.ReadLine());
            Console.Write("Player 2 name: ");
            Player player2 = new Player(Console.ReadLine());

            int boardSize = board.boardSize;
            bool winner;        //flag marking when someone won
            bool draw;          //flag marking when it's a draw
            bool continuePlay = true;  //flag letting players start over or restart the game
            int turn = 0;       //turn counter

            Console.Clear();
            do
            {
                do
                {
                    turn++;
                    ShowBoard(board.boardSize, board.spaces);
                    if (turn % 2 != 0)
                    {
                        Console.WriteLine("It's " + player1.name + "'s turn");
                        FillTile(player1.number, board.spaces, board.boardSize);
                    }
                    else
                    {
                        Console.WriteLine("It's " + player2.name + "'s turn");
                        FillTile(player2.number, board.spaces, board.boardSize);
                    }
                    winner = CheckWinner(board.spaces);
                    draw = CheckDraw(board.spaces);

                    Console.Clear();
                } while (!winner & !draw);

                if (winner)
                {
                    ShowBoard(board.boardSize, board.spaces);
                    if (turn % 2 != 0)
                    {
                        player1.score++;
                        Console.WriteLine(player1.name + " Wins!");
                    }
                    else
                    {
                        player2.score++;
                        Console.WriteLine(player2.name + " Wins!");
                    }
                }
                else
                {
                    Console.WriteLine("It's a draw");
                }
                Console.WriteLine(player1.name + "'s score: " + player1.score);
                Console.WriteLine(player2.name + "'s score: " + player2.score);
                Console.ReadLine();
                Console.Clear();
                board = new GameBoard(boardSize);
            } while (continuePlay);
            Console.ReadLine();
        }

        //displays game board
        static void ShowBoard(int size, int[,] location)
        {
            for (int i1 = 0; i1 < size; i1++)
            {
                for (int i2 = 0; i2 < size; i2++)
                {
                    Console.Write(location[i1, i2] + "|");
                }
                Console.WriteLine();
                for (int i3 = 0; i3 < size * 2; i3++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }
        }
        //checks for winning boardstates
        static bool CheckWinner(int[,] location)
        {
            bool iswin = false;
            int gridSize = location.GetLength(0);

            /*Checks for horizontal winner
             *Checks if first number in the row is non-zero
             *If non-zero, it checks if each number in the row is equal to the first number
             *If yes, CheckWinner returns true, otherwise, continues to check Columns and diagonals
             *Works for any 2D array of size greater than 1*/

            for (int i1 = 0; i1 < gridSize; i1++)
            {
                for (int i2 = 1; i2 < gridSize; i2++)
                {
                    if (location[i1, 0] == location[i1, i2] & location[i1, 0] != 0)
                    {
                        iswin = true;
                    }
                    else
                    {
                        //no need to check further if you ever arrive here
                        iswin = false;
                        break;
                    }
                }
                if (iswin)
                {
                    return true;
                }
            }

            //Same routine for the columns
            for (int i1 = 0; i1 < gridSize; i1++)
            {
                for (int i2 = 1; i2 < gridSize; i2++)
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

            //diagonal top left bottom right
            for (int i = 1; i < gridSize; i++)
            {
                if (location[0, 0] == location[i, i] & location[0, 0] != 0)
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

            //diagonal bottom left to to right. Couldn't figure out a more elegant method.
            int diagCounter = 0;
            for (int i = gridSize - 1; i >= 0; i--)
            {
                if (location[gridSize - 1, 0] == location[i, diagCounter] & location[gridSize - 1, 0] != 0)
                {
                    diagCounter++;
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

            //returns false in case all checks failed
            return false;
        }
        //checks if boardstate is a draw
        static bool CheckDraw(int[,] location)
        {
            int gridSize = location.GetLength(0);

            for (int i1 = 0; i1 < gridSize; i1++)
            {
                for (int i2 = 1; i2 < gridSize; i2++)
                {
                    if (location[i1, i2] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //lets players fill tiles with their appropriate number
        static void FillTile(int playerNumber, int[,] location, int boardSize)

        {
            int xCoord;
            int yCoord;
            int compare;
            bool legalMove = false;

            do
            {
                try
                {
                    Console.Write("X coordinate of your move: ");
                    xCoord = int.Parse(Console.ReadLine());
                    Console.Write("Y coordinate of your move: ");
                    yCoord = int.Parse(Console.ReadLine());

                    compare = location[yCoord - 1, xCoord - 1];

                    if (xCoord <= boardSize & xCoord > 0 & yCoord <= boardSize & yCoord > 0)
                    {

                        if (compare == 0)
                        {
                            location[yCoord - 1, xCoord - 1] = playerNumber;
                            legalMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Coordinates already used, use different coordinates");
                        }
                    }
                    else
                    {
                        Console.WriteLine("out of bounds! Use different coordinates");
                    }
                }
                catch
                {
                    Console.WriteLine("Please use whole numbers");
                }
            } while (!legalMove);
        }

    }
}
