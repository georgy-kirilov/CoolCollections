namespace P02.CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            int number = int.Parse(Console.ReadLine());
            int index = 1;
            int[] result = new int[50];
            result[0] = number;

            for (int i = 1; i < result.Length; i++)
            {
                int sum = number + 1;

                if (index == 2)
                {
                    sum = 2 * number + 1;
                }
                else if (index == 3)
                {
                    sum = number + 2;
                }

                if (index > 3)
                {
                    index = 0;
                    number = queue.Dequeue();
                    i--;
                }
                else
                {
                    queue.Enqueue(sum);
                    result[i] = sum;
                }
                
                index++;
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
