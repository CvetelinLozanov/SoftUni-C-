using CustomLinkedList;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private const int InitialCount = 0;
        private DynamicList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new DynamicList<int>();
        }

        [Test]
        public void ConstructorShouldSetCountToZero()
        {         
            //Arrange
            //Act
            //Assert
            Assert.That(list.Count, Is.EqualTo(InitialCount));
        }

        [Test]
        public void IndexOperatorShouldReturnValue()
        {

            //Arrange
            
            //Act
            list.Add(13);
            int element = list[0];
            //Assert
            Assert.That(element, Is.EqualTo(13));
        }

        [Test]
        public void IndexOperatorShouldSetValue()
        {
            //Arrange
            //Act
            list.Add(13);
            list[0] = 42;
            //Assert
            Assert.That(list[0], Is.EqualTo(42));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowArgumentExceptionWhenGetingInvalidIndex(int index)
        {
            //Arrange
            //Act
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
            int returnValue = 0;

            //Assert

            Assert.Throws<ArgumentOutOfRangeException>(() => returnValue = list[index]);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowExceptionWhenSetingInvalidIndex(int index)
        {
            //Arrange
            //Act
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 69, "Index" + index, "but count is 100.");
        }
    }
}