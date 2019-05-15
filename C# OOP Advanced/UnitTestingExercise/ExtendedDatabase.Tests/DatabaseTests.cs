namespace Tests
{
    using ExtendedDatabase.Contracts;
    using ExtendedDatabase.Models;
    using ExtendedDatabase.Repository;
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database();
        }

        [Test]
        public void DatabaseInitializationConstructorWithCollectionOfPeople()
        {
            //Arrange
            var firstPerson = new Person(111L, "First");
            var secondPerson = new Person(222L, "Second");
            var collectionOfPeople = new IPerson[] { firstPerson, secondPerson };
            //Act
            this.database = new Database(collectionOfPeople);
            //Assets
            Assert.AreEqual(2, this.database.Count, $"Constructor doesn.t work with {typeof(IPerson)} as parameter");
        }

        [Test]
        public void DatabaseInitializeConstructorWithNullLeadsToEmptyDB()
        {
            //Assert
            Assert.DoesNotThrow(() => this.database = new Database(null));
        }

        [Test]
        public void DatabaseAddPerson()
        {
            //Arrange
            var person = new Person(111L, "Test");
            //Act
            this.database.Add(person);
            int actualResult = this.database.Count;
            int expectedResult = 1;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(1L, "1", 1L, "1")]
        [TestCase(1L, "1", 10L, "1")]
        [TestCase(10L, "1", 1L, "1")]
        public void CannotAddPersonWithAlreadyExistingUsernameOrId(long firstId, string firstName, long secondId, string secondName)
        {
            //Arrange
            var firstPerson = new Person(firstId, firstName);
            var secondPerson = new Person(secondId, secondName);
            //Act
            this.database.Add(firstPerson);
            ////Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(secondPerson));
            
        }

        [Test]
        public void RemovePersonFromDataBase()
        {
            // Arrange
            var firstPerson = new Person(1L, "First");
            var secondPerson = new Person(2L, "Second");
            var thirdPerson = new Person(2, "Second");
            this.database.Add(firstPerson);
            this.database.Add(secondPerson);
            // Act
            this.database.Remove(thirdPerson);
            this.database.Remove(firstPerson);
            // Assert
            Assert.AreEqual(0, this.database.Count, $"Remove {typeof(IPerson)} doesn't work");
        }



        [Test]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "1L")]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "2L")]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "3L")]
        public void FindByUsername(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername, string keyUsername)
        {
            // Arrange
            this.database.Add(new Person(firstId, firstUsername));
            this.database.Add(new Person(secondId, secondUsername));
            this.database.Add(new Person(thirdId, thirdUsername));
            // Act
            var foundPerson = this.database.Find(keyUsername);
            // Assert
            Assert.AreEqual(keyUsername, foundPerson.Username, $"Found {typeof(IPerson)} by Username is not the desired one");
        }

        [Test]
        public void CannotFindUnexistentId()
        {
            // Arrange 
            this.database.Add(new Person(1, "First"));
            // Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Find(2));
        }

        [Test]
        public void CannotFindNegativeId()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.Find(-1));
        }

        [Test]
        public void CannotFindUnexistentUsername()
        {
            // Arrange 
            this.database.Add(new Person(1, "First"));
            // Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Find("fiRst"));
        }



        [Test]
        public void CannotFindUsernameNull()
        {
            // Arrange 
            this.database.Add(new Person(1, "First"));
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.database.Find(null));
        }
    }
}