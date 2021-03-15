namespace CoolCollections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SortedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        public const int InitialCapacity = 4;

        private T[] data;

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

        public bool AscendingOrder { get; set; }

        public int Capacity => this.data.Length;

        public void Add(T item)
        {
            if (item == null)
            {
                throw new NullReferenceException("Item with null value cannot be added");
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

        public void Expand()
        {
            T[] temp = this.data;
            this.data = new T[this.Capacity * 2];

            for (int i = 0; i < temp.Length; i++)
            {
                this.data[i] = temp[i];
            }
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
    }
}
