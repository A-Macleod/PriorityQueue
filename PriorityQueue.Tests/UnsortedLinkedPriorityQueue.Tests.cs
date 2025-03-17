using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace PriorityQueue.Tests
{
    public class UnsortedLinkedPriorityQueue
    {

        private UnsortedLinkedPriorityQueue<Person> unsortedLinkedPriorityQueue;



        [SetUp]
        public void Setup()
        {
            unsortedLinkedPriorityQueue = new UnsortedLinkedPriorityQueue<Person>();
        }



        [TearDown]
        public void TearDown()
        {
            unsortedLinkedPriorityQueue = null;
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsEmptyWhenQueueIsEmpty()
        {
            // Assert
            Assert.That(unsortedLinkedPriorityQueue.IsEmpty, Is.True);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenItemsAreAdded()
        {
            // Act
            unsortedLinkedPriorityQueue.Add(new Person("one"), 90);

            // Assert
            Assert.That(unsortedLinkedPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenQueueIsFull()
        {
            // Act
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("two"), 20);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);
            unsortedLinkedPriorityQueue.Add(new Person("four"), 40);
            unsortedLinkedPriorityQueue.Add(new Person("five"), 50);
            unsortedLinkedPriorityQueue.Add(new Person("six"), 60);
            unsortedLinkedPriorityQueue.Add(new Person("seven"), 70);
            unsortedLinkedPriorityQueue.Add(new Person("eight"), 80);

            // Assert
            Assert.That(unsortedLinkedPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void Add_AddingOneItemToQueue()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);

            // Act
            var head = unsortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("one", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingRemovingThenAddingWhileTrackingTheHighestPriority()
        {
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("four"), 40);
            unsortedLinkedPriorityQueue.Add(new Person("two"), 20);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);

            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();

            unsortedLinkedPriorityQueue.Add(new Person("five"), 50);

            var head = unsortedLinkedPriorityQueue.Head();

            Assert.That("five", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingItemWithNullNameDoesNotGetAddedToQueue()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person(null), 10);

            // Act
            var result = unsortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("[(, 10)]", Is.Not.EqualTo(result)); ;
        }
        






















    }
}
