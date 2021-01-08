using System;
using System.Collections.Generic;

namespace LCS_Dynamic_
{
    class Program
    {
        static void Main()
        {
            var first = "GCGCAATG";
            var second = "GCCCTAGCG";
            

            var lcsMatrix = new int[first.Length + 1, second.Length + 1];

         for (int row = 1; row <= first.Length; row++)
            {
                for (int col = 1; col <= second.Length; col++)
                {
                    var up = lcsMatrix[row - 1, col];
                    var left = lcsMatrix[row, col - 1];

                    var resultMax = Math.Max(up, left);

                    if(first[row - 1] == second[col - 1])
                    {
                        resultMax = Math.Max(1 + lcsMatrix[row - 1, col - 1], resultMax);
                    }
                    lcsMatrix[row, col] = resultMax;
                }
            }
           for (int i = 0; i < lcsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < lcsMatrix.GetLength(1); j++)
                {
                    Console.Write(lcsMatrix[i, j] + " ");
                }
            }
           Console.WriteLine(lcsMatrix[first.Length, second.Length]);

            var currentRow = first.Length;
            var currentCol = second.Length;

            var finish = new List<char>();

            while (currentRow > 0 && currentCol > 0)
            {
                if (first[currentRow - 1] == second[currentCol - 1])
                {
                    finish.Add(first[currentRow - 1]);
                    currentRow--;
                    currentCol--;
                }
                else if(lcsMatrix[currentRow - 1, currentCol] == lcsMatrix[currentRow, currentCol])
                {
                    currentRow--;
                }
                else
                {
                    currentCol--;
                }

            }

            finish.Reverse();
            Console.WriteLine(string.Join(" ", finish));
        }
    }
}
