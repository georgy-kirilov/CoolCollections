namespace P01.ReverseNumbersWithStack
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            string output = string.Join(" ", numbers);
            output = output.Length == 0 ? "(empty)" : output;
            Console.WriteLine(output);
        }
    }
}
