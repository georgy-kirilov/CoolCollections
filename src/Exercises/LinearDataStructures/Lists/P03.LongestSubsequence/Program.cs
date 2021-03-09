namespace P03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            numbers = FindLongestSubsequence(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        public static List<T> FindLongestSubsequence<T>(List<T> sequence)
        {
            if (sequence.Count == 0)
            {
                return null;
            }

            var currentSubsequence = new List<T>() { sequence[0] };
            var longestSubsequence = new List<T>() { sequence[0] };

            for (int i = 1; i < sequence.Count; i++)
            {
                if (!sequence[i].Equals(sequence[i - 1]))
                {
                    if (currentSubsequence.Count > longestSubsequence.Count)
                    {
                        longestSubsequence = currentSubsequence.ToList();
                    }

                    currentSubsequence.Clear();
                    currentSubsequence.Add(sequence[i]);
                }
                else
                {
                    currentSubsequence.Add(sequence[i]);
                }
            }

            if (currentSubsequence.Count > longestSubsequence.Count)
            {
                longestSubsequence = currentSubsequence.ToList();
            }

            return longestSubsequence;
        }
    }
}
