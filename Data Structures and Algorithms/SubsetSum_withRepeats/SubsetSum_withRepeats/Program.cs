using System;

namespace SubsetSum_withRepeats
{
    class Program
    {
        static void Main()
        {
            var numbers = new[] { 3, 5, 2 };
            var targetSum = 8;
            var possiblesums = new bool[targetSum + 1];
            possiblesums[0] = true;

            for (int sum = 0; sum < possiblesums.Length; sum++)
            {
                if(possiblesums[sum])
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        var newSum = sum + numbers[i];
                        if(newSum <= targetSum)
                        possiblesums[newSum] = true;
                    }
                }
            }
            while(targetSum != 0)
            {
                for(int i = 0; i < numbers.Length; i++)
                {
                    var sum = targetSum - numbers[i];
                    if (sum >= 0 && possiblesums[sum])
                    {
                        Console.Write(numbers[i] + " ");
                        targetSum = sum;
                    }
                }
            }
            Console.WriteLine(possiblesums[targetSum]);
        }
    }
}
