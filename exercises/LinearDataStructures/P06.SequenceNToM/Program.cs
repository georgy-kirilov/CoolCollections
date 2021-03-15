namespace P06.SequenceNToM
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();
            int start = 3, end = 10;
            queue.Enqueue(start);

            var stack = new Stack<int>();

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current < end)
                {
                    queue.Enqueue(current + 1);
                    queue.Enqueue(current + 2);
                    queue.Enqueue(current * 2);
                }
                else if (current == end)
                {
                    Console.WriteLine("Solution");
                }
            }
        }

        static Queue<int> queue = new Queue<int>();

        public static void Solve(int current, int end)
        {
            if (current >= end)
            {
                Console.WriteLine();
                return;
            }

            Console.Write(current);

            queue.Enqueue(current + 1);
            queue.Enqueue(current + 2);
            queue.Enqueue(current * 2);

        }
    }
}
