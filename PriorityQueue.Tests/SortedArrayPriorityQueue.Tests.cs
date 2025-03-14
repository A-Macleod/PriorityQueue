using NUnit.Framework;
using System;

namespace PriorityQueue.Tests
{
    public class SortedArrayPriorityQueueTests
    {

        private SortedArrayPriorityQueue<Person> sortedArrayPriorityQueue;



        [SetUp]
        public void Setup()
        {
            int size = 8;
            sortedArrayPriorityQueue = new SortedArrayPriorityQueue<Person>(size);
        }



        [TearDown]
        public void TearDown()
        {
            sortedArrayPriorityQueue = null;
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsEmptyWhenNoItemsAreAdded()
        {
            // Assert
            Assert.That(sortedArrayPriorityQueue.IsEmpty, Is.True);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenItemsAreAdded()
        {
            // Act
            sortedArrayPriorityQueue.Add(new Person("one"), 90);

            // Assert
            Assert.That(sortedArrayPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void Add_AddPersonToQueue()
        {
            sortedArrayPriorityQueue.Add(new Person("one"), 90);

            Assert.That(sortedArrayPriorityQueue.Head()., Is.)
        }



        [TestCase("one", 10, false)]
        [TestCase("two", 20, false)]
        [TestCase("three", 30, false)]
        [TestCase("four", 40, false)]
        [TestCase("five", 50, false)]
        [TestCase("six", 60, false)]
        [TestCase("seven", 70, false)]
        [TestCase("eight", 80, true)]

        public void Add_AddsAnItemToTheQueue_ReturnsTrueIfNotEmpty(string name, int priority, bool expected)
        {

            // Arrange


            // Act
            sortedArrayPriorityQueue.Add(new Person(name), priority);

            // Assert
            Assert.That(sortedArrayPriorityQueue.Head(), Is.EqualTo(expected));
            
        }



        [TestCase()]
        public void Constructor_InitializesArrayWithCorrectSize_ThrowsOverflowExceptionWhenExceeded()
        {
            // Arrange
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("two"), 20);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);
            sortedArrayPriorityQueue.Add(new Person("four"), 40);
            sortedArrayPriorityQueue.Add(new Person("five"), 50);
            sortedArrayPriorityQueue.Add(new Person("six"), 60);
            sortedArrayPriorityQueue.Add(new Person("seven"), 70);
            sortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Act & Assert
            Assert.That(() => sortedArrayPriorityQueue.Add(new Person("nine"), 90), Throws.TypeOf<QueueOverflowException>());
        }



        [Test]
        public void Remove_ThrowsExceptionWhenQueueIsEmpty()
        {
            // Arrange
            int size = 8;
            sortedArrayPriorityQueue = new SortedArrayPriorityQueue<Person>(size);
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("two"), 20);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);

            // Act
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();

            // Act & Assert
            Assert.That(() => sortedArrayPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }





    }
}
