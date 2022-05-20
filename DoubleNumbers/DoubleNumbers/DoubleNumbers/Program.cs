using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleNumbers
{
    class Program
    {
        static int Main(string[] args)
        {
            var numbersLine = string.Empty;
            Console.Write("Enter numbers: ");
            numbersLine = Console.ReadLine();

            var splitNumbersLine = numbersLine.Split(' ');
            var numbers = new int?[splitNumbersLine.Length];

            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(splitNumbersLine[i]);
            }

            for (var i = 0; i < numbers.Length; i++)
            {
                var unique = true;

                for (var j = numbers.Length - 1; j > i; j--)
                {
                    if (numbers[i] == numbers[j])
                    {
                        unique = false;
                        numbers[j] = null;
                    }
                }

                if (!unique)
                {
                    numbers[i] = null;
                }
            }

            Console.Write("Unique: ");

            var hasUnique = false;

            foreach (var number in numbers)
            {
                if (number != null)
                {
                    Console.Write(number + "\t");

                    hasUnique = true;
                }
            }

            if (!hasUnique)
            {
                Console.Write("not found");
            }

            Console.ReadLine();
            return 0;
        }
    }
}
