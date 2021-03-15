namespace CoolCollections.Trees
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right) : this(value)
        {
            this.Left = left;
            this.Right = right;
        }

        public T Value { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }
    }
}
