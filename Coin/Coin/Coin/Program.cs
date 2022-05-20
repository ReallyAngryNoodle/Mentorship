using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input number:");
            var n = int.Parse(Console.ReadLine());

            var fileName = n.ToString() + ".txt";

            var power = 1;
            for (var i = 0; i < n; i++)
            {
                power *= 2;
            }

            var c = new byte[power, n];
            var t = new byte[power];

            var lastIndex = power - 1;
            var max = 0;

            for (var i = 1; i < power; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    c[i, j] = c[i - 1, j];
                }
                c[i, 0]++;
                for (var j = 0; j < n; j++)
                {
                    if (c[i, j] == 2)
                    {
                        c[i, j + 1]++;
                        c[i, j] = 0;
                    }
                }
            }

            var index = t.Length / 4;

            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(appPath, fileName);

            if (File.Exists(path))
            {
                var lastCombination = File.ReadAllText(fileName);
                var lastCombinationArray = lastCombination.Split(' ');
                for (var i = 0; i < lastCombinationArray.Length; i++)
                {
                    t[i] = byte.Parse(lastCombinationArray[i]);
                }
            }
            else
            {
                // fill 4 parts

                // 1
                for (var i = 1; i < index; i += 2)
                {
                    t[i] = (byte)(n - 1);
                    t[i + 1] = 1;
                }

                // 2
                for (var i = index; i < index * 2; i++)
                {
                    t[i] = (byte)(n - 2);
                }

                // 3
                for (var i = index * 2 + 1; i < index * 3; i += 2)
                {
                    t[i] = (byte)(n - 1);
                }
            }

            var iteration = 0;

            while (true)
            {
                var current = 0;
                for (var i = 0; i < power; i++)
                {
                    for (var j = 0; j < power; j++)
                    {
                        if (c[j, t[i]] == c[i, t[j]])
                        {
                            current++;
                        }
                    }
                }

                // write last combination into file every 1m iterations
                iteration++;
                if (iteration == 1000000)
                {
                    iteration = 0;
                    File.WriteAllText(fileName, string.Join(" ", t));
                }

                if (current > max)
                {
                    max = current;
                    Console.WriteLine($"Max: {max} of {power * power}");
                    Console.WriteLine("Tactic1:");
                    for (var i = 0; i < power; i++)
                    {
                        Console.Write($" {t[i]}");
                    }

                    File.WriteAllText(fileName, string.Join(" ", t));
                    Console.WriteLine();
                    Console.WriteLine();
                }

                if (n == 2)
                {
                    t[0]++;
                }
                else
                {
                    t[2]++;
                }

                if (n == 2)
                {
                    for (var i = 0; i < lastIndex; i++)
                    {
                        if (t[i] == n)
                        {
                            t[i + 1]++;
                            t[i] = 0;
                        }
                    }
                }
                else
                {
                    for (var i = 2; i < index; i += 2)
                    {
                        if (t[i] == n)
                        {
                            t[i + 2]++;
                            t[i] = 1;
                        }
                    }
                }

                if (t[index] == n)
                {
                    break;
                }
            }

            Console.WriteLine("End.");
            Console.ReadLine();
        }
    }
}
