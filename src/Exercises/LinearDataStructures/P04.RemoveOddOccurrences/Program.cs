namespace P04.RemoveOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var numbersOccurencesPairs = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!numbersOccurencesPairs.ContainsKey(numbers[i]))
                {
                    numbersOccurencesPairs.Add(numbers[i], 0);
                }
                numbersOccurencesPairs[numbers[i]]++;
            }

            numbersOccurencesPairs = numbersOccurencesPairs.Where(p => p.Value % 2 != 0).ToDictionary(p => p.Key, p => p.Value);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbersOccurencesPairs.ContainsKey(numbers[i]))
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
