namespace CoolCollections
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IList<T>, IEnumerable<T>
    {
        private const int InitialCapacity = 2;
        private T[] array;

        public List(IEnumerable<T> collection) : this(collection.Count())
        {
            this.AddRange(collection);
        }

        public List() : this(InitialCapacity)
        {
        }

        public List(int initialCapacity)
        {
            this.array = new T[initialCapacity];
            this.Count = 0;
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

        public bool Contains(Predicate<T> match)
        {
            return this.IndexOf(match) >= 0;
        }

        public int IndexOf(T item)
        {
            return this.IndexOf(x => this.AreEqual(x, item));
        }

        public int IndexOf(Predicate<T> match)
        {
            return this.FindIndexOf(match);
        }

        public int LastIndexOf(T item)
        {
            return this.LastIndexOf(x => this.AreEqual(x, item));
        }

        public int LastIndexOf(Predicate<T> match)
        {
            return this.FindIndexOf(match, fromFirst: false);
        }

        public IList<TOut> ConvertAll<TOut>(Func<T, TOut> converter)
        {
            var convertedItems = new List<TOut>(this.Count);

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
            this.ThrowIfIndexOutOfRange(startIndex);

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Count cannot be less than zero");
            }

            var sublist = new List<T>(count);
            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (i == this.Count)
                {
                    break;
                }

                sublist.Add(this[i]);
            }

            return sublist;
        }

        public void Insert(int index, T item)
        {
            this.ThrowIfIndexOutOfRange(index, inclusive: false);

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
            return this.Remove(x => this.AreEqual(x, item));
        }

        public bool Remove(Predicate<T> match)
        {
            int index = this.IndexOf(match);

            if (index >= 0)
            {
                this.RemoveAt(index);
                return true;
            }

            return false;
        }

        public bool RemoveLast(T item)
        {
            return this.RemoveLast(x => this.AreEqual(x, item));
        }

        public bool RemoveLast(Predicate<T> match)
        {
            int index = this.LastIndexOf(match);

            if (index >= 0)
            {
                this.RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAll(T item)
        {
            this.RemoveAll(x => this.AreEqual(x, item));
        }

        public void RemoveAll(Predicate<T> match)
        {
            int index = 0;
            T[] filteredArray = new T[this.Count];

            foreach (T item in this)
            {
                if (!match(item))
                {
                    filteredArray[index] = item;
                    index++;
                }
            }

            this.array = filteredArray;
            this.Count = index;
            this.Shrink();
        }

        public T RemoveAt(int index)
        {
            this.ThrowIfIndexOutOfRange(index);
            T removedItem = this.array[index];

            for (int i = index; i < this.Count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.Count--;
            this.Shrink();
            return removedItem;
        }

        public T[] ToArray()
        {
            T[] copy = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.array[i];
            }

            return copy;
        }

        public override string ToString()
        {
            return $"[ {string.Join(", ", this)} ]";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int FindIndexOf(Predicate<T> match, bool fromFirst = true)
        {
            int offset = fromFirst ? 1 : -1;
            int index = fromFirst ? 0 : this.Count - 1;

            while (fromFirst && index < this.Count || !fromFirst && index >= 0)
            {
                if (match(this.array[index]))
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

        private void Shrink()
        {
            if (this.Count <= this.Capacity / 4)
            {
                T[] copy = new T[this.Count * 2];
                Array.Copy(this.array, copy, this.Count);
                this.array = copy;
            }
        }

        private void ThrowIfIndexOutOfRange(int index, bool inclusive = true)
        {
            if (index < 0 || inclusive && index >= this.Count || !inclusive && index > this.Count)
            {
                throw new IndexOutOfRangeException("Index was outside the list bounds");
            }
        }

        private bool AreEqual(T first, T second)
        {
            return first == null && second == null || first != null && first.Equals(second);
        }
    }
}
