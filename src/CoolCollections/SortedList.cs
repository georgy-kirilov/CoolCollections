namespace CoolCollections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SortedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        public const int InitialCapacity = 4;

        private T[] data;
        private bool ascendingOrder;

        public SortedList(int initialCapacity)
        {
            this.data = new T[initialCapacity];
            this.Count = 0;
        }

        public SortedList(bool ascendingOrder = true) : this(InitialCapacity)
        {
            this.AscendingOrder = ascendingOrder;
        }

        public int Count { get; private set; }

        public bool AscendingOrder
        {
            get => this.ascendingOrder;

            set
            {
                if (this.ascendingOrder != value)
                {
                    this.Reverse();
                    this.ascendingOrder = value;
                }
            }
        }

        public int Capacity => this.data.Length;

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item with null value cannot be added");
            }

            if (this.Count >= this.Capacity)
            {
                this.Expand();
            }

            int itemInsertionIndex = this.Count;

            for (int index = 0; index < this.Count; index++)
            {
                int comparisonResult = this.data[index].CompareTo(item);
                bool insertionPossible = this.AscendingOrder && comparisonResult > 0 || !this.AscendingOrder && comparisonResult < 0;

                if (insertionPossible)
                {
                    itemInsertionIndex = index;

                    for (int i = this.Count; i > index; i--)
                    {
                        this.data[i] = this.data[i - 1];
                    }

                    break;
                }
            }

            this.data[itemInsertionIndex] = item;
            this.Count++;
        }

        public int IndexOf(T item)
        {
            int min = 0;
            int max = this.Count - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                int comparisonResult = item.CompareTo(this.data[mid]);

                if (comparisonResult == 0)
                {
                    return mid;
                }
                else if (this.AscendingOrder && comparisonResult < 0 || !this.AscendingOrder && comparisonResult > 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return -1;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) >= 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.data[i];
            }
        }

        public override string ToString()
        {
            return $"[ {string.Join(", ", this)} ]";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Expand()
        {
            T[] temp = this.data;
            this.data = new T[this.Capacity * 2];

            for (int i = 0; i < temp.Length; i++)
            {
                this.data[i] = temp[i];
            }
        }

        private void Reverse()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                int endIndex = this.Count - 1 - i;
                T temp = this.data[i];
                this.data[i] = this.data[endIndex];
                this.data[endIndex] = temp;
            }
        }
    }
}
