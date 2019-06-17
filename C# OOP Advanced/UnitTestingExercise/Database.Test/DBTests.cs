namespace Database.Test
{
    using NUnit.Framework;
    using System;
    using DatabaseExample;
    using System.Reflection;
    using System.Linq;

    [TestFixture]
    public class DBTests
    {
        private const int ArraySize = 16;
        private const int InitialArrayIndex = -1;

        [Test]
        public void EmptyConstructorShouldInitData()
        {
            //Arrange
            Database db = new Database();

            //Act
            Type type = typeof(Database);
            var fields = (int[])type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "data")
                .GetValue(db);

            var length = fields.Length;

            //Assert
            Assert.That(length, Is.EqualTo(ArraySize));
        }

        [Test]
        public void EmptyConstructorShouldInitIndexToMinusOne()
        {
            //Arrange
            Database db = new Database();

            //Act
            Type type = typeof(Database);
            var indexValue = (int)type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(db);       

            //Assert
            Assert.That(indexValue, Is.EqualTo(InitialArrayIndex));
        }


        [Test]        
        public void CtorShouldThrowInvalidOperationException()
        {
            //Arrange
            int[] arr = new int[ArraySize + 1];          
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(arr));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] {13})]
        [TestCase(new int[] {13, 12, 11, 10, 9})]
        [TestCase(new int[] {16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1})]
        public void CtorShouldSetIndexCorrectly(int[] values)
        {
            //Arrange
            Database db = new Database(values);

            int expectedIndex = values.Length - 1;
            Type type = typeof(Database);
            var indexValue = (int)type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(db);
            //Act

            //Assert
            Assert.That(indexValue, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] {15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        public void AddShouldIncreaseIndexCorectly(int[] values)
        {
            Database db = new Database(values );
            db.Add(16);
            Type type = typeof(Database);
            var indexValue = (int)type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(db);

            int expectedIndex = values.Length;

            Assert.That(indexValue, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void AddWhenDatabaseIsFullShouldThrowInvalidOperationException()
        {
            //Arrange
            int[] arr = new int[16];
            Database db = new Database(arr);
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(1));
        }

        [Test]
        public void RemoveShouldDecreaseIndex()
        {
            //Arrange
            int[] arr = new int[10];

            Database db = new Database(arr);

            //Act
            db.Remove();

            Type type = typeof(Database);
            var indexValue = (int)type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(db);

            int expectedIndex = arr.Length - 2;
            //Assert
            Assert.That(indexValue, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void RemoveFromEmptyDatabaseShouldThrowInvalidOperationException()
        {
            //Arrange
            Database db = new Database();

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }
    }
}
