﻿using NUnit.Framework;
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



        [TestCase("one", 10)]
        [TestCase("two", 20)]
        [TestCase("three", 30)]
        [TestCase("four", 40)]
        [TestCase("five", 50)]
        [TestCase("six", 60)]
        [TestCase("seven", 70)]
        [TestCase("eight", 80)]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenQueueIsFull(string name, int priority)
        {
            // Act
            sortedArrayPriorityQueue.Add(new Person(name), priority);

            // Assert
            Assert.That(sortedArrayPriorityQueue.IsEmpty, Is.False);
        }



        [TestCase()]
        public void Constructor_InitializesArrayWithCorrectSizeThrowsOverflowExceptionWhenExceeded()
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
