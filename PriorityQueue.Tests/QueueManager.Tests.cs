using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;
using PriorityQueue;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;


namespace PriorityQueue.Tests
{
    public class QueueManagerTests
    {

        private QueueManager _form;
        private ComboBox _comboBox;
        private Label _label;
        private Button _button;
        private TextBox _textBox;
        private NumericUpDown _numericUpDown;



        [SetUp]
        public void Setup()
        {
            _form = new QueueManager();
            _form.Show();

            _comboBox = new ComboBox();
            _form.Controls.Add(_comboBox);

            _label = new Label();
            _form.Controls.Add(_label);

            _comboBox.Items.Add("Sorted Array Priority Queue");
            _comboBox.Items.Add("Unsorted Array Priority Queue");
            _comboBox.Items.Add("Unsorted LinkedList Priority Queue");
            _comboBox.Items.Add("Sorted LinkedList Priority Queue");

        }



        [TearDown]
        public void TearDown()
        {
            _comboBox.Dispose();
            _label.Dispose();
            _form.Close();
            _form.Dispose();
        }



        [Test]
        public void CB_Implementation_IsNotNullWithQueuesInTheList()
        {
            // Assert
            Assert.That(_comboBox, Is.Not.Null, "The list should not be null");
        }



        [TestCase("Sorted Array Priority Queue")]
        [TestCase("Unsorted Array Priority Queue")]
        [TestCase("Unsorted LinkedList Priority Queue")]
        [TestCase("Sorted LinkedList Priority Queue")]
        public void CB_Implementation_ContainsCorrectFourImplementationsOfPriorityQueue(string queueType)
        {
            // Assert
            Assert.That(_comboBox.Items.Contains(queueType), "It should have each implementation in the list");
        }



        [Test]
        public void CB_Implementation_ListContainsFourImplementationsOfPriorityQueue()
        {
            Assert.That(4, Is.EqualTo(_comboBox.Items.Count), "It should have 4 items in the list");
        }



        [TestCase("Sorted Array Priority Queue")]
        [TestCase("Unsorted Array Priority Queue")]
        [TestCase("Unsorted LinkedList Priority Queue")]
        [TestCase("Sorted LinkedList Priority Queue")]
        public void CB_Implementation_OnSelectionPanelsAreVisible_SimulatingChangingBoolStateAfterListSelection(string queueType)
        {
            var isSelected = false;
            _comboBox.SelectedIndexChanged += (sender, e) => isSelected = true; // Simulate event handler to change bool state when item is selected

            _comboBox.SelectedItem = queueType; // Testing for each comboBox item

            // Assert
            Assert.That(isSelected, Is.True, "It should be true after item is selected");
        }



        [Test]
        public void CB_Implementation_SimulateQueueSelectionAndQueueInstantiationSortedArray()
        {
            SortedArrayPriorityQueue<Person> sortedArray = null;            

            // Act
            _comboBox.SelectedIndexChanged += (sender, e) =>
            {
                sortedArray = new SortedArrayPriorityQueue<Person>(8);
                _label.Text = "New sorted array priority queue created";
            };

            _comboBox.SelectedItem = "Sorted Array Priority Queue"; // Trigger the event handler for selecting the list option

            // Assert
            Assert.That(sortedArray, Is.InstanceOf<SortedArrayPriorityQueue<Person>>());
            Assert.That("New sorted array priority queue created", Is.EqualTo(_label.Text));
        }



        [Test]
        public void CB_Implementation_SimulateQueueSelectionAndQueueInstantiationUnsortedArray()
        {
            UnsortedArrayPriorityQueue<Person> unsortedArray = null;

            // Act
            _comboBox.SelectedIndexChanged += (sender, e) =>
            {
                unsortedArray = new UnsortedArrayPriorityQueue<Person>(8);
                _label.Text = "New unsorted array priority queue created";
            };

            _comboBox.SelectedItem = "Unsorted Array Priority Queue"; // Trigger the event handler for selecting the list option

            // Assert
            Assert.That(unsortedArray, Is.InstanceOf<UnsortedArrayPriorityQueue<Person>>());
            Assert.That("New unsorted array priority queue created", Is.EqualTo(_label.Text));
        }



        [Test]
        public void CB_Implementation_SimulateQueueSelectionAndQueueInstantiationUnsortedList()
        {
            UnsortedLinkedPriorityQueue<Person> unsortedLinkedList = null;

            // Act
            _comboBox.SelectedIndexChanged += (sender, e) =>
            {
                unsortedLinkedList = new UnsortedLinkedPriorityQueue<Person>();
                _label.Text = "New unsorted linked priority queue created";
            };

            _comboBox.SelectedItem = "Unsorted LinkedList Priority Queue"; // Trigger the event handler for selecting the list option

            // Assert
            Assert.That(unsortedLinkedList, Is.InstanceOf<UnsortedLinkedPriorityQueue<Person>>());
            Assert.That("New unsorted linked priority queue created", Is.EqualTo(_label.Text));
        }



        [Test]
        public void CB_Implementation_SimulateQueueSelectionAndQueueInstantiationSortedList()
        {
            SortedLinkedPriorityQueue<Person> sortedLinkedList = null;

            // Act
            _comboBox.SelectedIndexChanged += (sender, e) =>
            {
                sortedLinkedList = new SortedLinkedPriorityQueue<Person>();
                _label.Text = "New sorted linked priority queue created";
            };

            _comboBox.SelectedItem = "Sorted LinkedList Priority Queue"; // Trigger the event handler for selecting the list option

            // Assert
            Assert.That(sortedLinkedList, Is.InstanceOf<SortedLinkedPriorityQueue<Person>>());
            Assert.That("New sorted linked priority queue created", Is.EqualTo(_label.Text));
        }



        [Test]
        public void Btn_AddQueue_Click_SimulateAddingPersonNameToTextBoxItIsNotNullOrWhitespace()
        {
            // Arrange
            _textBox = new TextBox();   // Person name text box

            // Act
            _textBox.Text = "personName";
            
            // Assert
            Assert.That(_textBox.Text, Is.Not.Null.And.Not.WhiteSpace);
        }



        [Test]
        public void Btn_AddQueue_Click_SimulateAddingPersonNameToTextBoxThatIsNull()
        {
            // Arrange
            _textBox = new TextBox();   // Person name text box

            // Act
            _textBox.Text = null;

            // Assert
            Assert.That(_textBox.Text, Is.Null.Or.WhiteSpace);
        }



        [Test]
        public void Btn_AddQueue_Click_SimulateAddingPersonNameToTextBoxThatIsWhitespace()
        {
            // Arrange
            _textBox = new TextBox();   // Person name text box

            // Act
            _textBox.Text = " ";

            // Assert
            Assert.That(_textBox.Text, Is.Null.Or.WhiteSpace);
        }



        [Test]
        public void Btn_AddQueue_Click_SimulateAddingPersonNameAndPriorityAssertingPersonHasBeenAdded()
        {
            UnsortedArrayPriorityQueue<Person> queue = null;

            // Arrange
            _button = new Button(); // Add button
            _textBox = new TextBox();   // Person name text box
            _numericUpDown = new NumericUpDown();   // Priority numeric up down                                                    

            _button.Click += (sender, e) =>
            {
                _textBox.Text = "personName" ;
                _numericUpDown.Value = 50;
                int numericInt = (int)_numericUpDown.Value;  // _numbericUpDown.Value is of type Decimal, we need to convert to Int

                Person person = new Person(_textBox.Text);
                queue.Add(person, numericInt);

                //Assert.That("personName", Is.EqualTo(person.Name));
                _label.Text = "Added " + person.ToString();

                Assert.That("Added personName", Is.EqualTo(_label.Text));

            };
        }

    }
}
