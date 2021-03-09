namespace CoolCollections
{
    public interface ILinkedList<T>
    {
        int Count { get; }

        T First { get; }

        T Last { get; }

        Node<T> AddFirst(T item);

        Node<T> AddLast(T item);

        Node<T> AddBefore(Node<T> node, Node<T> newNode);

        Node<T> AddAfter(Node<T> node, Node<T> newNode);

        Node<T> FindFirst(T item);

        Node<T> FindLast(T item);

        void RemoveFirst();

        void RemoveLast();

        bool Remove(T item);

        void Clear();

        bool Contains(T item);
    }
}
