using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace PriorityQueue.Tests
{
    public class UnsortedArrayPriorityQueueTests
    {

        private UnsortedArrayPriorityQueue<Person> UnsortedArrayPriorityQueue;



        [SetUp]
        public void Setup()
        {
            int size = 8;
            UnsortedArrayPriorityQueue = new UnsortedArrayPriorityQueue<Person>(size);
        }



        [TearDown]
        public void TearDown()
        {
            UnsortedArrayPriorityQueue = null;
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsEmptyWhenQueueIsEmpty()
        {
            // Assert
            Assert.That(UnsortedArrayPriorityQueue.IsEmpty, Is.True);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenItemsAreAdded()
        {
            // Act
            UnsortedArrayPriorityQueue.Add(new Person("one"), 90);

            // Assert
            Assert.That(UnsortedArrayPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenQueueIsFull()
        {
            // Act
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);
            UnsortedArrayPriorityQueue.Add(new Person("four"), 40);
            UnsortedArrayPriorityQueue.Add(new Person("five"), 50);
            UnsortedArrayPriorityQueue.Add(new Person("six"), 60);
            UnsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            UnsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Assert
            Assert.That(UnsortedArrayPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void Add_AddingOneItemToQueue()
        {
            // Arrange
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);

            // Act
            var head = UnsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("one", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingRemovingThenAddingWhileTrackingTheHighestPriority()
        {
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("four"), 40);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);

            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();

            UnsortedArrayPriorityQueue.Add(new Person("five"), 50);

            var head = UnsortedArrayPriorityQueue.Head();

            Assert.That("five", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingItemWithNullNameDoesNotGetAddedToQueue()
        {
            // Arrange
            UnsortedArrayPriorityQueue.Add(new Person(""), 10);

            // Act
            var head = UnsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("one", Is.Not.EqualTo(head.Name));
        }



        [Test]
        public void Add_ThrowsTheCorrectExceptionErrorMessageWhenAddingNewItemAndTheQueueIsFull()
        {
            // Arrange
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);
            UnsortedArrayPriorityQueue.Add(new Person("four"), 40);
            UnsortedArrayPriorityQueue.Add(new Person("five"), 50);
            UnsortedArrayPriorityQueue.Add(new Person("six"), 60);
            UnsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            UnsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Act
            var exception = Assert.Throws<QueueOverflowException>(() => UnsortedArrayPriorityQueue.Add(new Person("nine"), 90));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is full"));
        }




        [Test]
        public void Add_AddingItemsToQueueUntilTheQueueIsFullAndExceptionMessageIsThrown()
        {

            // Act
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);
            UnsortedArrayPriorityQueue.Add(new Person("four"), 40);
            UnsortedArrayPriorityQueue.Add(new Person("five"), 50);
            UnsortedArrayPriorityQueue.Add(new Person("six"), 60);
            UnsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            UnsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Assert
            Assert.That(() => UnsortedArrayPriorityQueue.Add(new Person("nine"), 90), Throws.TypeOf<QueueOverflowException>());
        }




        [Test]
        public void Constructor_InitializesArrayWithCorrectSizeThrowsOverflowExceptionWhenExceeded()
        {
            // Act
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);
            UnsortedArrayPriorityQueue.Add(new Person("four"), 40);
            UnsortedArrayPriorityQueue.Add(new Person("five"), 50);
            UnsortedArrayPriorityQueue.Add(new Person("six"), 60);
            UnsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            UnsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Act & Assert
            Assert.That(() => UnsortedArrayPriorityQueue.Add(new Person("nine"), 90), Throws.TypeOf<QueueOverflowException>());
        }



        [Test]
        public void Remove_RemovesHighestPriorityFromQueue()
        {
            // Arrange
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);

            // Act
            UnsortedArrayPriorityQueue.Remove();
            var head = UnsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("two", Is.EqualTo(head.Name));
        }



        [Test]
        public void Remove_AddsAndFillsTheQueueThenRemovesAllTheItemsFromTheQueueThenThrowsExceptionErrorWhenEmpty()
        {
            // Arrange
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);
            UnsortedArrayPriorityQueue.Add(new Person("four"), 40);
            UnsortedArrayPriorityQueue.Add(new Person("five"), 50);
            UnsortedArrayPriorityQueue.Add(new Person("six"), 60);
            UnsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            UnsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Act
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();

            // Assert
            Assert.That(() => UnsortedArrayPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Remove_ThrowsTheCorrectExceptionErrorMessage()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => UnsortedArrayPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));
        }



        [Test]
        public void Remove_DequeuesItemsFromQueueThrowsExceptionWhenRemovingFromEmptyQueue()
        {
            // Arrange
            int size = 8;
            UnsortedArrayPriorityQueue = new UnsortedArrayPriorityQueue<Person>(size);
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);


            // Act
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();
            UnsortedArrayPriorityQueue.Remove();

            // Assert
            Assert.That(() => UnsortedArrayPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Head_IsTheHighestPriorityItem()
        {
            // Act
            UnsortedArrayPriorityQueue.Add(new Person("one"), 10);
            UnsortedArrayPriorityQueue.Add(new Person("three"), 30);
            UnsortedArrayPriorityQueue.Add(new Person("two"), 20);

            var head = UnsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }










    }
}
