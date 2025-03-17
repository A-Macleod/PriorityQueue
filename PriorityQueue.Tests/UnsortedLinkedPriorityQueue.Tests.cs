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
        public void IsEmpty_CheckTheQueueIsNotEmptyWhenThereAreALotOfItemsInTheQueue()
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



        [Test]
        public void Remove_RemovesHighestPriorityFromQueue()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);
            unsortedLinkedPriorityQueue.Add(new Person("two"), 20);

            // Act
            unsortedLinkedPriorityQueue.Remove();
            var head = unsortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("two", Is.EqualTo(head.Name));
        }



        [Test]
        public void Remove_AddsToTheQueueThenRemovesAllTheItemsFromTheQueueThenThrowsExceptionErrorWhenEmpty()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("two"), 20);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);
            unsortedLinkedPriorityQueue.Add(new Person("four"), 40);
            unsortedLinkedPriorityQueue.Add(new Person("five"), 50);
            unsortedLinkedPriorityQueue.Add(new Person("six"), 60);
            unsortedLinkedPriorityQueue.Add(new Person("seven"), 70);
            unsortedLinkedPriorityQueue.Add(new Person("eight"), 80);

            // Act
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();

            // Assert
            Assert.That(() => unsortedLinkedPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Remove_ThrowsTheCorrectExceptionErrorMessage()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => unsortedLinkedPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));
        }



        [Test]
        public void Remove_DequeuesItemsFromQueueThrowsExceptionWhenRemovingFromEmptyQueue()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);
            unsortedLinkedPriorityQueue.Add(new Person("two"), 20);


            // Act
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();

            // Assert
            Assert.That(() => unsortedLinkedPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void Head_IsTheHighestPriorityItem()
        {
            // Act
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);
            unsortedLinkedPriorityQueue.Add(new Person("two"), 20);

            var head = unsortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_IsTheHighestPriorityAfterMultipleDeletes()
        {
            // Act
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);
            unsortedLinkedPriorityQueue.Add(new Person("five"), 50);
            unsortedLinkedPriorityQueue.Add(new Person("seven"), 70);

            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();

            var head = unsortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("three", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_IsTheHighestPriorityAfterMultipleDeletesAndThenMoreAdds()
        {
            // Act
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);
            unsortedLinkedPriorityQueue.Add(new Person("five"), 50);
            unsortedLinkedPriorityQueue.Add(new Person("seven"), 70);

            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();

            unsortedLinkedPriorityQueue.Add(new Person("seven"), 70);
            unsortedLinkedPriorityQueue.Add(new Person("eight"), 80);

            var head = unsortedLinkedPriorityQueue.Head();

            // Assert
            Assert.That("eight", Is.EqualTo(head.Name));
        }



        [Test]
        public void Head_ThrowsCorrectExceptionErrorWhenQueueIsEmpty()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => unsortedLinkedPriorityQueue.Remove());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Queue is empty"));

        }



        [Test]
        public void Head_ThrowsExceptionErrorWhenQueueIsEmpty()
        {
            Assert.That(() => unsortedLinkedPriorityQueue.Remove(), Throws.TypeOf<QueueUnderflowException>());
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormat()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person("one"), 90);

            // Act
            var result = unsortedLinkedPriorityQueue.ToString();

            // Assert
            Assert.That("[(one, 90)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormatWithMultipleAddsAndIsNotSorted()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person("one"), 50);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 65);
            unsortedLinkedPriorityQueue.Add(new Person("five"), 100);

            // Act
            var result = unsortedLinkedPriorityQueue.ToString();

            // Assert
            Assert.That("[(one, 50), (three, 65), (five, 100)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsInCorrectFormatWithMultipleAddsAndMultipleDeletesAndIsNotSorted()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person("two"), 40);
            unsortedLinkedPriorityQueue.Add(new Person("three"), 65);
            unsortedLinkedPriorityQueue.Add(new Person("five"), 100);

            unsortedLinkedPriorityQueue.Remove();
            unsortedLinkedPriorityQueue.Remove();

            unsortedLinkedPriorityQueue.Add(new Person("one"), 50);

            // Act
            var result = unsortedLinkedPriorityQueue.ToString();

            // Assert
            Assert.That("[(two, 40), (one, 50)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ChecksTheToStringMethodOutputsAllTheItemsInTheUnsortedListInCorrectOrder()
        {
            // Arrange
            unsortedLinkedPriorityQueue.Add(new Person("three"), 30);
            unsortedLinkedPriorityQueue.Add(new Person("four"), 40);
            unsortedLinkedPriorityQueue.Add(new Person("one"), 10);
            unsortedLinkedPriorityQueue.Add(new Person("two"), 20);
            unsortedLinkedPriorityQueue.Add(new Person("five"), 50);
            unsortedLinkedPriorityQueue.Add(new Person("six"), 60);
            unsortedLinkedPriorityQueue.Add(new Person("seven"), 70);
            unsortedLinkedPriorityQueue.Add(new Person("eight"), 80);

            // Act
            var result = unsortedLinkedPriorityQueue.ToString();

            // Assert
            Assert.That("[(three, 30), (four, 40), (one, 10), (two, 20), (five, 50), (six, 60), (seven, 70), (eight, 80)]", Is.EqualTo(result));
        }



        [Test]
        public void ToString_ThrowsCorrectExceptionMessageWhenToStringIsCalledOnAnEmptyQueue()
        {
            // Act
            var exception = Assert.Throws<QueueUnderflowException>(() => unsortedLinkedPriorityQueue.ToString());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No items to display"));
        }



        [Test]
        public void ToString_ThrowsExceptionWhenThetoStringMethodIsCalledOnAnEmptyQueue()
        {
            // Assert
            Assert.That(() => unsortedLinkedPriorityQueue.ToString(), Throws.TypeOf<QueueUnderflowException>());
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
