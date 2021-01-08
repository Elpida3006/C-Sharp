using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSum
{
    //without repeat
    class Program
    {
        static Dictionary<int, int>CalcSums(int[] numbers)
            {
            var result = new Dictionary<int, int>();
            result.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
              // var newSums = new Dictionary<int, int>();

                foreach (var item in result.Keys.ToList())
                {
                    var newSum = currentNumber + item;
                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, currentNumber);
                    }
                }
            }

            return result;
            }
        static void Main()
        {
            var numbers = new int[] { 3, 5, 1, 4, 2};

            var sums = CalcSums(numbers);
            var targetSum = 9;

            if (sums.ContainsKey(targetSum))
            {
                Console.WriteLine("YES");

                while(targetSum != 0)
                {
                    var number = sums[targetSum];
                    Console.Write(number);
                    targetSum -= number;
                }
            }  
            else
            {
                Console.WriteLine("NO");
            }
        }
   
    
    }
}
 