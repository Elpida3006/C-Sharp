using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

//Recursion//

namespace _8Queens
{
    class Program
    {
        private const int Size = 8;
        static int[,] board = new int[Size, Size];

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();

        static void Solve(int row)
        
        {
            if (row == Size)
            {
                PrintSolution();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if(CanPlaceQueen(row, col))
               
                    {
                        MarckedAtachfield(row, col);
                        Solve(row + 1);
                        //с това пускаме рекурсията;
                        UnmarkAttackedFields(row, col);

                    }
                }
            }

        }

        private static void PrintSolution()
        {
           for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    if (board[row, col] == 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                  
                }
                //sled prinirane na wsichki redowe, printirane prazen red
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void MarckedAtachfield(int row, int col)
        {
            board[row, col] = 1;
            attackedRows.Add(row);
            attackedCols.Add(col);

        }
        private static void UnmarkAttackedFields(int row, int col)
        {
            board[row, col] = 0;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
        }
        private static bool CanPlaceQueen(int row, int col)
        {
           if (attackedRows.Contains(row))
            {
                return false;
            }
            if (attackedCols.Contains(col))
            {
                return false;
            }
            //left-up diagonal

            for ( int i = 1; i < Size; i++)
            {
                int currentRow = row - i;
                int currentCol = col - i;

                if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }
               
                    if (board[currentRow, currentCol] == 1)
                {
                    return false;
                    //ima kralica
                }
                
            }
            //right-up
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - i;
                int currentCol = col + i;

                if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }

                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                    //ima kralica
                }

            }
            //left-down
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + i;
                int currentCol = col - i;

                if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }

                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                    //ima kralica
                }

            }
            //right-down
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + i;
                int currentCol = col + i;

                if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }

                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                    //ima kralica
                }

            }
            return true;
        }
        static void Main(string[] args)
        {
            Solve(0);
        }
    }

   
}
