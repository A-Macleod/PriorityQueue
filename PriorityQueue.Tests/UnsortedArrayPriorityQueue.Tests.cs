using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PriorityQueue;

namespace PriorityQueue.Tests
{
    public class UnsortedArrayPriorityQueueTests
    {

        private UnsortedArrayPriorityQueue<Person> unsortedArrayPriorityQueue;



        [SetUp]
        public void Setup()
        {
            int size = 8;
            unsortedArrayPriorityQueue = new UnsortedArrayPriorityQueue<Person>(size);
        }



        [TearDown]
        public void TearDown()
        {
            unsortedArrayPriorityQueue = null;
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsEmptyWhenQueueIsEmpty()
        {
            // Assert
            Assert.That(unsortedArrayPriorityQueue.IsEmpty, Is.True);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenItemsAreAdded()
        {
            // Act
            unsortedArrayPriorityQueue.Add(new Person("one"), 90);

            // Assert
            Assert.That(unsortedArrayPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenQueueIsFull()
        {
            // Act
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("four"), 40);
            unsortedArrayPriorityQueue.Add(new Person("five"), 50);
            unsortedArrayPriorityQueue.Add(new Person("six"), 60);
            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            unsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Assert
            Assert.That(unsortedArrayPriorityQueue.IsEmpty, Is.False);
        }



        [Test]
        public void Add_AddingOneItemToQueue()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);

            // Act
            var head = unsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("one", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingRemovingThenAddingWhileTrackingTheHighestPriority()
        {
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("four"), 40);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);

            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();

            unsortedArrayPriorityQueue.Add(new Person("five"), 50);

            var head = unsortedArrayPriorityQueue.Head();

            Assert.That("five", Is.EqualTo(head.Name));
        }



        [Test]
        public void Add_AddingItemWithNullNameDoesNotGetAddedToQueue()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person(null), 10);

            // Act
            var result = unsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("[(, 10)]", Is.Not.EqualTo(result)); ;
        }



        [Test]
        public void Add_ThrowsTheCorrectExceptionErrorMessageWhenAddingNewItemAndTheQueueIsFull()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("four"), 40);
            unsortedArrayPriorityQueue.Add(new Person("five"), 50);
            unsortedArrayPriorityQueue.Add(new Person("six"), 60);
            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            unsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Act
            var exception = Assert.Throws<QueueOverflowException>(() => unsortedArrayPriorityQueue.Add(new Person("nine"), 90));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is full"));
        }




        [Test]
        public void Add_AddingItemsToQueueUntilTheQueueIsFullAndExceptionMessageIsThrown()
        {

            // Act
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("four"), 40);
            unsortedArrayPriorityQueue.Add(new Person("five"), 50);
            unsortedArrayPriorityQueue.Add(new Person("six"), 60);
            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            unsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Assert
            Assert.That(() => unsortedArrayPriorityQueue.Add(new Person("nine"), 90), Throws.TypeOf<QueueOverflowException>());
        }




        [Test]
        public void Constructor_InitializesArrayWithCorrectSizeThrowsOverflowExceptionWhenExceeded()
        {
            // Act
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("four"), 40);
            unsortedArrayPriorityQueue.Add(new Person("five"), 50);
            unsortedArrayPriorityQueue.Add(new Person("six"), 60);
            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            unsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Act & Assert
            Assert.That(() => unsortedArrayPriorityQueue.Add(new Person("nine"), 90), Throws.TypeOf<QueueOverflowException>());
        }



        [Test]
        public void Remove_RemovesHighestPriorityFromQueue()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);

            // Act
            unsortedArrayPriorityQueue.Remove();
            var head = unsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("two", Is.EqualTo(head.Name));
        }



        [Test]
        public void Remove_AddsAndFillsTheQueueThenRemovesAllTheItemsFromTheQueueThenThrowsExceptionErrorWhenEmpty()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("four"), 40);
            unsortedArrayPriorityQueue.Add(new Person("five"), 50);
            unsortedArrayPriorityQueue.Add(new Person("six"), 60);
            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            unsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Act
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();

            // Assert
            Assert.That(() => unsortedArrayPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Remove_ThrowsTheCorrectExceptionErrorMessage()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => unsortedArrayPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));
        }



        [Test]
        public void Remove_DequeuesItemsFromQueueThrowsExceptionWhenRemovingFromEmptyQueue()
        {
            // Arrange
            int size = 8;
            unsortedArrayPriorityQueue = new UnsortedArrayPriorityQueue<Person>(size);
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);


            // Act
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();

            // Assert
            Assert.That(() => unsortedArrayPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Head_IsTheHighestPriorityItem()
        {
            // Act
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);

            var head = unsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_IsTheHighestPriorityAfterMultipleDeletes()
        {
            // Act
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("five"), 50);
            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);

            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();

            var head = unsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_IsTheHighestPriorityAfterMultipleDeletesAndThenMoreAdds()
        {
            // Act
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("five"), 50);
            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);

            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();

            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            unsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            var head = unsortedArrayPriorityQueue.Head();

            // Assert
            Assert.That("eight", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_ThrowsCorrectExceptionErrorWhenQueueIsEmpty()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => unsortedArrayPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));

        }



        [Test]
        public void Head_ThrowsExceptionErrorWhenQueueIsEmpty()
        {
            Assert.That(() => unsortedArrayPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormat()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person("one"), 90);

            // Act
            var result = unsortedArrayPriorityQueue.ToString();

            // Assert
            Assert.That("[(one, 90)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormatWithMultipleAddsAndIsNotSorted()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person("one"), 50);
            unsortedArrayPriorityQueue.Add(new Person("three"), 65);
            unsortedArrayPriorityQueue.Add(new Person("five"), 100);

            // Act
            var result = unsortedArrayPriorityQueue.ToString();

            // Assert
            Assert.That("[(one, 50), (three, 65), (five, 100)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormatWithMultipleAddsAndMultipleDeletesAndIsNotSorted()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person("two"), 40);
            unsortedArrayPriorityQueue.Add(new Person("three"), 65);
            unsortedArrayPriorityQueue.Add(new Person("five"), 100);

            unsortedArrayPriorityQueue.Remove();
            unsortedArrayPriorityQueue.Remove();

            unsortedArrayPriorityQueue.Add(new Person("one"), 50);

            // Act
            var result = unsortedArrayPriorityQueue.ToString();

            // Assert
            Assert.That("[(two, 40), (one, 50)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsAllTheItemsInTheUnsortedArrayInCorrectOrder()
        {
            // Arrange
            unsortedArrayPriorityQueue.Add(new Person("three"), 30);
            unsortedArrayPriorityQueue.Add(new Person("four"), 40);
            unsortedArrayPriorityQueue.Add(new Person("one"), 10);
            unsortedArrayPriorityQueue.Add(new Person("two"), 20);
            unsortedArrayPriorityQueue.Add(new Person("five"), 50);
            unsortedArrayPriorityQueue.Add(new Person("six"), 60);
            unsortedArrayPriorityQueue.Add(new Person("seven"), 70);
            unsortedArrayPriorityQueue.Add(new Person("eight"), 80);

            // Act
            var result = unsortedArrayPriorityQueue.ToString();

            // Assert
            Assert.That("[(three, 30), (four, 40), (one, 10), (two, 20), (five, 50), (six, 60), (seven, 70), (eight, 80)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ThrowsCorrectExceptionMessageWhenToStringIsCalledOnAnEmptyQueue()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => unsortedArrayPriorityQueue.ToString());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No items to display"));
        }



        [Test]
        public void ToString_ThrowsExceptionWhenThetoStringMethodIsCalledOnAnEmptyQueue()
        {
            // Assert
            Assert.That(() => unsortedArrayPriorityQueue.ToString(), Throws.TypeOf<QueueUnderflowException>());
        }






    }
}
