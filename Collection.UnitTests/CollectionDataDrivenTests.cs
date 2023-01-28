using Collections;
using NUnit.Framework.Constraints;
using System.Globalization;

namespace Collection.UnitTests
{
    public class CollectionDataDrivenTests
    {
        [TestCase("Peter,Maria,Ivan", 0, "Peter")]
        [TestCase("Peter,Maria,Ivan", 1, "Maria")]
        [TestCase("Peter,Maria,Ivan", 2, "Ivan")]
        [TestCase("Peter", 0, "Peter")]

        public void Test_Collection_GetByValidIndex(string data, int index, string expected)
        {
            var coll = new Collection<string>(data.Split(","));
            var actual = coll[index];

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("John,Maria,Stacey", 3)]
        [TestCase("", 0)]
        [TestCase("Peter", -1)]
        [TestCase("John,Maria,Stacey", 10)]
        public void Test_Collection_GetByInvalidIndexDDT(string data, int index)
        {
            var coll = new Collection<string>(data.Split(",",
                StringSplitOptions.RemoveEmptyEntries));

            Assert.That(() => coll[index],
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCase("1,2,3,4,5", 0, 4, "[5, 2, 3, 4, 1]")]
        [TestCase("1,2,3,4,5", 4, 2, "[1, 2, 5, 4, 3]")]
        [TestCase("1,2,3,4,5", 0, 0, "[1, 2, 3, 4, 5]")]

        public void Test_Collection_ExchangeDDT(string data, int index, int index2, string expected)
        {
            var coll = new Collection<string>(data.Split(","));
            coll.Exchange(index, index2);

            Assert.That(coll.ToString(), Is.EqualTo(expected));
        }

        [TestCase("Jones, Jamie, Jack, Jules", 0, "[Jamie, Jack, Jules]")]
        [TestCase("Jones, Jamie, Jack, Jules", 2, "[Jones, Jamie, Jules]")]
        [TestCase("Jones, Jamie, Jack, Jules", 3, "[Jones, Jamie, Jack]")]
        public void Test_Collection_RemoveAtDDT(string data, int index, string expected)
        {
            var coll = new Collection<string>(data.Split(", "));
            coll.RemoveAt(index);

            Assert.That(coll.ToString(), Is.EqualTo(expected));
        }

        [TestCase("Jones, Jamie, Jack, Jules", 4)]
        [TestCase("Jones, Jamie, Jack, Jules", -2)]
        [TestCase("Jones, Jamie, Jack, Jules", 100)]
        public void Test_Collection_RemoveAtInvalidIndexDDT(string data, int index)
        {
            var coll = new Collection<string>(data.Split(", ",
                StringSplitOptions.RemoveEmptyEntries));

            Assert.That(() => coll.RemoveAt(index),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
