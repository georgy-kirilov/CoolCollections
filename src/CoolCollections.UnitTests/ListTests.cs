namespace CoolCollections.UnitTests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ListTests
    {
        private const int ListInitialCount = 10;
        private const int FirstListItem = 1;
        private List<int> list;

        private int[] existingItems = new int[] { FirstListItem, ListInitialCount / 2, ListInitialCount };
        private int[] unexistingItems = new int[] { int.MinValue, int.MaxValue, ListInitialCount + 1 };

        [SetUp]
        public void InitializeList()
        {
            this.list = new List<int>();
            for (int i = FirstListItem; i <= ListInitialCount; i++)
            {
                list.Add(i);
            }
        }

        [Test]
        public void Add_Item_Should_IncrementCount()
        {
            int length = 5;
            for (int i = 0; i < length; i++)
            {
                this.list.Add(i);
            }

            Assert.AreEqual(ListInitialCount + length, this.list.Count);
        }

        [Test]
        public void Add_Item_Should_AddItemProperly()
        {
            int index = FirstListItem;
            foreach (int item in this.list)
            {
                Assert.AreEqual(index, item);
                index++;
            }
        }

        [Test]
        public void AddRange_Collection_Should_AddItemsProperly()
        {
            int[] collection = new int[] { 100, 200, 300, 400, 500 };
            this.list.AddRange(collection);

            for (int i = 0; i < collection.Length; i++)
            {
                int itemIndex = this.list.Count - collection.Length + i;
                Assert.IsTrue(this.list.LastIndexOf(collection[i]) == itemIndex);
            }
        }

        [Test]
        public void AddRange_Collection_Should_IncrementCount()
        {
            Random random = new Random();
            int[] collection = Enumerable.Range(random.Next(100), random.Next(100)).ToArray();
            this.list.AddRange(collection);
            Assert.AreEqual(ListInitialCount + collection.Length, this.list.Count);
        }

        [Test]
        public void GetIndexer_ValidIndex_Should_ReturnCorrectResult()
        {
            for (int i = FirstListItem; i <= ListInitialCount; i++)
            {
                Assert.AreEqual(i, this.list[i - 1]);
            }
        }

        [Test]
        public void GetIndexer_InvalidIndex_Should_ThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => { int a = this.list[int.MaxValue]; });
            Assert.Throws<IndexOutOfRangeException>(() => { int a = this.list[int.MinValue]; });
        }

        [Test]
        public void SetIndexer_ValidIndex_Should_WorkProperly()
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                this.list[i] = 0;
            }

            foreach (int item in this.list)
            {
                Assert.AreEqual(0, item);
            }
        }

        [Test]
        public void SetIndexer_InvalidIndex_Should_ThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.list[int.MaxValue] = 0);
            Assert.Throws<IndexOutOfRangeException>(() => this.list[int.MinValue] = 0);
        }

        [Test]
        public void Contains_ExistingItem_Should_ReturnTrue()
        {
            foreach (int item in this.existingItems)
            {
                Assert.IsTrue(this.list.Contains(item));
            }
        }

        [Test]
        public void Contains_UnexistingItem_Should_ReturnFalse()
        {
            foreach (int item in this.unexistingItems)
            {
                Assert.IsFalse(this.list.Contains(item));
            }
        }

        [Test]
        public void IndexOf_ExistingItem_Should_ReturnCorrectIndex()
        {
            foreach (int item in this.existingItems)
            {
                Assert.AreEqual(item - 1, this.list.IndexOf(item));
            }
        }

        [Test]
        public void IndexOf_UnexistingItem_Should_ReturnNegativeIndex()
        {
            foreach (int item in this.unexistingItems)
            {
                Assert.IsTrue(this.list.IndexOf(item) < 0);
            }
        }

        [Test]
        public void LastIndexOf_ExistingItem_Should_ReturnCorrectIndex()
        {
            foreach (int item in this.existingItems)
            {
                Assert.AreEqual(item - 1, this.list.LastIndexOf(item));
            }
        }

        [Test]
        public void LastIndexOf_UnexistingItem_Should_ReturnNegativeIndex()
        {
            foreach (int item in this.unexistingItems)
            {
                Assert.IsTrue(this.list.LastIndexOf(item) < 0);
            }
        }

        [Test]
        public void ConvertAll_Items_Should_ReturnCorrectResult()
        {
            IList<string> stringList = this.list.ConvertAll(x => (x * x).ToString());

            for (int i = 0; i < this.list.Count; i++)
            {
                string expected = (this.list[i] * this.list[i]).ToString();
                Assert.AreEqual(expected, stringList[i]);
            }

            Assert.AreEqual(this.list.Count, stringList.Count, "Both lists counts should match");
        }

        [Test]
        public void Insert_CorrectIndex_Should_IncrementCount([Values(0, ListInitialCount / 2, ListInitialCount - 1)] int index)
        {
            this.list.Insert(index, 5);
            Assert.AreEqual(ListInitialCount + 1, this.list.Count);
        }

        [Test]
        public void Insert_IncorrectIndex_Should_ThrowException([Values(int.MinValue, ListInitialCount, int.MaxValue)] int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.list.Insert(index, 5));
        }

        [Test]
        [TestCase(0, 5)]
        [TestCase(ListInitialCount / 2, 5)]
        [TestCase(ListInitialCount - 1, 5)]
        public void Insert_CorrectIndex_Should_InsertItemProperly(int index, int item)
        {
            this.list.Insert(index, item);
            for (int i = 0; i < this.list.Count; i++)
            {
                int expected = i + 1;

                if (i == index)
                {
                    expected = item;
                }
                else if (i > index)
                {
                    expected = i;
                }

                Assert.AreEqual(expected, this.list[i]);
            }
        }
    }
}
