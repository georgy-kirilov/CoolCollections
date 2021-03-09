namespace CoolCollections
{
    using System;
    using System.Collections.Generic;

    public interface IList<T>
    {
        int Count { get; }

        int Capacity { get; }

        T this[int index] { get; set; }

        void Add(T item);

        void AddRange(IEnumerable<T> collection);

        void Insert(int index, T item);

        void InsertRange(int index, IEnumerable<T> collection);

        int IndexOf(T item);

        int LastIndexOf(T item);

        bool Contains(T item);

        bool Remove(T item);

        T RemoveAt(int index);

        void RemoveAll(T item);

        void RemoveRange(int index, int count);

        void Clear();

        IList<TOut> ConvertAll<TOut>(Func<T, TOut> converter);

        IList<T> GetRange(int startIndex, int count);
    }
}
