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
        public void Add_AddingOneItemToQueue()
        {
            // Arrange
            sortedArrayPriorityQueue.Add(new Person("one"), 10);

            // Act
            var head = sortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("one", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddRemoveAdd()
        {

        }


        [Test]
        public void Add_AddingItemWithNullNameDoesNotGetAddedToQueue()
        {
            // Arrange
            sortedArrayPriorityQueue.Add(new Person(""), 10);

            // Act
            var head = sortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("one", Is.Not.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingItemsToQueueUntilTheQueueIsFullAndExceptionMessageIsThrown()
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

            // Act
            var exception = Assert.Throws<QueueOverflowException>(() => sortedArrayPriorityQueue.Add(new Person("nine"), 90));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is full"));
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
            
            // Act & Assert
            Assert.That(() => sortedArrayPriorityQueue.Add(new Person("nine"), 90), Throws.TypeOf<QueueOverflowException>());
        }



        [Test]
        public void Remove_RemovesHighestPriorityFromQueue()
        {
            // Arrange
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("two"), 20);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);

            // Act
            sortedArrayPriorityQueue.Remove();
            var head = sortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("two", Is.EqualTo(head.Name));
        }



        [Test]
        public void Remove_AddsAndFillsTheQueueThenRemovesAllTheItemsFromTheQueueThenThrowsExceptionErrorWhenEmpty()
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

            // Act
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();

            // Assert
            Assert.That(() => sortedArrayPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Remove_ThrowsTheCorrectExceptionErrorMessage()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => sortedArrayPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));
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

            // Assert
            Assert.That(() => sortedArrayPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Head_IsTheHighestPriorityItem()
        {
            // Act
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);

            var head = sortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_IsTheHighestPriorityAfterMultipleDeletes()
        {
            // Act
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);
            sortedArrayPriorityQueue.Add(new Person("five"), 50);
            sortedArrayPriorityQueue.Add(new Person("seven"), 70);

            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();

            var head = sortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_IsTheHighestPriorityAfterMultipleDeletesAndThenMoreAdds()
        {
            // Act
            sortedArrayPriorityQueue.Add(new Person("one"), 10);
            sortedArrayPriorityQueue.Add(new Person("three"), 30);
            sortedArrayPriorityQueue.Add(new Person("five"), 50);
            sortedArrayPriorityQueue.Add(new Person("seven"), 70);

            sortedArrayPriorityQueue.Remove();
            sortedArrayPriorityQueue.Remove();

            sortedArrayPriorityQueue.Add(new Person("seven"), 70);
            sortedArrayPriorityQueue.Add(new Person("eight"), 80);

            var head = sortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("eight", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_ThrowsExceptionErrorWhenQueueIsEmpty()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => sortedArrayPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));
 
        }

    }
}
