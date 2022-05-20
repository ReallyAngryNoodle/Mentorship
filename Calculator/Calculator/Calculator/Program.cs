using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static int Main(string[] args)
        {
            var expression = string.Empty;
            Console.Write("Enter expression: ");
            expression = Console.ReadLine();

            var result = Calculate(expression);

            Console.WriteLine($"Result: {result}");
            Console.ReadLine();
            return 0;
        }

        public static int Calculate(string expression)
        {
            var arr = expression.ToCharArray();
            var index = 0;

            return Parse(arr, ref index);
        }

        public static int Parse(char[] arr, ref int index)
        {
            var stack = new Stack<int>();
            var operation = '+';

            while (index < arr.Length)
            {
                if (arr[index] != ' ')
                {
                    if (char.IsDigit(arr[index]))
                    {
                        var numberBuilder = new StringBuilder();
                        while (index < arr.Length && char.IsDigit(arr[index]))
                        {
                            numberBuilder.Append(arr[index++]);
                        }

                        index--;

                        var number = int.Parse(numberBuilder.ToString());
                        InsertElement(stack, number, operation);
                    }
                    else if (arr[index] == '(')
                    {
                        index++;
                        var curNum = Parse(arr, ref index);
                        InsertElement(stack, curNum, operation);
                    }
                    else if (arr[index] == ')')
                    {
                        break;
                    }
                    else
                    {
                        operation = arr[index];
                    }
                }

                index++;
            }

            var total = 0;

            while (stack.Count != 0)
            {
                total += stack.Pop();
            }

            return total;
        }

        private static void InsertElement(Stack<int> stack, int curNum, char op)
        {
            switch (op)
            {
                case '-':
                    curNum *= -1;
                    break;
                case '*':
                    curNum *= stack.Pop();
                    break;
                case '/':
                    curNum = stack.Pop() / curNum;
                    break;
                case '%':
                    curNum = stack.Pop() % curNum;
                    break;
                case '^':
                    curNum = Convert.ToInt32(Math.Pow(stack.Pop(), curNum));
                    break;
            }

            stack.Push(curNum);
        }
    }
}
