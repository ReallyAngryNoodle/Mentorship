using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static int Main(string[] args)
        {
            int n = 0, m = 0;
            int startN = 0, startM = 0;

            Console.Write("Enter n: ");
            n = int.Parse(Console.ReadLine());
            startN = n;

            Console.Write("Enter m: ");
            m = int.Parse(Console.ReadLine());
            startM = m;

            var matrix = new int[m, n];

            var manual = string.Empty;

            Console.Write("Enter \"manual\" if you want to fill matrix manually: ");
            manual = Console.ReadLine();

            // fill matrix

            if (manual == "manual")
            {
                for (var i = 0; i < m; i++)
                {
                    for (var j = 0; j < n; j++)
                    {
                        Console.Write($"Enter position i = {i + 1}, j = {j + 1}: ");
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
            else
            {
                var rnd = new Random();

                for (var i = 0; i < m; i++)
                {
                    for (var j = 0; j < n; j++)
                    {
                        matrix[i, j] = rnd.Next(50);
                    }
                }
            }

            // show matrix
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // circle walkthrough
            int row = 0, column = 0;  // row = k (m), column = l (n)
            var output = 0;

            while (row < m && column < n)
            {
                // top row →
                Console.Write("→\t" );
                for (var i = column; i < n; ++i)
                {
                    Console.Write(matrix[row, i] + "\t");
                    output++;
                }

                if (output >= startM * startN)
                {
                    break;
                }

                row++;
                Console.WriteLine();

                // right column ↓
                Console.Write("↓\t");
                for (var i = row; i < m; ++i)
                {
                    Console.Write(matrix[i, n - 1] + "\t");
                    output++;
                }
                n--;

                if (output >= startM * startN)
                {
                    break;
                }

                Console.WriteLine();

                // bottom row ←
                Console.Write("←\t");
                if (row < m)
                {
                    for (var i = n - 1; i >= column; --i)
                    {
                        Console.Write(matrix[m - 1, i] + "\t");
                        output++;
                    }
                    m--;
                }

                if (output >= startM * startN)
                {
                    break;
                }

                Console.WriteLine();

                // left row ↑
                Console.Write("↑\t");
                if (column < n)
                {
                    for (var i = m - 1; i >= row; --i)
                    {
                        Console.Write(matrix[i, column] + "\t");
                        output++;
                    }
                    column++;
                }

                if (output >= startM * startN)
                {
                    break;
                }

                Console.WriteLine();
            }

            Console.ReadLine();
            return 0;
        }
    }
}
