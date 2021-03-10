namespace CoolCollections.Sandbox
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var list = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                list.Add(i);
            }
            list.RemoveAll(x => x % 2 != 0);
            Console.WriteLine(list[list.LastIndexOf(x => x > 20 && x < 30)]);
            Console.WriteLine(list);
        }
    }
}
