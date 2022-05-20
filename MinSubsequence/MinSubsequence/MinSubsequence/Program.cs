using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinSubsequence
{
    class Program
    {
        static int Main(string[] args)
        {
            var sequenceString = string.Empty;
            Console.Write("Enter sequence: ");
            sequenceString = Console.ReadLine();

            var sequenceStringArray = sequenceString.Split(' ');
            var sequence = new int[sequenceStringArray.Length];

            for (var i = 0; i < sequence.Length; i++)
            {
                sequence[i] = int.Parse(sequenceStringArray[i]);
            }

            var length = sequence.Length;
            var minLength = sequence.Length;

            while (length > 0)
            {
                var subsequence = new int[length];

                for (var i = 0; i < subsequence.Length; i++)
                {
                    subsequence[i] = sequence[i];
                }

                var isSubsequence = true;
                var index = 0;

                for (var i = 0; i < sequence.Length; i++)
                {
                    if (index == subsequence.Length)
                    {
                        index = 0;
                    }

                    if (sequence[i] != subsequence[index])
                    {
                        isSubsequence = false;
                        break;
                    }

                    index++;
                }

                if (isSubsequence)
                {
                    if (length < minLength)
                    {
                        minLength = length;
                    }
                }

                length--;
            }

            var minSubsequence = string.Empty;

            for (var i = 0; i < minLength; i++)
            {
                minSubsequence += sequence[i];
                minSubsequence += " ";
            }

            Console.WriteLine("================================");
            Console.WriteLine($"Min subsequence: {minSubsequence}");
            Console.WriteLine($"Min subsequence length: {minLength}");

            Console.ReadLine();
            return 0;
        }
    }
}
