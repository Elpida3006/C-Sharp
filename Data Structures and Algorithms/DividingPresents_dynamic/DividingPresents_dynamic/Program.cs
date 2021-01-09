using System;
using System.Linq;
//blizka do SUBSETSUM

namespace DividingPresents_dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var totalSum = presents.Sum();
            var sums = new int[totalSum + 1];

            for (int i = 1; i < sums.Length; i++)
            {
                sums[i] = -1;
            }
            for (int presIndex = 0; presIndex < presents.Length; presIndex++)
            {
                for (int prevSumIndex = totalSum - presents[presIndex]; prevSumIndex >= 0; prevSumIndex--)
                {
                    if (sums[prevSumIndex] != -1 && sums[prevSumIndex + presents[presIndex]] == -1)
                    {
                        sums[prevSumIndex + presents[presIndex]] = presIndex;
                    }
                }
            }
            var half = totalSum / 2;
            for (int i = half; i >= 0; i--)
            {
                if (sums[i] == -1)
                {
                    continue;
                }
                Console.WriteLine($"Difference: {totalSum - i - i}");
                Console.WriteLine($"Alan:{i} Bob:{totalSum - i}");
                Console.Write($"Alan takes:");

                while(i != 0)
                {
                    Console.Write($" {presents[sums[i]]}");
                    i -= presents[sums[i]];
                }

                Console.WriteLine();
                Console.WriteLine("Bob takes the rest.");

            }
        }
    }
}
