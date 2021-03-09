namespace CoolCollections
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public Node(T value, Node<T> next) : this(value)
        {
            this.Next = next;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}
