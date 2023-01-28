using Collections;
using System.Globalization;

namespace Collection.UnitTests
{
    public class CollectionTests
    {
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //Arrange and Act
            var coll = new Collection<int>();

            //Assert
            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var coll = new Collection<int>(5);

            Assert.AreEqual(coll.ToString(), "[5]");
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var coll = new Collection<int>(5, 6);

            Assert.AreEqual(coll.ToString(), "[5, 6]");
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var coll = new Collection<int>(5, 6, 8);

            Assert.That(coll.Count, Is.EqualTo(3), "Check for count");
            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));
        }

        [Test]
        public void Test_Collection_Add()
        {
            var coll = new Collection<string>("Ivan", "Peter");
            coll.Add("Gosho");

            Assert.That(coll.ToString(), Is.EqualTo("[Ivan, Peter, Gosho]"));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var coll = new Collection<int>(5, 6, 7);
            var item = coll[1];
            Assert.That(item.ToString(), Is.EqualTo("6"));
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var coll = new Collection<int>(5, 6, 7);
            coll[1] = 55;
            Assert.That(coll.ToString(), Is.EqualTo("[5, 55, 7]"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var coll = new Collection<string>("Peter", "Ivan");

            Assert.That(() => { var item = coll[2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var coll = new Collection<string>("John", "Maria", "Stacey");

            Assert.That(() => { coll[100] = "Shawn"; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByNegativeInvalidIndex()
        {
            var coll = new Collection<string>("John", "Maria", "Stacey");

            Assert.That(() => { coll[-1] = "Shawn"; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var coll = new Collection<int>();
            for (int i = 0; i < 19; i++)
            {
                coll.Add(i);
            }
            Assert.That(coll.ToString(), Is.EqualTo("[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]"));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var coll = new Collection<int>(4, 7, 9);
            coll.AddRange(10, 11, 12, 13);

            Assert.That(coll.ToString, Is.EqualTo("[4, 7, 9, 10, 11, 12, 13]"));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var coll = new Collection<int>();
            var oldCapacity = coll.Capacity;
            var newColl = Enumerable.Range(1000, 2000).ToArray();

            coll.AddRange(newColl);

            Assert.That(coll.ToString, Is.EqualTo("[" + string.Join(", ", newColl) + "]"));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var coll = new Collection<double>(3.6, 7.8, 9.9);
            coll.InsertAt(0, 1.1);

            Assert.That(coll.ToString, Is.EqualTo("[1,1, 3,6, 7,8, 9,9]"));
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var coll = new Collection<char>('a', 'b', 'c', 'd');
            coll.InsertAt(2, 'm');

            Assert.That(coll.ToString, Is.EqualTo("[a, b, m, c, d]"));
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var coll = new Collection<int>(2, 4, 6, 8);
            coll.InsertAt(4, 10);

            Assert.That(coll.ToString, Is.EqualTo("[2, 4, 6, 8, 10]"));
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var coll = new Collection<int>(1, 2, 100, 101);

            Assert.That(() => { coll.InsertAt(5, 103); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ExchangeMiddle()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan");
            coll.Exchange(1, 2);

            Assert.That("[Maria, Deyan, John]", Is.EqualTo(coll.ToString()));
        }


        [Test]
        public void ExchangeFirstLast()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan", "Caroline", "Molly");
            coll.Exchange(0, 4);

            Assert.That("[Molly, John, Deyan, Caroline, Maria]", Is.EqualTo(coll.ToString()));
        }


        [Test]
        public void ExchangeInvalidIndexes()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan", "Caroline", "Molly");

            Assert.That(() => { coll.Exchange(10, 11); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void RemoveAtStart()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan", "Caroline", "Molly");
            coll.RemoveAt(0);

            Assert.That("[John, Deyan, Caroline, Molly]", Is.EqualTo(coll.ToString()));
        }

        [Test]
        public void RemoveAtEnd()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan", "Caroline", "Molly");
            coll.RemoveAt(4);

            Assert.That("[Maria, John, Deyan, Caroline]", Is.EqualTo(coll.ToString()));
        }

        [Test]
        public void RemoveAtMiddle()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan", "Caroline", "Molly");
            coll.RemoveAt(2);

            Assert.That("[Maria, John, Caroline, Molly]", Is.EqualTo(coll.ToString()));
        }
        [Test]
        public void RemoveAtInvalidIndex()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan", "Caroline", "Molly");

            Assert.That(() => { coll.RemoveAt(6); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void RemoveAll()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan", "Caroline", "Molly");
            for (int i = 0; i < 5; i++)
            {
                coll.RemoveAt(0);
            }

            Assert.That("[]", Is.EqualTo(coll.ToString()));
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var coll = new Collection<string>("Maria", "John", "Deyan", "Caroline", "Molly");
            coll.Clear();

            Assert.That("[]", Is.EqualTo(coll.ToString()));
        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var coll = new Collection<int>();

            Assert.That("[]", Is.EqualTo(coll.ToString()));
        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            var coll = new Collection<int>(65);

            Assert.That("[65]", Is.EqualTo(coll.ToString()));
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            var coll = new Collection<int>(65, 66, 89, 99, 100);

            Assert.That("[65, 66, 89, 99, 100]", Is.EqualTo(coll.ToString()));
        }

        [Test]
        public void Test_Collection_ToStringNested()
        {
            var names = new Collection<string>("Maria", "Dinko");
            var nums = new Collection<int>(1, 2, 3);
            var dates = new Collection<DateTime>();

            var nested = new Collection<object>(nums, dates, names);
            String nestedToString = nested.ToString();

            Assert.That(nestedToString,
                Is.EqualTo("[[1, 2, 3], [], [Maria, Dinko]]"));
        }

        [Test]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var coll = new Collection<int>();
            coll.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            Assert.That(coll.Capacity >= coll.Count);
            Assert.That(coll.Count == itemsCount);
            for (int i=itemsCount-1; i>=0; i--)
            {
                coll.RemoveAt(i);
            }
            Assert.That(coll.ToString() == "[]");
            Assert.That(coll.Capacity >= coll.Count);

        }
    }
}