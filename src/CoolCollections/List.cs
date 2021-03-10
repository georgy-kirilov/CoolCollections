namespace CoolCollections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IList<T>, IEnumerable<T>
    {
        private const int InitialCapacity = 2;
        private T[] array;

        public List() : this(InitialCapacity)
        {
        }

        public List(int initialCapacity)
        {
            this.array = new T[initialCapacity];
            this.Count = 0;
        }

        public List(IEnumerable<T> collection) : this()
        {
            this.AddRange(collection);
        }

        public T this[int index]
        { 
            get
            {
                this.ThrowIfIndexOutOfRange(index);
                return this.array[index];
            }
            set
            {
                this.ThrowIfIndexOutOfRange(index);
                this.array[index] = value;
            }
        }

        public int Count { get; private set; }

        public int Capacity => this.array.Length;

        public void Add(T item)
        {
            if (this.Count >= this.Capacity)
            {
                this.Expand();
            }
            this.array[this.Count] = item;
            this.Count++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this.array = new T[InitialCapacity];
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) >= 0;
        }

        public IList<TOut> ConvertAll<TOut>(Func<T, TOut> converter)
        {
            IList<TOut> convertedItems = new List<TOut>(this.Count);
            foreach (T item in this)
            {
                convertedItems.Add(converter(item));
            }
            return convertedItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        public IList<T> GetRange(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            return this.IndexOf(item, true);
        }

        public int LastIndexOf(T item)
        {
            return this.IndexOf(item, false);
        }

        public void Insert(int index, T item)
        {
            this.ThrowIfIndexOutOfRange(index);

            if (this.Count >= this.Capacity)
            {
                this.Expand();
            }

            for (int i = this.Count; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[index] = item;
            this.Count++;
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                this.Insert(index, item);
            }
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAll(T item)
        {
            throw new System.NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveRange(int index, int count)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int IndexOf(T item, bool fromFirst)
        {
            int offset = fromFirst ? 1 : -1;
            int index = fromFirst ? 0 : this.Count - 1;
            while (fromFirst && index < this.Count || !fromFirst && index >= 0)
            {
                T current = this.array[index];
                bool itemIndexFound = current == null && item == null || current != null && current.Equals(item);
                if (itemIndexFound)
                {
                    return index;
                }
                index += offset;
            }
            return -1;
        }

        private void Expand()
        {
            T[] copy = new T[this.Capacity * 2];
            for (int i = 0; i < this.Capacity; i++)
            {
                copy[i] = this.array[i];
            }
            this.array = copy;
        }

        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index cannot be negative or greater than the list count");
            }
        }
    }
}
