namespace CoolCollections
{
    using System;
    using System.Collections.Generic;

    public interface IList<T>
    {
        public T this[int index] { get; set; }

        public int Count { get; }

        public int Capacity { get; }

        void Add(T item);

        void AddRange(IEnumerable<T> collection);

        void Clear();

        bool Contains(T item);

        bool Contains(Predicate<T> match);

        int IndexOf(T item);

        int IndexOf(Predicate<T> match);

        int LastIndexOf(T item);

        int LastIndexOf(Predicate<T> match);

        IList<TOut> ConvertAll<TOut>(Func<T, TOut> converter);

        IEnumerator<T> GetEnumerator();

        IList<T> GetRange(int startIndex, int count);

        void Insert(int index, T item);

        void InsertRange(int index, IEnumerable<T> collection);
        bool Remove(T item);

        bool Remove(Predicate<T> match);

        bool RemoveLast(T item);

        bool RemoveLast(Predicate<T> match);

        void RemoveAll(T item);

        void RemoveAll(Predicate<T> match);

        T RemoveAt(int index);

        void RemoveRange(int index, int count);

        T[] ToArray();
    }
}
