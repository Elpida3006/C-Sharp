using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDown_RightSum_Dynamic
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var columns = int.Parse(Console.ReadLine());

            var numbers = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    numbers[i, j] = int.Parse(line[j]);
                    //line[j] - '0'; kastwame kam chislo
                }
            }
            var sums = new int[rows, columns];
            sums[0, 0] = numbers[0, 0];

            for (int row = 1; row < rows; row++)
            {
                sums[rows, 0] = sums[row - 1, 0] + numbers[row, 0];

            }
            for (int col = 1; col < columns; col++)
            {
                sums[0, col] = sums[0, col - 1] + numbers[0, col];

            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < columns; col++)
                {

                    var result = Math.Max(
                        sums[row - 1, col],
                        sums[row, col - 1]) + numbers[row, col];

                    sums[row, col] = result;

                }
            }
            Console.WriteLine(sums[rows - 1, columns - 1]);

            var resultPath = new List<string>();

            resultPath.Add($"[{rows - 1}, {columns - 1}]");

            var currentRow = rows - 1;
            var currentColumn = columns - 1;

            while (currentRow != 0 || currentColumn != 0)
            {
                var top = -1;
                if (currentRow - 1 >= 0)
                {
                    top = sums[currentRow - 1, currentColumn];
                }

                var left = -1;
                if (currentColumn - 1 >= 0)
                {
                    left = sums[currentRow, currentColumn - 1];
                }

                if (top > left)
                {
                    resultPath.Add($"[{currentRow - 1}, {currentColumn}]");
                    currentRow -= 1;

                }
                else
                {
                    resultPath.Add($"[{currentRow }, {currentColumn - 1}]");
                    currentColumn -= 1;
                }
            }
            resultPath.Reverse();
            Console.WriteLine(string.Join(" ", resultPath));

        }
    }
}
