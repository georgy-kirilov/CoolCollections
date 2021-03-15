namespace CoolCollections.Sandbox
{
    using CoolCollections.Trees;
    using System;

    public class Program
    {
        public static void Main()
        {
            var tree = new BinaryTree<int>(10);
            tree.Add(7);
            tree.Add(4);
            tree.Add(8);
            tree.Add(12);
            tree.Add(11);
            tree.Add(13);
            tree.Add(13);
            tree.Add(15);
            Console.WriteLine();
        }
    }
}
