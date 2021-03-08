namespace P05.CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] occurences = new int[1001];
            var list = new List<int>();

            foreach (int item in array)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
                occurences[item]++;
            }

            list = list.OrderBy(x => x).ToList();

            foreach (int item in list)
            {
                Console.WriteLine($"{item} -> {occurences[item]} times");
            }
        }
    }
}
