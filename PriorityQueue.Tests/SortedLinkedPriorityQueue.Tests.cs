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



        [Test]
        public void Remove_RemovesHighestPriorityFromQueue()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);
            sortedLinkedPriorityQueue.Add(new Person("two"), 20);

            // Act
            sortedLinkedPriorityQueue.Remove();
            var head = sortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("two", Is.EqualTo(head.Name));
        }



        [Test]
        public void Remove_AddsToTheQueueThenRemovesAllTheItemsFromTheQueueThenThrowsExceptionErrorWhenEmpty()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("two"), 20);
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);
            sortedLinkedPriorityQueue.Add(new Person("four"), 40);
            sortedLinkedPriorityQueue.Add(new Person("five"), 50);
            sortedLinkedPriorityQueue.Add(new Person("six"), 60);
            sortedLinkedPriorityQueue.Add(new Person("seven"), 70);
            sortedLinkedPriorityQueue.Add(new Person("eight"), 80);

            // Act
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();

            // Assert
            Assert.That(() => sortedLinkedPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Remove_ThrowsTheCorrectExceptionErrorMessage()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => sortedLinkedPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));
        }



        [Test]
        public void Remove_DequeuesItemsFromQueueThrowsExceptionWhenRemovingFromEmptyQueue()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);
            sortedLinkedPriorityQueue.Add(new Person("two"), 20);

            // Act
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();

            // Assert
            Assert.That(() => sortedLinkedPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Head_IsTheHighestPriorityItem()
        {
            // Act
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);
            sortedLinkedPriorityQueue.Add(new Person("two"), 20);

            var head = sortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_IsTheHighestPriorityAfterMultipleDeletes()
        {
            // Act
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);
            sortedLinkedPriorityQueue.Add(new Person("five"), 50);
            sortedLinkedPriorityQueue.Add(new Person("seven"), 70);

            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();

            var head = sortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_IsTheHighestPriorityAfterMultipleDeletesAndThenMoreAdds()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);
            sortedLinkedPriorityQueue.Add(new Person("five"), 50);
            sortedLinkedPriorityQueue.Add(new Person("seven"), 70);

            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();

            sortedLinkedPriorityQueue.Add(new Person("seven"), 70);
            sortedLinkedPriorityQueue.Add(new Person("eight"), 80);

            // Act
            var head = sortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("eight", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_ThrowsCorrectExceptionErrorWhenQueueIsEmpty()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => sortedLinkedPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));

        }



        [Test]
        public void Head_ThrowsExceptionErrorWhenQueueIsEmpty()
        {
            Assert.That(() => sortedLinkedPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormat()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("one"), 90);

            // Act
            var result = sortedLinkedPriorityQueue.ToString();

            // Assert
            Assert.That("[(one, 90)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormatWithMultipleAddsAndIsSortedByPriority()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("one"), 50);
            sortedLinkedPriorityQueue.Add(new Person("three"), 65);
            sortedLinkedPriorityQueue.Add(new Person("five"), 100);

            // Act
            var result = sortedLinkedPriorityQueue.ToString();

            // Assert
            Assert.That("[(five, 100), (three, 65), (one, 50)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormatWithMultipleAddsAndMultipleDeletesAndIsSortedByPriority()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("two"), 40);
            sortedLinkedPriorityQueue.Add(new Person("three"), 65);
            sortedLinkedPriorityQueue.Add(new Person("five"), 100);

            sortedLinkedPriorityQueue.Remove();
            sortedLinkedPriorityQueue.Remove();

            sortedLinkedPriorityQueue.Add(new Person("one"), 50);

            // Act
            var result = sortedLinkedPriorityQueue.ToString();

            // Assert
            Assert.That("[(one, 50), (two, 40)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsAllTheItemsInTheSortedListInCorrectOrder()
        {
            // Arrange
            sortedLinkedPriorityQueue.Add(new Person("three"), 30);
            sortedLinkedPriorityQueue.Add(new Person("four"), 40);
            sortedLinkedPriorityQueue.Add(new Person("one"), 10);
            sortedLinkedPriorityQueue.Add(new Person("two"), 20);
            sortedLinkedPriorityQueue.Add(new Person("five"), 50);
            sortedLinkedPriorityQueue.Add(new Person("six"), 60);
            sortedLinkedPriorityQueue.Add(new Person("seven"), 70);
            sortedLinkedPriorityQueue.Add(new Person("eight"), 80);

            // Act
            var result = sortedLinkedPriorityQueue.ToString();

            // Assert
            Assert.That("[(eight, 80), (seven, 70), (six, 60), (five, 50), (four, 40), (three, 30), (two, 20), (one, 10)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ThrowsCorrectExceptionMessageWhenToStringIsCalledOnAnEmptyQueue()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => sortedLinkedPriorityQueue.ToString());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No items to display"));
        }



        [Test]
        public void ToString_ThrowsExceptionWhenThetoStringMethodIsCalledOnAnEmptyQueue()
        {
            // Assert
            Assert.That(() => sortedLinkedPriorityQueue.ToString(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Node_ConstructorInitialNextPointerIsNull()
        {
            var node = new Node<Person>(new Person("person1"), 10);

            Assert.That(null, Is.EqualTo(node.Next));

        }



        [Test]
        public void Node_ConstructorNameIsStoredCorrectly()
        {
            var node = new Node<Person>(new Person("person1"), 10);

            Assert.That("person1", Is.EqualTo(node.Item.Name));

        }



        [Test]
        public void Node_ConstructorPriorityIsStoredCorrectly()
        {
            var node = new Node<Person>(new Person("person1"), 10);

            Assert.That(10, Is.EqualTo(node.Priority));

        }



        [Test]
        public void Node_CheckNextPointerPointsToNextNode()
        {
            // Arrange
            var node = new Node<Person>(new Person("person1"), 10);
            var node1 = new Node<Person>(new Person("person2"), 20);

            // Act
            node.Next = node1;
            node1.Next = null;

            // Assert
            Assert.That(node.Next, Is.EqualTo(node1));
            Assert.That(node1.Next, Is.Null);

        }


























    }
}
