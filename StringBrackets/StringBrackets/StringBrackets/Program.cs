using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBrackets
{
    class Program
    {
        static int Main(string[] args)
        {
            var expression = string.Empty;

            Console.Write("Enter expression: ");
            expression = Console.ReadLine();

            var length = 0;

            for (var i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(' || expression[i] == ')' || expression[i] == '[' || expression[i] == ']')
                {
                    length++;
                }
            }

            var arr = new int[length];
            var bracketsString = string.Empty;
            var index = 0;

            for (var i = 0; i < arr.Length; index++)
            {
                if (expression[index] == '(')
                {
                    bracketsString += expression[index];
                    arr[i] = 1;
                    i++;
                }

                if (expression[index] == ')')
                {
                    bracketsString += expression[index];
                    arr[i] = -1;
                    i++;
                }

                if (expression[index] == '[')
                {
                    bracketsString += expression[index];
                    arr[i] = 2;
                    i++;
                }

                if (expression[index] == ']')
                {
                    bracketsString += expression[index];
                    arr[i] = -2;
                    i++;
                }
            }

            // check if equal amount of opening and closing brackets of the same type
            if (arr.Sum() != 0)
            {
                Console.WriteLine("Incorrect brackets placement");

                Console.ReadLine();
                return 1;
            }

            // check if any brackets
            if (arr.Sum() == 0 && length <= 0)
            {
                Console.WriteLine("No brackets");

                Console.ReadLine();
                return 1;
            }

            // check if first element is incorrect
            if (arr[0] < 0)
            {
                Console.WriteLine("Incorrect brackets placement");

                Console.ReadLine();
                return 1;
            }

            var startBracketIndex = 0;
            var endBracketIndex = 1;
            var noChangesMade = 0;

            while (bracketsString.Length > 0)
            {
                if (bracketsString[startBracketIndex] == '(' || bracketsString[startBracketIndex] == '[')
                {
                    if (IsOppositeBracket(bracketsString[startBracketIndex], bracketsString[endBracketIndex]))
                    {
                        bracketsString = bracketsString.Remove(startBracketIndex, 1);
                        bracketsString = bracketsString.Remove(startBracketIndex, 1);
                        startBracketIndex = 0;
                        endBracketIndex = 1;
                        noChangesMade = 0;
                        continue;
                    }

                    if (noChangesMade > bracketsString.Length / 2)
                    {
                        Console.WriteLine("Incorrect brackets placement");

                        Console.ReadLine();
                        return 1;
                    }

                    startBracketIndex++;
                    endBracketIndex++;
                }
            }

            Console.WriteLine("Correct brackets placement");
            Console.ReadLine();
            return 0;
        }

        public static bool IsOppositeBracket(char bracket1, char bracket2)
        {
            if (bracket1 == '(' && bracket2 == ')')
            {
                return true;
            }

            if (bracket1 == '[' && bracket2 == ']')
            {
                return true;
            }

            return false;
        }
    }
}
