namespace P02.SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();
            words = words.OrderBy(w => w).ToList();
            string output = string.Join(" ", words);
            Console.WriteLine(output);
        }
    }
}
