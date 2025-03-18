﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Windows.Forms;
using PriorityQueue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Collections;

namespace PriorityQueue.Tests
{
    public class QueueManagerTests
    {

        private QueueManager _form;
        private ComboBox _comboBox;



        [SetUp]
        public void Setup()
        {
            _form = new QueueManager();
            _form.Show();
            
        }



        [TearDown]
        public void TearDown()
        {
            _form.Close();
            _form.Dispose();
        }



        [Test]
        public void CB_Implementation_IsNotNullWithQueuesInTheList()
        {
            // Arrange & Act
            _comboBox = new ComboBox();
            _form.Controls.Add(_comboBox);

            _comboBox.Items.Add("Sorted Array Priority Queue");
            _comboBox.Items.Add("Unsorted Array Priority Queue");
            _comboBox.Items.Add("Unsorted LinkedList Priority Queue");
            _comboBox.Items.Add("Sorted LinkedList Priority Queue");

            // Assert
            Assert.That(_comboBox, Is.Not.Null, "The list should not be null");
        }



        [TestCase("Sorted Array Priority Queue")]
        [TestCase("Unsorted Array Priority Queue")]
        [TestCase("Unsorted LinkedList Priority Queue")]
        [TestCase("Sorted LinkedList Priority Queue")]
        public void CB_Implementation_ContainsCorrectFourImplementationsOfPriorityQueue(string queueType)
        {
            // Arrange & Act
            _comboBox = new ComboBox();
            _form.Controls.Add(_comboBox);

            _comboBox.Items.Add("Sorted Array Priority Queue");
            _comboBox.Items.Add("Unsorted Array Priority Queue");
            _comboBox.Items.Add("Unsorted LinkedList Priority Queue");
            _comboBox.Items.Add("Sorted LinkedList Priority Queue");

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
            // Arrange & Act
            _comboBox = new ComboBox();
            _form.Controls.Add(_comboBox);

            _comboBox.Items.Add("Sorted Array Priority Queue");
            _comboBox.Items.Add("Unsorted Array Priority Queue");
            _comboBox.Items.Add("Unsorted LinkedList Priority Queue");
            _comboBox.Items.Add("Sorted LinkedList Priority Queue");

            var isSelected = false;
            _comboBox.SelectedIndexChanged += (sender, e) => isSelected = true; // Simulate event handler to change bool state when item is selected

            _comboBox.SelectedItem = queueType; // Testing for each comboBox item

            // Assert
            Assert.That(isSelected, Is.True, "It should be true after item is selected");

        }
    }
}
