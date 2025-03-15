using NUnit.Framework;
using System;
using System.Xml.Linq;

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
        public void IsEmpty_CheckTheQueueIsEmptyWhenQueueIsEmpty()
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

        public void IsEmpty_CheckTheQueueIsNotEmptyWhenQueueIsFull()
        {
            // Act
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("two"), 20);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);
            sortedArrayPriorityQueue.Add(new Person("four"), 40);
            sortedArrayPriorityQueue.Add(new Person("five"), 50);
            sortedArrayPriorityQueue.Add(new Person("six"), 60);
            sortedArrayPriorityQueue.Add(new Person("seven"), 70);
            sortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Assert
            Assert.That(sortedArrayPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void Constructor_InitializesArrayWithCorrectSizeThrowsOverflowExceptionWhenExceeded()
        {
            // Act
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("two"), 20);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);
            sortedArrayPriorityQueue.Add(new Person("four"), 40);
            sortedArrayPriorityQueue.Add(new Person("five"), 50);
            sortedArrayPriorityQueue.Add(new Person("six"), 60);
            sortedArrayPriorityQueue.Add(new Person("seven"), 70);
            sortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Assert
            Assert.That(() => sortedArrayPriorityQueue.Add(new Person("nine"), 90), Throws.TypeOf<QueueOverflowException>());
        }



        [Test]
        public void Remove_DequeuesItemsFromQueueThrowsExceptionWhenRemovingFromEmptyQueue()
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



        [Test]
        public void Head_IsTheHighestPriorityItem()
        {
            // Arrange
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);

            // Act
            var head = sortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }







    }
}
