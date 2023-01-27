using Collections;
using System.Globalization;

namespace Collection.UnitTests
{
    public class CollectionDataDrivenTests
    {
       [TestCase("Peter,Maria,Ivan",0,"Peter")]
       [TestCase("Peter,Maria,Ivan", 1, "Maria")]
       [TestCase("Peter,Maria,Ivan", 2, "Ivan")]
       [TestCase("Peter", 0, "Peter")]

        public void Test_Collection_GetByValidIndex(string data, int index, string expected)
        {
            var coll = new Collection<string>(data.Split(","));
            var actual = coll[index];

            Assert.That(actual, Is.EqualTo(expected));    
        }

    }
}
