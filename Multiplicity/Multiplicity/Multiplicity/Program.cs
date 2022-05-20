using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplicity
{
    class Program
    {
        static int Main(string[] args)
        {
            int maxNumber;

            Console.Write("Enter max number: ");
            maxNumber = int.Parse(Console.ReadLine());

            int total = 0;

            for (int i = 2; i < maxNumber; i++)
            {
                if ((i % 2 == 0) && (i % 5 == 0))
                {
                    i++;
                }

                if ((i % 2 == 0) || (i % 5 == 0))
                {
                    total++;
                    Console.WriteLine(i + " | ");
                }
            }

            Console.WriteLine("Total numbers: " + total);
            Console.ReadLine();
            return 0;
        }
    }
}
