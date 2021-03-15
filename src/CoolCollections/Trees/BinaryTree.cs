namespace CoolCollections.Trees
{
    using System;

    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public BinaryTree(T rootValue)
        {
            this.Root = new BinaryTreeNode<T>(rootValue);
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot add item with null value");
            }

            BinaryTreeNode<T> current = this.Root;

            while (current != null)
            {
                if (current.Value.CompareTo(item) > 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new BinaryTreeNode<T>(item);
                        break;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new BinaryTreeNode<T>(item);
                        break;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }
        }
    }
}
