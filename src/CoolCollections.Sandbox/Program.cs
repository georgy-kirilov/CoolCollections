namespace CoolCollections.Sandbox
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var list = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }
            Console.WriteLine(list.GetRange(0, 1));
        }
    }
}
