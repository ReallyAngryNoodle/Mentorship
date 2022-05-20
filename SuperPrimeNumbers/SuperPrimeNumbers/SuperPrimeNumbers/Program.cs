using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPrimeNumbers
{
    class Program
    {
        static int Main(string[] args)
        {
            var numberOfSuperPrime = 0;
            Console.Write("Enter super prime number position: ");
            numberOfSuperPrime = int.Parse(Console.ReadLine());

            if (numberOfSuperPrime <= 0)
            {
                Console.WriteLine("Stop it, get some help");
                Console.ReadLine();

                return 1;
            }

            var primeCount = 0;
            var superPrimeCount = 0;

            var i = 2;

            while (true)
            {
                if (CheckIfPrimeNumber(i))
                {
                    Console.Write($"Prime number: {i}");

                    primeCount++;

                    if (CheckIfPrimeNumber(primeCount))
                    {
                        superPrimeCount++;

                        Console.Write($", is {superPrimeCount} super prime");

                        if (superPrimeCount == numberOfSuperPrime)
                        {
                            Console.WriteLine();
                            Console.WriteLine("====================================");
                            Console.WriteLine($"Selected super prime number: {i}");
                            break;
                        }
                    }

                    Console.WriteLine();
                }

                i++;
            }

            Console.ReadLine();
            return 0;
        }

        static bool CheckIfPrimeNumber(int num)
        {
            if (num < 2 || num % 2 == 0)
            {
                return false;
            }

            if (num == 2)
            {
                return true;
            }

            int n = num / 2;

            for (var i = 3; i <= n + 2; i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
