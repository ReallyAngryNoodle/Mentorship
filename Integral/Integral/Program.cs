using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    class Program
    {
        private const double EXP = 0.0001;

        static void Main(string[] args)
        {
            double start;
            double end;
            string polinom;

            Console.Write("Start: ");
            start = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("End: ");
            end = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Function: ");
            polinom = Console.ReadLine();

            var result = ParseFunction(polinom, start, end);

            Console.Write(result);
            Console.ReadLine();
        }

        public static int GetMaxPower(string func)
        {
            int max = 0;
            string maxString = "";
            string temp;

            bool flag = func.Contains('^');

            if (flag)
            {
                for (int i = 0; i < func.Length; i++)
                {
                    if (func[i] == '^')
                    {
                        temp = "";

                        for (int j = i + 1; j < func.Length; j++)
                        {
                            if (func[j] == '+' || func[j] == '-')
                            {
                                break;
                            }

                            temp += func[j];
                        }

                        int index = Int32.Parse(temp);
                        if (max < index)
                        {
                            max = index;
                        }
                    }
                }
            }
            else
            {
                max = func.Contains('x') ? 1 : 0;
            }

            return max;
        }

        public static double ParseFunction(string func, double start, double end)
        {
            var maxPower = GetMaxPower(func);
            var constants = new int[maxPower + 1];

            var splitByPlus = func.Split('+');

            // parse values
            foreach (var part in splitByPlus)
            {
                var splitByMinus = part.Split('-');

                if (splitByMinus.Length > 1)
                {
                    var first = splitByMinus[0].Split('x');
                    int constanta, power;

                    // parse power
                    var powerToParse = string.IsNullOrEmpty(first[1]) ? "1" : first[1].Remove(0, 1);
                    if (!int.TryParse(powerToParse, out power))
                    {
                        power = 1;
                    }

                    // parse constant
                    if (int.TryParse(first[0], out constanta))
                    {
                        constants[power] = constanta;
                    }
                    else
                    {
                        constants[1] = 1;
                    }

                    var second = splitByMinus[1].Split('x');

                    // parse power
                    powerToParse = string.IsNullOrEmpty(second[1]) ? "1" : second[1].Remove(0, 1);
                    if (!int.TryParse(powerToParse, out power))
                    {
                        power = 1;
                    }

                    // parse constant
                    var constantToParse = second[0].Insert(0, "-");
                    if (int.TryParse(constantToParse, out constanta))
                    {
                        constants[power] = constanta;
                    }
                    else
                    {
                        constants[1] = 1;
                    }
                }
                else
                {
                    constants[0] = int.Parse(splitByMinus[0]);
                }
            }

            var rezRight = RightRecktangles(constants, start, end);
            var rezLeft = LeftRecktangles(constants, start, end);

            Console.WriteLine("Right:" + rezRight);
            Console.WriteLine("Left:" + rezLeft);

            return (rezLeft + rezRight) / 2;
        }

        static double LeftRecktangles(int[] constants, double start, double end)
        {
            var result = .0;

            for (var i = start; i < end; i += EXP)
            {
                result += CalculateAxisY(i, constants) * EXP;
            }

            return result;
        }

        static double RightRecktangles(int[] constants, double start, double end)
        {
            var result = .0;

            for (var i = end; i > start; i -= EXP)
            {
                result += CalculateAxisY(i, constants) * EXP;
            }

            return result;
        }

        static double CalculateAxisY(double x, int[] constants)
        {
            var rez = .0;

            for (int i = 0; i < constants.Length; i++)
            {
                rez += constants[i] * Math.Pow(x, i);
            }

            return rez;
        }

    }
}
