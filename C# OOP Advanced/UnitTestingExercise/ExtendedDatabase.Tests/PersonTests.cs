namespace ExtendedDatabase.Tests
{
    using ExtendedDatabase.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void ConstructorInitializationWorks()
        {
            // Arrange
            var person = new Person(123, "Test");
            // Assert
            Assert.AreNotEqual(null, person);
            Assert.AreEqual(123, person.Id);
            Assert.AreEqual("Test", person.Username);
        }

        [Test]
        public void AllPropertiesHaveNonPublicSetters()
        {
            // Arrange
            var personType = typeof(Person);
            var propertiesWithPublicSetters = personType
                .GetProperties()
                .Where(p => p.SetMethod.IsPublic)
                .ToArray();  
            // Assert
            Assert.AreEqual(0, propertiesWithPublicSetters.Length);
        }
    }
}
