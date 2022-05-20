using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSubsequenceSum
{
    class Program
    {
        static int Main(string[] args)
        {
            var sequenceString = string.Empty;

            Console.Write("Enter sequence:");
            sequenceString = Console.ReadLine();

            var splitSequence = sequenceString.Split(' ');

            var sequence = new int[splitSequence.Length];

            for (var i = 0; i < splitSequence.Length; i++)
            {
                sequence[i] = int.Parse(splitSequence[i]);
            }

            var maxStartIndex = 0;
            var maxLength = 1;
            var maxSum = sequence[0];

            int length;

            for (var i = 0; i < sequence.Length; i++)
            {
                length = 1;

                while (i + length <= sequence.Length)
                {
                    var sum = SumSubsequence(length, i, sequence);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxLength = length;
                        maxStartIndex = i;
                    }

                    length++;
                }
            }

            Console.WriteLine("Sequence:");
            for (var i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i] + "\t");
            }

            Console.WriteLine();
            Console.WriteLine($"Subsequence start index: {maxStartIndex}");
            Console.WriteLine($"Subsequence length: {maxLength}");
            Console.WriteLine($"Sum is: {maxSum}");
            Console.WriteLine("Max subsequence is:");
            ShowSubsequence(maxLength, maxStartIndex, sequence);

            Console.ReadLine();
            return 0;
        }

        static int SumSubsequence(int length, int startIndex, int[] sequence)
        {
            var sum = 0;

            for (var i = startIndex; i < startIndex + length; i++)
            {
                sum += sequence[i];
            }

            return sum;
        }

        static void ShowSubsequence(int length, int startIndex, int[] sequence)
        {
            for (var i = startIndex; i < startIndex + length; i++)
            {
                Console.Write(sequence[i] + "\t");
            }
        }
    }
}
