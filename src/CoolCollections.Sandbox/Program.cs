namespace CoolCollections.Sandbox
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var list = new SortedList<int>(ascendingOrder: true);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(3);
            list.Add(5);
            list.Add(1);
            list.AscendingOrder = false;
            Console.WriteLine(list.Contains(0));
            
        }
    }
}
