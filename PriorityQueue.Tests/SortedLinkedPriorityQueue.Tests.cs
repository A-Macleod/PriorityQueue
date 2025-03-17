using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace PriorityQueue.Tests
{
    public class SortedLinkedPriorityQueue
    {

        private SortedLinkedPriorityQueue<Person> sortedLinkedPriorityQueue;



        [SetUp]
        public void Setup()
        {
            sortedLinkedPriorityQueue = new SortedLinkedPriorityQueue<Person>();
        }



        [TearDown]
        public void TearDown()
        {
            sortedLinkedPriorityQueue = null;
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsEmptyWhenQueueIsEmpty()
        {
            // Assert
            Assert.That(sortedLinkedPriorityQueue.IsEmpty, Is.True);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenItemsAreAdded()
        {
            // Act
            sortedLinkedPriorityQueue.Add(new Person("one"), 90);

            // Assert
            Assert.That(sortedLinkedPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenThereAreALotOfItemsInTheQueue()
        {
            // Act
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("two"), 20);
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);
            sortedLinkedPriorityQueue.Add(new Person("four"), 40);
            sortedLinkedPriorityQueue.Add(new Person("five"), 50);
            sortedLinkedPriorityQueue.Add(new Person("six"), 60);
            sortedLinkedPriorityQueue.Add(new Person("seven"), 70);
            sortedLinkedPriorityQueue.Add(new Person("eight"), 80);

            // Assert
            Assert.That(sortedLinkedPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void Add_AddingOneItemToQueue()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);

            // Act
            var head = sortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("one", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingRemovingThenAddingWhileTrackingTheHighestPriority()
        {
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("four"), 40);
            sortedLinkedPriorityQueue.Add(new Person("two"), 20);
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);

            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();

            sortedLinkedPriorityQueue.Add(new Person("five"), 50);

            var head = sortedLinkedPriorityQueue.Head();

            Assert.That("five", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingItemWithNullNameDoesNotGetAddedToQueue()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person(null), 10);

            // Act
            var result = sortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("[(, 10)]", Is.Not.EqualTo(result));
        }





























    }
}
