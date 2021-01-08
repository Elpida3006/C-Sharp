using System;

namespace Fibonacci_DynamicProgramming
{
    class Program
    {
        //  static int count;
        static int[] numbers;
        //така кеширахме реултата
        static int Fib(int n)
        {
            if (numbers[n] != 0)
            {
                return numbers[n];
            }
            //count++;
           // Console.WriteLine(count);
            if ( n == 1 || n == 2)
            {
                return 1;
            }
            // return Fib(n - 1) + Fib(n - 2);
            var result =  Fib(n - 1) + Fib(n - 2);
             numbers[n] = result;
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Fibonnacci dynamic");
            numbers = new int[100];
            Console.WriteLine(Fib(30));
           


            //задачите които са много бавни с рекусия, т.е. има много повторения, се решават с динамично оптимиране//
            //разцепва проблема на подпроблеми, като запазва и преизползва резултат, за да не се преизчислява на ново
        }
    }
}
  