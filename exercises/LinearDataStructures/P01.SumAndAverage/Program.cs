namespace P01.SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            int sum = numbers.Sum();
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"Sum={sum}; Average={average:f2}");
        }
    }
}
