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
        public void IsEmpty_CheckTheQueueIsEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(sortedArrayPriorityQueue.IsEmpty);
        }


    }
}
