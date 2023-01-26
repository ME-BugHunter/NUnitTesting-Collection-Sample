using Collections;

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
    }
}